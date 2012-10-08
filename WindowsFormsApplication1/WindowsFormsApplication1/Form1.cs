using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            InitializeSoundPlayers();

            serialPort1.PortName = "COM5";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            if (serialPort1.IsOpen)
            {
                textBox1.AppendText("is open");
            }
            else
            {
                serialPort1.Open();
            }
            serialPort1.DataReceived += serialPort1_DataReceived;

        }

        List<System.Media.SoundPlayer> sps;

        public void InitializeSoundPlayers()
        {
            sps = new List<System.Media.SoundPlayer>();
            string[] trackLocations = new string[4];
            string dict = @"D:\sound\";
            trackLocations[0] = dict + "0.wav";
            trackLocations[1] = dict + "1.wav";
            trackLocations[2] = dict + "2.wav";
            trackLocations[3] = dict + "3.wav";
            for (int i = 0; i < trackLocations.Length; i++) {
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
                sp.SoundLocation = trackLocations[i];
                sps.Add(sp);
            }
        }

        public void Play()
        {
            string trackLocation = "";
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.SoundLocation = trackLocation;
            sp.Play();
            sp.Stop();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string line = serialPort1.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            //What to do with the received line here          
            string[] signals = line.Split(":".ToCharArray());
            int trackNum = int.Parse(signals[0]);
            if (trackNum < 2 && trackNum >= 1)
            {
                sps[trackNum].Play();
                textBox1.AppendText(line + "\n");
            }
            

            //progressBar1.Value = int.Parse(line);
        }
        public void Listener()
        {
            string str = "";
            System.IO.Ports.SerialPort spListner = new System.IO.Ports.SerialPort();
            spListner.PortName = "COM5";
            spListner.BaudRate = 9600;
            spListner.Open();

            while (spListner.BytesToRead > 0)
            {
                str = spListner.ReadLine();
                textBox1.AppendText(str);
            }
        }
    }
}
