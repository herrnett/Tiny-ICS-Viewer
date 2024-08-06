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

namespace ICS_Viewer_C_
{
    public partial class Form1 : Form
    {

        string[] texts = { "Begins", "Ends", "Location", "Title", "Description" };
        public Form1()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            DTStart.AllowDrop = true;
            DTStart.DragEnter += new DragEventHandler(Form1_DragEnter);
            DTStart.DragDrop += new DragEventHandler(Form1_DragDrop);
            DTStart.Text = texts[0];
            DTEnd.AllowDrop = true;
            DTEnd.DragEnter += new DragEventHandler(Form1_DragEnter);
            DTEnd.DragDrop += new DragEventHandler(Form1_DragDrop);
            DTEnd.Text = texts[1];
            Location.AllowDrop = true;
            Location.DragEnter += new DragEventHandler(Form1_DragEnter);
            Location.DragDrop += new DragEventHandler(Form1_DragDrop);
            Location.Text = texts[2];
            Summary.AllowDrop = true;
            Summary.DragEnter += new DragEventHandler(Form1_DragEnter);
            Summary.DragDrop += new DragEventHandler(Form1_DragDrop);
            Summary.Text = texts[3];
            Description.AllowDrop = true;
            Description.DragEnter += new DragEventHandler(Form1_DragEnter);
            Description.DragDrop += new DragEventHandler(Form1_DragDrop);
            Description.Text = texts[4];
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            DTStart.Text = texts[0];
            DTEnd.Text = texts[1];
            Location.Text = texts[2];
            Summary.Text = texts[3];
            Description.Text = texts[4];

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if ( files != null && files.Length > 0 )
            {
                string readContents;
                using (StreamReader streamReader = new StreamReader(files[0], Encoding.UTF8))
                {
                    readContents = streamReader.ReadToEnd();
                    string[] seperators = { "VEVENT","VALARM" };
                    string[] parts = readContents.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    parts = parts[1].Split('\n');

                    string[] temp;
                    string year;
                    string month;
                    string day;
                    string hour;
                    string min;
                    foreach (string part in parts)
                    {
                        if (part.StartsWith("LOCATION"))
                        {
                            temp = part.Split(':');
                            Location.Text = "Location: " + temp[1];
                        }
                        if (part.StartsWith("SUMMARY"))
                        {
                            temp = part.Split(':');
                            Summary.Text = "Title: " + temp[1];
                        }
                        if (part.StartsWith("DESCRIPTION"))
                        {
                            seperators = new string[] { "DESCRIPTION:" };
                            temp = part.Split(seperators, StringSplitOptions.None);
                            Description.Text = "Description: " + temp[1];
                        }
                        if (part.StartsWith("DTSTART"))
                        {
                            temp = part.Split(':');
                            year = temp[1].Substring(0, 4);
                            month = temp[1].Substring(4, 2);
                            day = temp[1].Substring(6, 2);
                            hour = temp[1].Substring(9, 2);
                            min = temp[1].Substring(11, 2);
                            temp = temp[0].Split('=');
                            DTStart.Text = "Begins: " + day + "." + month + "." + year + " um " + hour + ":" + min + ". Time zone: " + temp[1];
                        }
                        if (part.StartsWith("DTEND"))
                        {
                            temp = part.Split(':');
                            year = temp[1].Substring(0, 4);
                            month = temp[1].Substring(4, 2);
                            day = temp[1].Substring(6, 2);
                            hour = temp[1].Substring(9, 2);
                            min = temp[1].Substring(11, 2);
                            temp = temp[0].Split('=');
                            DTEnd.Text = "Ends: " + day + "." + month + "." + year + " um " + hour + ":" + min + ". Time Zone: " + temp[1];
                        }
                    }   
                }
            }
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
