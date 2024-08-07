using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ical.Net;

namespace ICS_Viewer_C_
{
    public partial class Form1 : Form
    {

        string[] texts = { "No beginning", "No end", "No location", "No title", "No description" };
        public Form1()
        {
            InitializeComponent();

            //Fill textboxes
            DTStart.Text = texts[0];
            DTEnd.Text = texts[1];
            MeetingLocation.Text = texts[2];
            Summary.Text = texts[3];
            Description.Text = texts[4];
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //Check for correct data type while dragging
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //Reset textboxes
            DTStart.Text = texts[0];
            DTEnd.Text = texts[1];
            MeetingLocation.Text = texts[2];
            Summary.Text = texts[3];
            Description.Text = texts[4];

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if ( files != null && files.Length > 0 )
            {
                try
                {
                    string readContent;
                    using (StreamReader streamReader = new StreamReader(files[0], Encoding.UTF8))
                    {
                        readContent = streamReader.ReadToEnd();
                        var calendar = Calendar.Load(readContent);

                        if (calendar.Events.Count > 0)
                        {
                            foreach (var calendarEvent in calendar.Events)
                            {
                                var dtstart = calendarEvent.DtStart;
                                var dtend = calendarEvent.DtEnd;
                                string meetinglocation = calendarEvent.Location;
                                string summary = calendarEvent.Summary;
                                string description = calendarEvent.Description;

                                if (!string.IsNullOrWhiteSpace(meetinglocation)) 
                                {
                                    MeetingLocation.Text = "Location: " + meetinglocation; 
                                }
                                if (!string.IsNullOrWhiteSpace(summary))
                                {
                                    Summary.Text = "Title: " + summary;
                                }
                                if (!string.IsNullOrWhiteSpace(description))
                                {
                                    Description.Text = "Description: " + description;
                                }
                                if (dtstart != null)
                                { 
                                    DTStart.Text = "Begins: " + dtstart.Value.Day.ToString("D2") + "." + dtstart.Value.Month.ToString("D2") + "." + dtstart.Value.Year + " at " + dtstart.Value.Hour + ":" + dtstart.Value.Minute + ". Time zone: " + dtstart.TimeZoneName; 
                                }
                                if (dtend != null)
                                {
                                    DTEnd.Text = "Ends: " + dtend.Value.Day.ToString("D2") + "." + dtend.Value.Month.ToString("D2") + "." + dtend.Value.Year + " at " + dtend.Value.Hour + ":" + dtend.Value.Minute + ". Time zone: " + dtend.TimeZoneName;
                                }

                                //Stop after first event for not. TODO: Declare vars earlier, make them lists, iterate through all, implement Buttons to go through all of them.
                                break;
                            }
                        }
                        else 
                        {
                            Description.Text = "File does not contain any events!";
                        }
                    }
                }
                catch (Exception ex) 
                {
                    Description.Text = "Not a valid iCalendar file!";
                }
            }
        }
    }
}
