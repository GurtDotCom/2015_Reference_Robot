using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using FTD2XX_NET;
using Ini;

namespace TowerDefender
{
    
    public partial class Form1 : Form
    {
        VideoCaptureDevice videoSource;
        FilterInfoCollection videoDevices;
        private LaserController _controller;
        FrameProcessor processor;
        
        private bool _inSetColor = false;
        private bool _inSetCenter = false;
       
        public Form1()
        {
            InitializeComponent();

            _controller = new LaserController();

            processor = new FrameProcessor(_controller);
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                comboBox1.Items.Add("No capture device on your system");
            }

            var ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                comboBox2.Items.Add(port);
            }
            
            String path = AppDomain.CurrentDomain.BaseDirectory;
            
            IniFile ini = new IniFile(@path + "config.ini");

            GlobalVar.xOffset = Convert.ToInt32(ini.IniReadValue("CONFIG", "XOFFSET"));
            GlobalVar.yOffset = Convert.ToInt32(ini.IniReadValue("CONFIG", "YOFFSET"));
            GlobalVar.comPort = Convert.ToInt32(ini.IniReadValue("CONFIG", "COMPORT"));           
            GlobalVar.targetColor = Color.FromArgb(Convert.ToInt32(ini.IniReadValue("CONFIG", "COLOR")));

            GlobalVar.Red = Convert.ToByte(ini.IniReadValue("CONFIG", "RED"));
            GlobalVar.Blue = Convert.ToByte(ini.IniReadValue("CONFIG", "BLUE"));
            GlobalVar.Green = Convert.ToByte(ini.IniReadValue("CONFIG", "GREEN"));   

            GlobalVar.aggression = Convert.ToInt32(ini.IniReadValue("CONFIG", "AGGRESSION"));
            GlobalVar.xRatio = Convert.ToSingle(ini.IniReadValue("CONFIG", "XRATIO"));
            GlobalVar.yRatio = Convert.ToSingle(ini.IniReadValue("CONFIG", "YRATIO"));
            GlobalVar.EnableXAnt = Convert.ToBoolean(ini.IniReadValue("CONFIG", "XANTENABLE"));
            GlobalVar.EnableYAnt = Convert.ToBoolean(ini.IniReadValue("CONFIG", "YANTENABLE"));



            if (GlobalVar.EnableXAnt)
            {
                AntXCheckBox.Checked = true;
            }
            else
            {
                AntXCheckBox.Checked = false;
            }


