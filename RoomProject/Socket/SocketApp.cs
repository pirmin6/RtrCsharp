using RoomProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using RoomProject.Socket;
using ConsoleApp2.Model.Staff;
using ConsoleApp2.Model;
using ConsoleApp2.Model.Object;

using Commun;


namespace RoomProject.Socket
{
    public class SocketApp : IWaiter
    {
        public bool State { get; set; }
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


        public void Update(Observable observable, string message)
        {
            Counter counter = (Counter)observable;
            
            switch (message)
            {
                    case "Commande":
                    Console.WriteLine("fgbfnfedzfdbgfdfedefgbg");
                        for (int i = 0; i < counter.CommandeEnvoie.Count; i++)
                        {
                           
                            this.SendCommande(counter.CommandeEnvoie[i]);
                            counter.CommandeEnvoie.Clear();

                        }
                        break;

                    case "Material":
                        for (int i = 0; i < counter.CommandeEnvoie.Count; i++)
                        {
                            this.SendMaterial(counter.MaterialEnvoie[i]);
                            counter.MaterialEnvoie.Clear(); 
                        }
                        break;
            }
                
        }

    }
}
