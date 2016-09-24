namespace mp3converter
{
    partial class StudyEV
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
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btndownload = new System.Windows.Forms.Button();
            this.txturl = new System.Windows.Forms.TextBox();
            this.cboresolution = new System.Windows.Forms.ComboBox();
            this.Resolustion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.makemp3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(408, 28);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(142, 41);
            this.button8.TabIndex = 0;
            this.button8.Text = "convert WAV";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "url:";
            // 
            // btndownload
            // 
            this.btndownload.Location = new System.Drawing.Point(408, 247);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(108, 30);
            this.btndownload.TabIndex = 2;
            this.btndownload.Text = "Download";
            this.btndownload.UseVisualStyleBackColor = true;
            this.btndownload.Click += new System.EventHandler(this.btndownload_Click);
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(51, 107);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(337, 28);
            this.txturl.TabIndex = 3;
            // 
            // cboresolution
            // 
            this.cboresolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboresolution.FormattingEnabled = true;
            this.cboresolution.Items.AddRange(new object[] {
            "360",
            "480\t",
            "720"});
            this.cboresolution.Location = new System.Drawing.Point(120, 150);
            this.cboresolution.Name = "cboresolution";
            this.cboresolution.Size = new System.Drawing.Size(268, 26);
            this.cboresolution.TabIndex = 4;
            // 
            // Resolustion
            // 
            this.Resolustion.AutoSize = true;
            this.Resolustion.Location = new System.Drawing.Point(12, 154);
            this.Resolustion.Name = "Resolustion";
            this.Resolustion.Size = new System.Drawing.Size(108, 18);
            this.Resolustion.TabIndex = 5;
            this.Resolustion.Text = "Resolustion:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 198);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(501, 38);
            this.progressBar.TabIndex = 6;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(522, 207);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(32, 18);
            this.lblPercentage.TabIndex = 7;
            this.lblPercentage.Text = "0%";
            // 
            // makemp3
            // 
            this.makemp3.Location = new System.Drawing.Point(211, 28);
            this.makemp3.Name = "makemp3";
            this.makemp3.Size = new System.Drawing.Size(158, 41);
            this.makemp3.TabIndex = 8;
            this.makemp3.Text = "MakeMp3";
            this.makemp3.UseVisualStyleBackColor = true;
            this.makemp3.Click += new System.EventHandler(this.makemp3_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(25, 28);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(158, 41);
            this.button9.TabIndex = 9;
            this.button9.Text = "mp4toFlv";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // StudyEV
            // 
            this.ClientSize = new System.Drawing.Size(585, 314);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.makemp3);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.Resolustion);
            this.Controls.Add(this.cboresolution);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.btndownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Name = "StudyEV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button save1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.SaveFileDialog save;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndownload;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.ComboBox cboresolution;
        private System.Windows.Forms.Label Resolustion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Button makemp3;
        private System.Windows.Forms.Button button9;
    }
}

