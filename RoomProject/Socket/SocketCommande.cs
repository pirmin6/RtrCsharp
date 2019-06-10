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
    public class SocketCommande
    {
        public SocketCommande()
        {

        }

        public void sendCMD(Counter counter)
        {
            bool testc = true;
            while (testc)
            {

                //string message = Console.ReadLine();

                string test2 = "zeubi";
                //string test = test2.ToString();
                //List<int> commande = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
                //convertit int en string
                //string test = CommandeEnvoie.ToString();
                byte[] msg;
                byte[] lenght;

                bool voo = true;
                UdpClient udpClient = new UdpClient();

                Thread.Sleep(100);
                while (voo)
                {
                    lenght = Encoding.Default.GetBytes(counter.CommandeEnvoie.Count().ToString());
                    //UdpClient udpClient = new UdpClient();
                    udpClient.Send(lenght, lenght.Length, "127.0.0.1", 5035);
                    voo = false;
                }

                udpClient.Close();

                Thread.Sleep(2000);

                //UdpClient udpClientCMD = new UdpClient();
                //foreach (int item in counter.CommandeEnvoie1[0])
                //{
                //    test2 = item.ToString();
                //    msg = Encoding.Default.GetBytes(test2);
                //    udpClientCMD.Send(msg, msg.Length, "127.0.0.1", 5035);
                //}
                //udpClient.Close();
                //Console.WriteLine("La commande à été envoyée");
            }
        }


        // A faire en retour
        public void ListnerCommande()
        {
            UdpClient serveur = new UdpClient(5035);

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
