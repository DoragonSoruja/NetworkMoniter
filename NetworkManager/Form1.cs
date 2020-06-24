using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            startAndStop.Text = "Start";
            resultBox.Clear();
            resultBox.Text = "Stop_Click";
            startAndStop.Click -= new EventHandler(Stop_Click); 
            startAndStop.Click += new EventHandler(Start_Click);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            startAndStop.Text = "Stop";

            startAndStop.Refresh();
            startAndStop.Click -= new EventHandler(Start_Click);
            startAndStop.Click += new EventHandler(Stop_Click);

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            long[] buffers = new long[interfaces.Length * 2];
            int y = 0;
            foreach(NetworkInterface x in interfaces)
            {
                buffers[y] = x.GetIPv4Statistics().BytesSent;
                buffers[y + 1] = x.GetIPv4Statistics().BytesReceived;
                y += 2;
            }
            for (int x = 0; x < 10; x++)
            {
                Program.BytesSentAndReceived(resultBox, buffers);
                resultBox.Refresh();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