            if (GlobalVar.EnableYAnt)
            {
                AntYCheckBox.Checked = true;
            }
            else
            {
                AntYCheckBox.Checked = false;
            }
            trackBar1.Value = GlobalVar.aggression;
            GlobalVar.XAnt = Convert.ToInt32(ini.IniReadValue("CONFIG", "ANTICIPATION"));
            antTrackBar.Value = GlobalVar.XAnt;
            if (comboBox2.Items.Count >= GlobalVar.comPort + 1) { 
                comboBox2.SelectedIndex = GlobalVar.comPort;
        }
            if ((GlobalVar.xOffset > 0) && (GlobalVar.yOffset > 0))
            {
                processor.SetCenter(GlobalVar.xOffset, GlobalVar.yOffset);
              
                
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            _controller.Connect(new SerialPort((string)comboBox2.SelectedItem, 57600));



            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();


        }



        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            var processed = processor.ProcessFrame((Bitmap)eventArgs.Frame.Clone());
           if(GlobalVar.Run) {
            try
            {
                pictureBox1.Invoke((Action)(() =>
                {
                    pictureBox1.Left = 1;
                    pictureBox1.Width = bitmap.Width;
                    pictureBox1.Height = bitmap.Height;
                    pictureBox1.Image = bitmap;

                    pictureBox2.Left = pictureBox1.Left + pictureBox1.Width + 1;
                    pictureBox2.Top = pictureBox1.Top;
                    pictureBox2.Width = bitmap.Width;
                    pictureBox2.Height = bitmap.Height;
                    pictureBox2.Image = processed;

                    Width = pictureBox2.Width + pictureBox2.Left + 2;
                }));
            }
            catch
            {
            }
        }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.SignalToStop();
            }
            String path = AppDomain.CurrentDomain.BaseDirectory;

            IniFile ini = new IniFile(@path + "config.ini");
          
            ini.IniWriteValue("CONFIG", "XOFFSET", Convert.ToString(GlobalVar.xOffset));
            ini.IniWriteValue("CONFIG", "YOFFSET", Convert.ToString(GlobalVar.yOffset));
            ini.IniWriteValue("CONFIG", "COMPORT", Convert.ToString(GlobalVar.comPort));
            ini.IniWriteValue("CONFIG", "COLOR", GlobalVar.targetColor.ToArgb().ToString());
            ini.IniWriteValue("CONFIG", "RED", Convert.ToString(GlobalVar.Red));
            ini.IniWriteValue("CONFIG", "BLUE", Convert.ToString(GlobalVar.Blue));
            ini.IniWriteValue("CONFIG", "GREEN", Convert.ToString(GlobalVar.Green));
            ini.IniWriteValue("CONFIG", "AGGRESSION", Convert.ToString(GlobalVar.aggression));
            ini.IniWriteValue("CONFIG", "ANTICIPATION", Convert.ToString(GlobalVar.XAnt));
            ini.IniWriteValue("CONFIG", "XRATIO", Convert.ToString(GlobalVar.xRatio));
            ini.IniWriteValue("CONFIG", "YRATIO", Convert.ToString(GlobalVar.yRatio));
            ini.IniWriteValue("CONFIG", "XANTENABLE", Convert.ToString(GlobalVar.EnableXAnt));
            ini.IniWriteValue("CONFIG", "YANTENABLE", Convert.ToString(GlobalVar.EnableYAnt));

        }

        private void btnSetColor_Click(object sender, EventArgs e)
        {
            //_inSetColor = true;
          //  btnSetColor.BackColor = SystemColors.ControlDarkDark;
            _inSetCenter = true;
        }
        private void OnPictureBoxClick(object sender, EventArgs e)
        {
            var em = e as MouseEventArgs;
            if (_inSetColor)
            {
                var color = (pictureBox1.Image as Bitmap).GetPixel(em.X, em.Y);
                GlobalVar.Red = color.R;
                GlobalVar.Blue = color.B;
                GlobalVar.Green = color.G;
                processor.SetColor(color);
                _inSetColor = false;
            }
            if (_inSetCenter)
            {
                processor.SetCenter(em.X, em.Y);
                _inSetCenter = false;
                GlobalVar.xOffset = em.X;
                GlobalVar.yOffset = em.Y;
            }
            else
            {
               AForge.Point center = new AForge.Point(240, 160);
               AForge.Point clicked = new AForge.Point(em.X, em.Y); 

               var delta = clicked - center;
              _controller.Update(delta.X, delta.Y, true);
            }
        }

        private void OnSettingsClick(object sender, EventArgs e)
        {
            if ((videoSource != null) && (videoSource is VideoCaptureDevice))
            {
                try
                {
                    ((VideoCaptureDevice)videoSource).DisplayPropertyPage(this.Handle);
                }
                catch (NotSupportedException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void panFineTrackBar_Scroll(object sender, EventArgs e)
        {
            
        }

        private void tiltFineTrackBar_Scroll(object sender, EventArgs e)
        {
            
        }

        private void panCoarseTrackBar_Scroll(object sender, EventArgs e)
        {
           
        }

        private void tiltCoarseTrackBar_Scroll(object sender, EventArgs e)
        {
            

        }

        private void thresholdTrackBar_Scroll(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                label7.Text = Convert.ToString(GlobalVar.xRatio);
                label8.Text = Convert.ToString(GlobalVar.objectX);
                label9.Text = Convert.ToString(GlobalVar.objectY);
                label1.Text = Convert.ToString(GlobalVar.Xdelta);
                label2.Text = Convert.ToString(GlobalVar.Ydelta);
                RedLabel.Text = Convert.ToString(GlobalVar.Red);
                BlueLabel.Text = Convert.ToString(GlobalVar.Blue);
                GreenLabel.Text = Convert.ToString(GlobalVar.Green);


                if (runEnableCheckBox.Checked) { GlobalVar.Run = true; } else { GlobalVar.Run = false; }

                if (moveEnableCheckBox.Checked) { GlobalVar.EnableMovement = true; } else { GlobalVar.EnableMovement = false; }


                if (AntXCheckBox.Checked)
                {
                    GlobalVar.EnableXAnt = true;
                }
                else
                {
                    GlobalVar.EnableXAnt = false;
                }
                if (AntYCheckBox.Checked)
                {
                    GlobalVar.EnableYAnt = true;
                }
                else
                {
                    GlobalVar.EnableYAnt = false;
                }

                if (GlobalVar.nothingTimerEnabled)
                {
                    NothingTimer.Enabled = true;
                }
                else
                {
                    NothingTimer.Enabled = false;
                }
            
        }

        private void calibrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVar.comPort = comboBox2.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button3.BackColor = SystemColors.ControlDarkDark;
            _inSetColor = true;
        }
        public void ChangeButtonColor()
        {
            this.button3.BackColor = SystemColors.Control;
            this.btnSetColor.BackColor = SystemColors.Control;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            GlobalVar.aggression = trackBar1.Value;
        }

        private void NothingTimer_Tick(object sender, EventArgs e)
        {
            GlobalVar.nothingTime++;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void antTrackBar_Scroll(object sender, EventArgs e)
        {
            GlobalVar.XAnt = antTrackBar.Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!GlobalVar.calibrationMode)
            {
                GlobalVar.calibrationMode = true;
                GlobalVar.calibrationMoveComplete = false;
            }
            else
            {
                GlobalVar.calibrationMode = false;
                GlobalVar.calibrationMoveComplete = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Red < 255) { GlobalVar.Red++; }
        }

        private void RedDownButton_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Red > 0) { GlobalVar.Red--; }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (GlobalVar.Green > 0) { GlobalVar.Green--; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Green < 255 ) { GlobalVar.Green++; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Blue > 0) { GlobalVar.Blue--; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (GlobalVar.Blue < 255) { GlobalVar.Blue++; }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            _controller.SlowZeroize();
            
        }

    }
}
public class GlobalVar
{
   // public static bool calibrateMode = true;
   // public static bool movedCal = false;
   // public static float panStep = 1;
   // public static float tiltStep = 1;
    public static float Xdelta;
    public static float Ydelta;
    public static int xOffset;
    public static int yOffset;
    public static int comPort;
    public static Color targetColor;
    public static byte Red;
    public static byte Blue;
    public static byte Green;
    public static int aggression;
    public static int nothingTime = 0;
    public static bool nothingTimerEnabled = false;
    public static int XAnt;
    public static int YAnt;
    public static float xRatio;
    public static float yRatio;
    public static bool calibrationMode = false;
    public static bool calibrationMoveComplete = false;
    public static float objectX;
    public static float objectY;
    public static bool EnableXAnt = true;
    public static bool EnableYAnt = true;
    public static bool EnableMovement = true;
    public static bool Run = true;
}
