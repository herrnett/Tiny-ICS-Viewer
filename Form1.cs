using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ical.Net;

namespace ICS_Viewer_C_
{
    public partial class Form1 : Form
    {

        //Invoke constants for "About..."
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        //Invoke declarations for "About..."
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        //ID for the "About..." item on the system menu
        private int SYSMENU_ABOUT_ID = 0x1;

        //Textbox presets
        private string[] texts = { "No beginning", "No end", "No location", "No title", "No description" };

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

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            //Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

            //Add separator and menu item
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "&About…");
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //Test if the "About..." item was selected from the system menu
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_ABOUT_ID))
            {
                MessageBox.Show("iCal.NET (https://github.com/rianjs/ical.net)\r\n\r\nThis software includes the iCal.NET Library: Copyright (C) 2016 Douglas Day, Rian Stockbower\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.");
            }

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
                catch 
                {
                    Description.Text = "Not a valid iCalendar file!";
                }
            }
        }
    }
}
