using RoomProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoomProject.Socket
{
    class SocketApp 
    {
        public SocketApp()
        {
            Thread listenThread = new Thread(ListenSocket);

            listenThread.Start();
        }

        public void ListenSocket()
        {
            string message = ConnectionUDP.Listen();
            //ConnectionUDP.Listen();
            //string message = "hello";
            Object Deserialized = SerializationJSON.ReadToObject(message);

            Console.WriteLine("la commande a bien été reçue");
        }

        public void SendSocket(Object obj)
        {
            string message = SerializationJSON.WriteObject(obj);
            ConnectionUDP.Send(message);

            Console.WriteLine("Le message a bien été envoyé");
        }

        /*
        public void update(Observable observable)
        {
            for (int i = 0; i < observable.ListOnDesk.Count; i++)
            {
                this.SendSocket(observable.ListOnDesk.ElementAt(i));
            }

            //On vide la liste 
            observable.ListOnDesk.Clear();
        }
        */
    }
}
