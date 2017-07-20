namespace FftGuitarTuner
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.closeButton = new System.Windows.Forms.Button();
            this.listenButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.hzLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noteNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dywaradio = new System.Windows.Forms.RadioButton();
            this.fftradio = new System.Windows.Forms.RadioButton();
            this.frequenciesScale1 = new FftGuitarTuner.FrequenciesScale(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(107, 308);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "&Close app";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // listenButton
            // 
            this.listenButton.Enabled = false;
            this.listenButton.Location = new System.Drawing.Point(107, 12);
            this.listenButton.Name = "listenButton";
            this.listenButton.Size = new System.Drawing.Size(75, 23);
            this.listenButton.TabIndex = 1;
            this.listenButton.Text = "&Listen...";
            this.listenButton.UseVisualStyleBackColor = true;
            this.listenButton.Click += new System.EventHandler(this.listenButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(107, 42);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "&Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(107, 137);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.ReadOnly = true;
            this.frequencyTextBox.Size = new System.Drawing.Size(54, 20);
            this.frequencyTextBox.TabIndex = 3;
            this.frequencyTextBox.TabStop = false;
            this.frequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hzLabel
            // 
            this.hzLabel.AutoSize = true;
            this.hzLabel.Location = new System.Drawing.Point(167, 140);
            this.hzLabel.Name = "hzLabel";
            this.hzLabel.Size = new System.Drawing.Size(18, 13);
            this.hzLabel.TabIndex = 4;
            this.hzLabel.Text = "hz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "closest note at";
            // 
            // closeFrequencyTextBox
            // 
            this.closeFrequencyTextBox.Location = new System.Drawing.Point(107, 180);
            this.closeFrequencyTextBox.Name = "closeFrequencyTextBox";
            this.closeFrequencyTextBox.ReadOnly = true;
            this.closeFrequencyTextBox.Size = new System.Drawing.Size(54, 20);
            this.closeFrequencyTextBox.TabIndex = 3;
            this.closeFrequencyTextBox.TabStop = false;
            this.closeFrequencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "hz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "is";
            // 
            // noteNameTextBox
            // 
            this.noteNameTextBox.Location = new System.Drawing.Point(139, 206);
            this.noteNameTextBox.Name = "noteNameTextBox";
            this.noteNameTextBox.ReadOnly = true;
            this.noteNameTextBox.Size = new System.Drawing.Size(33, 20);
            this.noteNameTextBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Start &Feeder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Feeder Status";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(197, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Stop Feeder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(195, 308);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Call &Monitor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dywaradio);
            this.groupBox1.Controls.Add(this.fftradio);
            this.groupBox1.Location = new System.Drawing.Point(107, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 70);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // dywaradio
            // 
            this.dywaradio.AutoSize = true;
            this.dywaradio.Checked = true;
            this.dywaradio.Location = new System.Drawing.Point(6, 42);
            this.dywaradio.Name = "dywaradio";
            this.dywaradio.Size = new System.Drawing.Size(148, 17);
            this.dywaradio.TabIndex = 1;
            this.dywaradio.TabStop = true;
            this.dywaradio.Text = "Use wavelet pitchtracking";
            this.dywaradio.UseVisualStyleBackColor = true;
            this.dywaradio.CheckedChanged += new System.EventHandler(this.dywaradio_CheckedChanged);
            // 
            // fftradio
            // 
            this.fftradio.AutoSize = true;
            this.fftradio.Location = new System.Drawing.Point(6, 19);
            this.fftradio.Name = "fftradio";
            this.fftradio.Size = new System.Drawing.Size(130, 17);
            this.fftradio.TabIndex = 0;
            this.fftradio.Text = "Use FFT pitchtracking";
            this.fftradio.UseVisualStyleBackColor = true;
            this.fftradio.CheckedChanged += new System.EventHandler(this.fftradio_CheckedChanged);
            // 
            // frequenciesScale1
            // 
            this.frequenciesScale1.BackColor = System.Drawing.Color.White;
            this.frequenciesScale1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frequenciesScale1.Location = new System.Drawing.Point(12, 12);
            this.frequenciesScale1.Name = "frequenciesScale1";
            this.frequenciesScale1.Size = new System.Drawing.Size(67, 319);
            this.frequenciesScale1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noteNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frequenciesScale1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hzLabel);
            this.Controls.Add(this.closeFrequencyTextBox);
            this.Controls.Add(this.frequencyTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.listenButton);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Guitar to Gamepad Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button listenButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.Label hzLabel;
        private FrequenciesScale frequenciesScale1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox closeFrequencyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox noteNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton dywaradio;
        private System.Windows.Forms.RadioButton fftradio;
    }
}

