namespace TowerDefender
{
    partial class Form1
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.NothingTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.antTrackBar = new System.Windows.Forms.TrackBar();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.AntXCheckBox = new System.Windows.Forms.CheckBox();
            this.AntYCheckBox = new System.Windows.Forms.CheckBox();
            this.moveEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.runEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RedDownButton = new System.Windows.Forms.Button();
            this.RedUpButton = new System.Windows.Forms.Button();
            this.RedLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(1, 113);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 138);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.OnPictureBoxClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 7);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // btnSetColor
            // 
            this.btnSetColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSetColor.Location = new System.Drawing.Point(22, 32);
            this.btnSetColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(81, 19);
            this.btnSetColor.TabIndex = 3;
            this.btnSetColor.Text = "Set Center";
            this.btnSetColor.UseVisualStyleBackColor = false;
            this.btnSetColor.Click += new System.EventHandler(this.btnSetColor_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(182, 113);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(177, 138);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(346, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 19);
            this.button2.TabIndex = 5;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnSettingsClick);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(175, 7);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(92, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pan Delta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tilt Delta:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(107, 32);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 19);
            this.button3.TabIndex = 12;
            this.button3.Text = "Set Color";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(283, 31);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(123, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.Value = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Aggressiveness:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NothingTimer
            // 
            this.NothingTimer.Tick += new System.EventHandler(this.NothingTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(500, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Anticipation:";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // antTrackBar
            // 
            this.antTrackBar.Location = new System.Drawing.Point(571, 32);
            this.antTrackBar.Maximum = 20;
            this.antTrackBar.Minimum = 1;
            this.antTrackBar.Name = "antTrackBar";
            this.antTrackBar.Size = new System.Drawing.Size(104, 45);
            this.antTrackBar.TabIndex = 16;
            this.antTrackBar.Value = 12;
            this.antTrackBar.Visible = false;
            this.antTrackBar.Scroll += new System.EventHandler(this.antTrackBar_Scroll);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(22, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Calibrate";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(552, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "label9";
            // 
            // AntXCheckBox
            // 
            this.AntXCheckBox.AutoSize = true;
            this.AntXCheckBox.Location = new System.Drawing.Point(110, 57);
            this.AntXCheckBox.Name = "AntXCheckBox";
            this.AntXCheckBox.Size = new System.Drawing.Size(95, 17);
            this.AntXCheckBox.TabIndex = 21;
            this.AntXCheckBox.Text = "Anticipate Pan";
            this.AntXCheckBox.UseVisualStyleBackColor = true;
            // 
            // AntYCheckBox
            // 
            this.AntYCheckBox.AutoSize = true;
            this.AntYCheckBox.Location = new System.Drawing.Point(229, 56);
            this.AntYCheckBox.Name = "AntYCheckBox";
            this.AntYCheckBox.Size = new System.Drawing.Size(90, 17);
            this.AntYCheckBox.TabIndex = 22;
            this.AntYCheckBox.Text = "Anticipate Tilt";
            this.AntYCheckBox.UseVisualStyleBackColor = true;
            // 
            // moveEnableCheckBox
            // 
            this.moveEnableCheckBox.AutoSize = true;
            this.moveEnableCheckBox.Location = new System.Drawing.Point(346, 58);
            this.moveEnableCheckBox.Name = "moveEnableCheckBox";
            this.moveEnableCheckBox.Size = new System.Drawing.Size(112, 17);
            this.moveEnableCheckBox.TabIndex = 23;
            this.moveEnableCheckBox.Text = "Enable Movement";
            this.moveEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // runEnableCheckBox
            // 
            this.runEnableCheckBox.AutoSize = true;
            this.runEnableCheckBox.Location = new System.Drawing.Point(463, 58);
            this.runEnableCheckBox.Name = "runEnableCheckBox";
            this.runEnableCheckBox.Size = new System.Drawing.Size(46, 17);
            this.runEnableCheckBox.TabIndex = 24;
            this.runEnableCheckBox.Text = "Run";
            this.runEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Red:";
            // 
            // RedDownButton
            // 
            this.RedDownButton.Location = new System.Drawing.Point(39, 88);
            this.RedDownButton.Name = "RedDownButton";
            this.RedDownButton.Size = new System.Drawing.Size(29, 20);
            this.RedDownButton.TabIndex = 27;
            this.RedDownButton.Text = "<";
            this.RedDownButton.UseVisualStyleBackColor = true;
            this.RedDownButton.Click += new System.EventHandler(this.RedDownButton_Click);
            // 
            // RedUpButton
            // 
            this.RedUpButton.Location = new System.Drawing.Point(95, 88);
            this.RedUpButton.Name = "RedUpButton";
            this.RedUpButton.Size = new System.Drawing.Size(29, 19);
            this.RedUpButton.TabIndex = 28;
            this.RedUpButton.Text = ">";
            this.RedUpButton.UseVisualStyleBackColor = true;
            this.RedUpButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(69, 92);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(13, 13);
            this.RedLabel.TabIndex = 29;
            this.RedLabel.Text = "0";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(226, 93);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(13, 13);
            this.GreenLabel.TabIndex = 33;
            this.GreenLabel.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(252, 89);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(29, 19);
            this.button5.TabIndex = 32;
            this.button5.Text = ">";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(196, 89);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(29, 20);
            this.button6.TabIndex = 31;
            this.button6.Text = "<";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(160, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Green:";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(390, 94);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(13, 13);
            this.BlueLabel.TabIndex = 37;
            this.BlueLabel.Text = "0";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(416, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(29, 19);
            this.button7.TabIndex = 36;
            this.button7.Text = ">";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(360, 90);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(29, 20);
            this.button8.TabIndex = 35;
            this.button8.Text = "<";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(333, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Blue:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(626, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 20);
            this.label11.TabIndex = 38;
            this.label11.Text = "Warning: This software is not Y2K compliant!";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(697, 38);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(106, 22);
            this.button9.TabIndex = 39;
            this.button9.Text = "Calibrate Motors";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 476);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.RedUpButton);
            this.Controls.Add(this.RedDownButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.runEnableCheckBox);
            this.Controls.Add(this.moveEnableCheckBox);
            this.Controls.Add(this.AntYCheckBox);
            this.Controls.Add(this.AntXCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.antTrackBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetColor);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlueBalls";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer NothingTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar antTrackBar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox AntXCheckBox;
        private System.Windows.Forms.CheckBox AntYCheckBox;
        private System.Windows.Forms.CheckBox moveEnableCheckBox;
        private System.Windows.Forms.CheckBox runEnableCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button RedDownButton;
        private System.Windows.Forms.Button RedUpButton;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button9;


    }
}

