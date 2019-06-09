using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using ConsoleApp2.Model.Object;


namespace ConsoleApp2.Socket
{
    class SocketTextile
    {
        public SocketTextile()
        {

        }

        public void SendTextile()
        {
            bool testc = true;
            while (testc)
            {

                //string message = Console.ReadLine();

                string test2 = "Textile from Salle";
                //string test = test2.ToString();
                int[][] CMD = new int[][] { new int[] { 1, 2, 2, 4, 8 } };
                //convertit int en string
                //string test = CommandeEnvoie.ToString();
                byte[] msg;
                msg = Encoding.Default.GetBytes(test2);
                UdpClient udpClient = new UdpClient();
                udpClient.Send(msg, msg.Length, "127.0.0.1", 10000);
                udpClient.Close();
                //Console.Write("\nContinuer ? (O/N)");
                //testc = (Console.ReadKey().Key == ConsoleKey.O);
            }
        }

        public void ListnerVaiselle()
        {
            UdpClient serveur = new UdpClient(11111);

            while (true)
            {

                System.Net.IPEndPoint client = null;
                byte[] data = serveur.Receive(ref client);

                int x = 0;
                string msg = Encoding.Default.GetString(data);
                Int32.TryParse(msg, out x);
                Console.WriteLine("serveur2 {0}", msg);
                // s'assure que c'est un int
                //Console.WriteLine("{0}", x.GetType());
            }
        }
    }
}
