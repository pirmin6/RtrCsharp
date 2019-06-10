using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RoomProject.Socket
{
    class ConnectionUDP
    {

        public static void Send(string message)
        {
            byte[] msg = Encoding.Default.GetBytes(message);

            UdpClient sender = new UdpClient();

            sender.Send(msg, msg.Length, "127.0.0.1", 5035);
            sender.Close();
        }


        public static string Listen()
        {
            UdpClient listener = new UdpClient(5036);

            while (true)
            {
                Console.WriteLine("ECOUTE...");

                IPEndPoint client = null;

                byte[] data = listener.Receive(ref client);
                Console.WriteLine("Données reçues en provenance de {0}:{1}", client.Address, client.Port);

                // Conversion des bytes en string
                string message = Encoding.Default.GetString(data);
                return message;
            }
        }
    }
}
