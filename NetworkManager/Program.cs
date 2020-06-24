﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace NetworkManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void BytesSentAndReceived(RichTextBox resultBox, long[] startPoint)
        {
            resultBox.Clear();
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                resultBox.Text += "Failed\n";
                return;
            }

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            for(int x=0, y=0; x < interfaces.Length; x++, y+=2)
            {
                if (interfaces[x].GetIPv4Statistics().BytesSent != 0 && interfaces[x].GetIPv4Statistics().BytesReceived != 0)
                {
                    resultBox.Text += interfaces[x].Name + '\n';
                    resultBox.Text += "    Mbs Sent: " + (((float)interfaces[x].GetIPv4Statistics().BytesSent - startPoint[y]) / 1000000) + '\n';
                    resultBox.Text += "    Mbs Received: " + (((float)interfaces[x].GetIPv4Statistics().BytesReceived - startPoint[y+1]) / 1000000 ) + "\n\n";
                }
            }
        }
    }
}
