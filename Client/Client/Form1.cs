using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// At the top of the file, you will always need
using System.Net.Sockets;
using RedCorona.Net;
namespace Client
{
    public partial class Form1 : Form
    {


        class SimpleClient
        {
            ClientInfo client;
            void Start()
            {
                Socket sock = Sockets.CreateTCPSocket("www.myserver.com", 2345);
                client = new ClientInfo(sock, false); // Don't start receiving yet
                client.OnReadBytes += new ConnectionReadBytes(ReadData);
                client.BeginReceive();
            }

            void ReadData(ClientInfo ci, byte[] data, int len)
            {
                Console.WriteLine("Received " + len + " bytes: " +
                System.Text.Encoding.UTF8.GetString(data, 0, len));
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
