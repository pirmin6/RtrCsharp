using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Utilise le Projet Commun
using Commun;
using ConsoleApp1.Model.Object;

namespace ConsoleApp1.Socket
{
    public class SocketListener
    {
        public static Desk kitchenDesk; 

        public static void listener()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1800);
            listener.Start();

            while (true)
            {
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
                kitchenDesk.ListMaterialGet.Add(ap);

                Console.WriteLine("La Cuisine a recue un Paquet de {0}", ap.TypeMaterial);
            }

            if (paquet is CommandePaquet)
            {
                CommandePaquet ap = (CommandePaquet)paquet;
                kitchenDesk.ListCommandeGet.Add(ap);
                

                Console.WriteLine("La Cuisine a recue une Commande de la Table : {0}", ap.IdTable);

                Console.WriteLine("La liste commandeGet contient {0} lignes", kitchenDesk.ListCommandeGet.Count);

                
            }
        }
    }
}
