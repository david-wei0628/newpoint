using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public FilterInfoCollection Webcams = null;
        public VideoCaptureDevice Cam = null;

        private FilterInfoCollection videoDevicesList;

        public Form1()
        {
            InitializeComponent();

            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDevicesList)
            {
                //MessageBox.Show(videoDevice.Name);
                //if (videoDevice.Name != "")
                //{ comboBox1.Items.Add(videoDevice.Name); }

                comboBox1.Items.Add(videoDevice.Name);
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Start" || button1.Text == "Open")
            {
                button1.Text = "Stop";
                Cam = new VideoCaptureDevice(videoDevicesList[comboBox1.SelectedIndex].MonikerString);
                Cam.NewFrame += new NewFrameEventHandler(video_NewFrame);
                Cam.Start();   // WebCam starts capturing images.
                comboBox1.Enabled = false;
            }
            else if(button1.Text == "Stop")
            {
                button1.Text = "Start";
                Cam.Stop();  // WebCam stops capturing images.
                comboBox1.Enabled = true;
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //if (Webcams.Count > 0)  // The quantity of WebCam must be more than 0.
            //{
            //    button1.Enabled = true;
            //    Cam = new VideoCaptureDevice(Webcams[0].MonikerString);
            //    Cam.NewFrame += new NewFrameEventHandler(Cam_NewFrame1);
            //}
            //else
            //{
            //    button1.Enabled = false;
            //    MessageBox.Show("No video input device is connected.");
            //}
        }

        private void Cam_NewFrame1(object sender, NewFrameEventArgs eventArgs)
        {
            //throw new NotImplementedException();
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Cam != null)
            {
                if (Cam.IsRunning)  // When Form1 closes itself, WebCam must stop, too.
                {
                    Cam.Stop();   // WebCam stops capturing images.
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cam.Stop();
            this.Close();
        }
    }
}
