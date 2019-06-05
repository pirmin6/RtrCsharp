using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace ConsoleApp1.Socket
{
    class SocketCommande
    {

        public SocketCommande()
            {
            }

        public void Ecouter()
        {
            Thread ThreadListnerCMD = new Thread(Ecouter);
            ThreadListnerCMD.Start();

            UdpClient serveur = new UdpClient(5035);

            while (true)
            {
                List<int> commande = new List<int>();
                List<int> taille = new List<int>();
                Console.WriteLine("\n Nouvelle Commande \n");
                while (true)
                {

                    System.Net.IPEndPoint client = null;
                    byte[] data = serveur.Receive(ref client);
                    int x;
                    string msg = Encoding.Default.GetString(data);
                    Int32.TryParse(msg, out x);
                    Console.WriteLine(x + "Taille de la commande :" + x);
                    taille.Add(x);
                    break;
                }


                // s'assure que c'est un int
                //Console.WriteLine("{0}", x.GetType());
                int i = 0;

                while (i < taille[0])
                {
                    int z;
                    System.Net.IPEndPoint client = null;
                    byte[] data = serveur.Receive(ref client);
                    string cmd = Encoding.Default.GetString(data);
                    Int32.TryParse(cmd, out z);
                    commande.Add(z);
                    //Console.WriteLine(z);
                    i++;
                }
                Console.WriteLine("\n La commande contient :");
                foreach (int elem in commande)
                {
                    Console.WriteLine(elem);
                }

                //envoie et que la clear



            }
        }

    }
}
