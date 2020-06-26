using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkManager
{
    public partial class Form1 : Form
    {
        bool clear = true;
        long[] buffers = new long[0];
        Thread reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void Clear(object sender, EventArgs e)
        {
            resultBox.Clear();
            clear = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            startAndStop.Text = "Start";
            startAndStop.Click -= new EventHandler(Stop_Click); 
            startAndStop.Click += new EventHandler(Start_Click);
            reader.Abort();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            startAndStop.Text = "Stop";
                
            startAndStop.Refresh();
            startAndStop.Click -= new EventHandler(Start_Click);
            startAndStop.Click += new EventHandler(Stop_Click);

            resultBox.Clear();

            reader = new Thread(new ThreadStart(ByteReader));
            reader.Start();
        }

        private void ByteReader()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            if (clear)
            {
                buffers = new long[interfaces.Length * 2];
                int y = 0;
                foreach (NetworkInterface x in interfaces)
                {
                    buffers[y] = x.GetIPv4Statistics().BytesSent;
                    buffers[y + 1] = x.GetIPv4Statistics().BytesReceived;
                    y += 2;
                }
                clear = !clear;
            }
            do
            {
                BytesSentAndReceived(buffers);
                Thread.Sleep(1000);
            } while (startAndStop.Text == "Stop");
        }

        private delegate void SafeCallDelegate(string text);

        public void SetText(string text)
        {
            if (resultBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetText);
                resultBox.Invoke(d, new object[] { text });
            }
            else
            {
                resultBox.Text = text;
            }
        }

        private void BytesSentAndReceived(long[] startPoint)
        {
            string tempText = "";

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                resultBox.Text += "Failed\n";
                return;
            }

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            for (int x = 0, y = 0; x < interfaces.Length; x++, y += 2)
            {
                if (interfaces[x].GetIPv4Statistics().BytesSent != 0 && interfaces[x].GetIPv4Statistics().BytesReceived != 0)
                {
                    tempText += interfaces[x].Name + '\n';
                    tempText += "    Mbs Sent: " + (interfaces[x].GetIPv4Statistics().BytesSent - startPoint[y]) / (float)1000000 + '\n';
                    tempText += "    Mbs Received: " + (interfaces[x].GetIPv4Statistics().BytesReceived - startPoint[y + 1]) / (float)1000000 + "\n\n";
                    SetText(tempText);
                }
            }
        }
    }
}
