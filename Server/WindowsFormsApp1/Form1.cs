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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        class SimpleServer
        {
            Server server;
            ClientInfo client;
            void Start()
            {
                server = new Server(2345, new ClientEvent(ClientConnect));
            }

            bool ClientConnect(Server serv, ClientInfo new_client)
            {
                new_client.Delimiter = '\n'.ToString();
                new_client.OnRead += new ConnectionRead(ReadData);
                return true; // allow this connection
            }

            void ReadData(ClientInfo ci, String text)
            {
                Console.WriteLine("Received from " + ci.ID + ": " + text);
                if (text[0] == '!')
                    server.Broadcast(Encoding.UTF8.GetBytes(text));
                else ci.Send(text);
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
