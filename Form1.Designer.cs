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
            this.DTStart = new System.Windows.Forms.RichTextBox();
            this.DTEnd = new System.Windows.Forms.RichTextBox();
            this.Location = new System.Windows.Forms.RichTextBox();
            this.Summary = new System.Windows.Forms.RichTextBox();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTStart
            // 
            this.DTStart.Location = new System.Drawing.Point(12, 12);
            this.DTStart.Name = "DTStart";
            this.DTStart.Size = new System.Drawing.Size(510, 32);
            this.DTStart.TabIndex = 0;
            this.DTStart.Text = "";
            // 
            // DTEnd
            // 
            this.DTEnd.Location = new System.Drawing.Point(12, 50);
            this.DTEnd.Name = "DTEnd";
            this.DTEnd.Size = new System.Drawing.Size(510, 32);
            this.DTEnd.TabIndex = 1;
            this.DTEnd.Text = "";
            // 
            // Location
            // 
            this.Location.Location = new System.Drawing.Point(12, 88);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(510, 32);
            this.Location.TabIndex = 2;
            this.Location.Text = "";
            // 
            // Summary
            // 
            this.Summary.Location = new System.Drawing.Point(12, 126);
            this.Summary.Name = "Summary";
            this.Summary.Size = new System.Drawing.Size(510, 32);
            this.Summary.TabIndex = 3;
            this.Summary.Text = "";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(12, 164);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(510, 232);
            this.Description.TabIndex = 4;
            this.Description.Text = "";
            this.Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(510, 53);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.DTEnd);
            this.Controls.Add(this.DTStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tiny ICS Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox DTStart;
        private System.Windows.Forms.RichTextBox DTEnd;
        private System.Windows.Forms.RichTextBox Location;
        private System.Windows.Forms.RichTextBox Summary;
        private System.Windows.Forms.RichTextBox Description;
        private System.Windows.Forms.Label label1;
    }
}

