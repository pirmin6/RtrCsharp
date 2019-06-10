using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

using Commun;


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

        public void update(Observable observable, string message)
        {
            switch (message)
            {
                case "Commande":
                    for (int i = 0; i < observable.ListOnDesk.Count; i++)
                    {
                        CommandePaquet ap = new CommandePaquet(observable.ListOnDesk.ElementAt(i).idTable, observable.ListOnDesk.ElementAt(i).ListPlats);
                        this.SendCommande(ap);
                    }
                    break;

                case "Material":
                    for (int i = 0; i < observable.ListOnDesk.Count; i++)
                    {
                        MaterialPaquet ap = new MaterialPaquet(observable.ListOnDesk.ElementAt(i).idTable, observable.ListOnDesk.ElementAt(i).ListPlats);
                        this.SendMaterial(ap);
                    }
                    break;
                    
            }


            //On vide la liste 
            observable.ListOnDesk.Clear();
        }
    }
}
