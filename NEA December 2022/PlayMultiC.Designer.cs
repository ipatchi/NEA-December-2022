namespace NEA_December_2022
{
    partial class PlayMultiC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayMultiC));
            this.Opt4 = new System.Windows.Forms.RichTextBox();
            this.Opt3 = new System.Windows.Forms.RichTextBox();
            this.Opt2 = new System.Windows.Forms.RichTextBox();
            this.Opt1 = new System.Windows.Forms.RichTextBox();
            this.InputQ = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Opt4
            // 
            this.Opt4.BackColor = System.Drawing.Color.Gold;
            this.Opt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Opt4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Opt4.Location = new System.Drawing.Point(403, 332);
            this.Opt4.Name = "Opt4";
            this.Opt4.ReadOnly = true;
            this.Opt4.Size = new System.Drawing.Size(225, 119);
            this.Opt4.TabIndex = 18;
            this.Opt4.Text = "";
            this.Opt4.Click += new System.EventHandler(this.Opt4_Click);
            // 
            // Opt3
            // 
            this.Opt3.BackColor = System.Drawing.Color.OliveDrab;
            this.Opt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Opt3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Opt3.Location = new System.Drawing.Point(172, 332);
            this.Opt3.Name = "Opt3";
            this.Opt3.ReadOnly = true;
            this.Opt3.Size = new System.Drawing.Size(225, 119);
            this.Opt3.TabIndex = 17;
            this.Opt3.Text = "";
            this.Opt3.Click += new System.EventHandler(this.Opt3_Click);
            // 
            // Opt2
            // 
            this.Opt2.BackColor = System.Drawing.Color.DodgerBlue;
            this.Opt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Opt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Opt2.Location = new System.Drawing.Point(403, 193);
            this.Opt2.Name = "Opt2";
            this.Opt2.ReadOnly = true;
            this.Opt2.Size = new System.Drawing.Size(225, 119);
            this.Opt2.TabIndex = 16;
            this.Opt2.Text = "";
            this.Opt2.Click += new System.EventHandler(this.Opt2_Click);
            // 
            // Opt1
            // 
            this.Opt1.BackColor = System.Drawing.Color.IndianRed;
            this.Opt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Opt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Opt1.Location = new System.Drawing.Point(172, 193);
            this.Opt1.Name = "Opt1";
            this.Opt1.ReadOnly = true;
            this.Opt1.Size = new System.Drawing.Size(225, 119);
            this.Opt1.TabIndex = 15;
            this.Opt1.Text = "";
            this.Opt1.Click += new System.EventHandler(this.Opt1_Click);
            // 
            // InputQ
            // 
            this.InputQ.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InputQ.Location = new System.Drawing.Point(213, 14);
            this.InputQ.Name = "InputQ";
            this.InputQ.ReadOnly = true;
            this.InputQ.Size = new System.Drawing.Size(381, 156);
            this.InputQ.TabIndex = 14;
            this.InputQ.Text = "";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(728, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PlayMultiC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Opt4);
            this.Controls.Add(this.Opt3);
            this.Controls.Add(this.Opt2);
            this.Controls.Add(this.Opt1);
            this.Controls.Add(this.InputQ);
            this.Name = "PlayMultiC";
            this.Text = "PlayMultiC";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox Opt4;
        private RichTextBox Opt3;
        private RichTextBox Opt2;
        private RichTextBox Opt1;
        private RichTextBox InputQ;
        private Button button1;
    }
}