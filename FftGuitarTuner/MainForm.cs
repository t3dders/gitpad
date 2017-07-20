using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SoundCapture;
using Feeder;

using System.Runtime.InteropServices;

namespace FftGuitarTuner
{
    public partial class MainForm : Form
    {
        bool isListenning = false;
        bool isStarted = false;
       
        public bool IsListenning
        {
            get { return isListenning; }
        }

        public bool IsStarted
        {
            get { return isStarted; }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        FrequencyInfoSource frequencyInfoSource;

        private void StopListenning()
        {
            isListenning = false;
            frequencyInfoSource.Stop();
            frequencyInfoSource.FrequencyDetected -= new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
            frequencyInfoSource = null;
        }

        private void StartListenning(SoundCaptureDevice device)
        {
            isListenning = true;
            frequencyInfoSource = new SoundFrequencyInfoSource(device);
            frequencyInfoSource.FrequencyDetected += new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected);
            frequencyInfoSource.Listen();
        }

        void frequencyInfoSource_FrequencyDetected(object sender, FrequencyDetectedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<FrequencyDetectedEventArgs>(frequencyInfoSource_FrequencyDetected), sender, e);
            }
            else
            {
                UpdateFrequecyDisplays(e.Frequency);
            }
        }

        private void UpdateFrequecyDisplays(double frequency)
        {
            if (frequency > 0)
            {
                //frequenciesScale1.SignalDetected = true;
                //frequenciesScale1.CurrentFrequency = frequency;

                double closestFrequency;
                string noteName;
                FindClosestNote(frequency, out closestFrequency, out noteName);
                Feeder.Program.Feed(closestFrequency);

                frequencyTextBox.Enabled = true;
                frequencyTextBox.Text = frequency.ToString("f3");

                //double closestFrequency;
                //string noteName;
                //FindClosestNote(frequency, out closestFrequency, out noteName);
                closeFrequencyTextBox.Enabled = true;
                closeFrequencyTextBox.Text = closestFrequency.ToString("f3");
                noteNameTextBox.Enabled = true;
                noteNameTextBox.Text = noteName;

                textBox1.Text = Feeder.Program.stat;
            }
            else
            {
                frequenciesScale1.SignalDetected = false;

                frequencyTextBox.Enabled = false;
                closeFrequencyTextBox.Enabled = false;
                noteNameTextBox.Enabled = false;
            }

        }

        static string[] NoteNames = {"A", "A#", "B/H", "C", "C#", "D", "D#", "E", "F", "F#",  "G",  "G#" };
        static double ToneStep = Math.Pow(2, 1.0 / 12);

        private void FindClosestNote(double frequency, out double closestFrequency, out string noteName)
        {
            const double AFrequency = 440.0;
            const int ToneIndexOffsetToPositives = 120;

            int toneIndex = (int)Math.Round( Math.Log(frequency / AFrequency, ToneStep) );
            noteName = NoteNames[(ToneIndexOffsetToPositives + toneIndex) % NoteNames.Length];
            closestFrequency = Math.Pow(ToneStep, toneIndex) * AFrequency;
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            SoundCaptureDevice device = null;
            using (SelectDeviceForm form = new SelectDeviceForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    device = form.SelectedDevice;
                }
            }

            if (device != null)
            {
                StartListenning(device);
                UpdateListenStopButtons();
            }
        }

        private void UpdateListenStopButtons()
        {
            listenButton.Enabled = !isListenning;
            stopButton.Enabled = isListenning;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopListenning();
            UpdateListenStopButtons();

            frequenciesScale1.SignalDetected = false;
            frequenciesScale1.CurrentFrequency = 0;

            frequencyTextBox.Enabled = false;
            frequencyTextBox.Text = " ";

            closeFrequencyTextBox.Enabled = false;
            closeFrequencyTextBox.Text = " ";
            noteNameTextBox.Enabled = false;
            noteNameTextBox.Text = " ";

            textBox1.Text = "On!";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsListenning)
            {
                StopListenning();
            }

            if (MonitorCalled)
            {
                monitor.Kill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            Feeder.Program.InitializeFeeder();
            isStarted = true;
            listenButton.Enabled = isStarted;
            button1.Enabled = !isStarted;
            button2.Enabled = isStarted;
            textBox1.Text = Feeder.Program.stat;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isListenning)
            {
                StopListenning();
            }

            isStarted = false;

            stopButton.Enabled = isListenning;
            listenButton.Enabled = isListenning;

            Feeder.Program.joystick.ResetAll();
            Feeder.Program.joystick.RelinquishVJD(1);

            button1.Enabled = !isStarted;
            button2.Enabled = isStarted;

            textBox1.Text = "Off!";

            UpdateFrequecyDisplays(-1);
        }

        bool MonitorCalled = false;
        Process monitor;

        private void button3_Click(object sender, EventArgs e)
        {
            if (MonitorCalled == false)
            {
                monitor = Process.Start("C:/Program Files/vJoy/JoyMonitor.exe");
                MonitorCalled = true;
                button3.Text = "Close Monitor";
            }
            else if (monitor.HasExited == true) 
            {
                MonitorCalled = false;
                MessageBox.Show("Should've closed by pressing 'Close Monitor' button, dude!");
                button3.Text = "Call Monitor";
            }
            else
            {
                monitor.Kill();
                MonitorCalled = false;
                button3.Text = "Call Monitor";
            }
        }

        private void fftradio_CheckedChanged(object sender, EventArgs e)
        {
            Wavelet.Pitchtracker.counter = 0;
        }

        private void dywaradio_CheckedChanged(object sender, EventArgs e)
        {
            Wavelet.Pitchtracker.counter = 1;
        }
    }
}
