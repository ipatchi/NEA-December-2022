namespace NEA_December_2022
{
    partial class PlayQA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayQA));
            this.label1 = new System.Windows.Forms.Label();
            this.OutputQ = new System.Windows.Forms.RichTextBox();
            this.InputA = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RealAnswerBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Answer:";
            // 
            // OutputQ
            // 
            this.OutputQ.Location = new System.Drawing.Point(12, 12);
            this.OutputQ.Name = "OutputQ";
            this.OutputQ.ReadOnly = true;
            this.OutputQ.Size = new System.Drawing.Size(381, 156);
            this.OutputQ.TabIndex = 3;
            this.OutputQ.Text = "";
            // 
            // InputA
            // 
            this.InputA.Location = new System.Drawing.Point(12, 234);
            this.InputA.Name = "InputA";
            this.InputA.Size = new System.Drawing.Size(381, 156);
            this.InputA.TabIndex = 4;
            this.InputA.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RealAnswerBox
            // 
            this.RealAnswerBox.Location = new System.Drawing.Point(407, 234);
            this.RealAnswerBox.Name = "RealAnswerBox";
            this.RealAnswerBox.ReadOnly = true;
            this.RealAnswerBox.Size = new System.Drawing.Size(381, 156);
            this.RealAnswerBox.TabIndex = 6;
            this.RealAnswerBox.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Move On";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(728, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlayQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.RealAnswerBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputA);
            this.Controls.Add(this.OutputQ);
            this.Controls.Add(this.label1);
            this.Name = "PlayQA";
            this.Text = "PlayQA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private RichTextBox OutputQ;
        private RichTextBox InputA;
        private Button button1;
        private RichTextBox RealAnswerBox;
        private Button button2;
        private Button button3;
    }
}