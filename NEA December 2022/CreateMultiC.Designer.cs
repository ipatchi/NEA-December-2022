namespace NEA_December_2022
{
    partial class CreateMultiC
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
            this.InputQ = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CorrectOpt = new System.Windows.Forms.RichTextBox();
            this.Opt2 = new System.Windows.Forms.RichTextBox();
            this.Opt3 = new System.Windows.Forms.RichTextBox();
            this.Opt4 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.MarksInp = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MarksInp)).BeginInit();
            this.SuspendLayout();
            // 
            // InputQ
            // 
            this.InputQ.Location = new System.Drawing.Point(201, 12);
            this.InputQ.Name = "InputQ";
            this.InputQ.Size = new System.Drawing.Size(381, 156);
            this.InputQ.TabIndex = 3;
            this.InputQ.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CorrectOpt
            // 
            this.CorrectOpt.BackColor = System.Drawing.Color.IndianRed;
            this.CorrectOpt.Location = new System.Drawing.Point(160, 191);
            this.CorrectOpt.Name = "CorrectOpt";
            this.CorrectOpt.Size = new System.Drawing.Size(225, 119);
            this.CorrectOpt.TabIndex = 5;
            this.CorrectOpt.Text = "";
            // 
            // Opt2
            // 
            this.Opt2.BackColor = System.Drawing.Color.DodgerBlue;
            this.Opt2.Location = new System.Drawing.Point(391, 191);
            this.Opt2.Name = "Opt2";
            this.Opt2.Size = new System.Drawing.Size(225, 119);
            this.Opt2.TabIndex = 6;
            this.Opt2.Text = "";
            // 
            // Opt3
            // 
            this.Opt3.BackColor = System.Drawing.Color.OliveDrab;
            this.Opt3.Location = new System.Drawing.Point(160, 330);
            this.Opt3.Name = "Opt3";
            this.Opt3.Size = new System.Drawing.Size(225, 119);
            this.Opt3.TabIndex = 7;
            this.Opt3.Text = "";
            // 
            // Opt4
            // 
            this.Opt4.BackColor = System.Drawing.Color.Gold;
            this.Opt4.Location = new System.Drawing.Point(391, 330);
            this.Opt4.Name = "Opt4";
            this.Opt4.Size = new System.Drawing.Size(225, 119);
            this.Opt4.TabIndex = 8;
            this.Opt4.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Put Correct Answer Here:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Put Other Options Here:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Put Other Options Here:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Put Other Options Here:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 455);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Create Question";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MarksInp
            // 
            this.MarksInp.Location = new System.Drawing.Point(666, 135);
            this.MarksInp.Name = "MarksInp";
            this.MarksInp.Size = new System.Drawing.Size(120, 23);
            this.MarksInp.TabIndex = 14;
            // 
            // CreateMultiC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.MarksInp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Opt4);
            this.Controls.Add(this.Opt3);
            this.Controls.Add(this.Opt2);
            this.Controls.Add(this.CorrectOpt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputQ);
            this.Name = "CreateMultiC";
            this.Text = "CreateMultiC";
            ((System.ComponentModel.ISupportInitialize)(this.MarksInp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox InputQ;
        private Button button1;
        private RichTextBox CorrectOpt;
        private RichTextBox Opt2;
        private RichTextBox Opt3;
        private RichTextBox Opt4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button2;
        private NumericUpDown MarksInp;
    }
}