using System;
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

        public static void BytesSentAndReceived(RichTextBox resultBox)
        {
            resultBox.Clear();
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                resultBox.Text += "Failed\n";
                return;
            }

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in interfaces)
            {
                resultBox.Text += ni.Description + '\n';
                resultBox.Text += "    Bytes Sent: {0}" + ni.GetIPv4Statistics().BytesSent + '\n';
                resultBox.Text += "    Bytes Received: {0}" + ni.GetIPv4Statistics().BytesReceived + '\n';
            }
        }
    }
}
