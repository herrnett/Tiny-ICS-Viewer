using System.Windows.Forms;

namespace ICS_Viewer_C_
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DTStart = new System.Windows.Forms.TextBox();
            this.DTEnd = new System.Windows.Forms.TextBox();
            this.MeetingLocation = new System.Windows.Forms.TextBox();
            this.Summary = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTStart
            // 
            this.DTStart.BackColor = System.Drawing.SystemColors.Window;
            this.DTStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DTStart.Location = new System.Drawing.Point(12, 12);
            this.DTStart.Name = "DTStart";
            this.DTStart.ReadOnly = true;
            this.DTStart.Size = new System.Drawing.Size(510, 20);
            this.DTStart.TabIndex = 0;
            // 
            // DTEnd
            // 
            this.DTEnd.BackColor = System.Drawing.SystemColors.Window;
            this.DTEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DTEnd.Location = new System.Drawing.Point(12, 38);
            this.DTEnd.Name = "DTEnd";
            this.DTEnd.ReadOnly = true;
            this.DTEnd.Size = new System.Drawing.Size(510, 20);
            this.DTEnd.TabIndex = 1;
            // 
            // MeetingLocation
            // 
            this.MeetingLocation.BackColor = System.Drawing.SystemColors.Window;
            this.MeetingLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MeetingLocation.Location = new System.Drawing.Point(12, 64);
            this.MeetingLocation.Name = "MeetingLocation";
            this.MeetingLocation.ReadOnly = true;
            this.MeetingLocation.Size = new System.Drawing.Size(510, 20);
            this.MeetingLocation.TabIndex = 2;
            // 
            // Summary
            // 
            this.Summary.BackColor = System.Drawing.SystemColors.Window;
            this.Summary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Summary.Location = new System.Drawing.Point(12, 90);
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Size = new System.Drawing.Size(510, 20);
            this.Summary.TabIndex = 3;
            // 
            // Description
            // 
            this.Description.BackColor = System.Drawing.SystemColors.Window;
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Description.Location = new System.Drawing.Point(12, 116);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Size = new System.Drawing.Size(510, 280);
            this.Description.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 43);
            this.label1.TabIndex = 5;
            this.label1.Text = "To open a file, simply drag it into this window.\r\nWill only display the first eve" +
    "nt of a file containing multiple events.\r\nDate format is DD.MM.YYYY.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.MeetingLocation);
            this.Controls.Add(this.DTEnd);
            this.Controls.Add(this.DTStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tiny ICS Viewer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DTStart;
        private System.Windows.Forms.TextBox DTEnd;
        private System.Windows.Forms.TextBox MeetingLocation;
        private System.Windows.Forms.TextBox Summary;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label label1;
    }
}

