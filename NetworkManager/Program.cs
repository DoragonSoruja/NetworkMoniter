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
            BytesSentAndReceived();
        }

        static void BytesSentAndReceived()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                Console.WriteLine("Failed");
                return;
            }

            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in interfaces)
            {
                Console.WriteLine(ni.Description);
                Console.WriteLine("    Bytes Sent: {0}", ni.GetIPv4Statistics().BytesSent);
                Console.WriteLine("    Bytes Received: {0}", ni.GetIPv4Statistics().BytesReceived);
            }

            string filler = Console.ReadLine();
        }
    }
}
