using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp2.Model.Object;

//Utilise le Projet Commun
using Commun;


namespace RoomProject.Socket
{
    class SocketListener
    {
        private static Counter counter;

        public static Counter Counter { get => counter; set => counter = value; }

        public static void listener()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1800);
            listener.Start();

            while (true)
            {
                Console.WriteLine("Ecoute . . . ");
                TcpClient client = listener.AcceptTcpClient();
                ParameterizedThreadStart ts = new ParameterizedThreadStart(acceptConnection);
                Thread t = new Thread(ts);
                t.Start(client);

            }
        }

        public static void acceptConnection(object obj)
        {
            TcpClient client = (TcpClient)obj;

            NetworkStream stream = client.GetStream();

            Paquet paquet = Paquet.Receive(stream);

            if (paquet is MaterialPaquet)
            {
                MaterialPaquet ap = (MaterialPaquet)paquet;
                // counter.ListMaterialDemander.Add(ap);

                //Console.WriteLine("J'ai recu le paquet eheh");
                //Console.WriteLine(ap.Material);
                //Console.WriteLine(ap.Quantity);
                counter.MaterialRecu.Add(ap);
            }

            if (paquet is CommandePaquet)
            {
                CommandePaquet ap = (CommandePaquet)paquet;

                Console.WriteLine("J'ai recu le paquet eheh");
                Console.WriteLine(ap.IdTable);

                for (int i = 0; i < ap.ListPlats.Count; i++)
                {
                    //Console.WriteLine(ap.ListPlats.ElementAt(i));
                    counter.CommandeReçu.Add(ap);
                }

            }
        }
    }
}
