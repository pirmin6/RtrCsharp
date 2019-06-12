using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

using Commun;
using ConsoleApp1.Model.Object;

namespace ConsoleApp1.Socket
{
    class SocketApp : IObserver
    {
        public SocketApp()
        {
            Thread listenThread = new Thread(SocketListener.listener);
            listenThread.Start();
        }

        public void SendCommande(CommandePaquet ap)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1800);

            NetworkStream stream = client.GetStream();

            Paquet.Send(ap, stream);
            Console.WriteLine("j'envois le paquet");

            Thread.Sleep(100);
        }

        public void SendMaterial(MaterialPaquet ap)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1800);

            NetworkStream stream = client.GetStream();

            Paquet.Send(ap, stream);
            Console.WriteLine("j'envois le paquet");

            Thread.Sleep(100);
        }

        public void update(Desk observable, string message)
        {
            switch (message)
            {
                case "SendCommande":
                    for (int i = 0; i < observable.ListCommandeSend.Count; i++)
                    {
                        this.SendCommande(observable.ListCommandeSend.ElementAt(i));
                        observable.ListCommandeSend.Clear();
                    }
                    break;

                case "SendMaterial":
                    for (int i = 0; i < observable.ListMaterialSend.Count; i++)
                    {
                        this.SendMaterial(observable.ListMaterialSend.ElementAt(i));
                        observable.ListMaterialSend.Clear();
                    }
                    break;    
            }
        }
    }
}
