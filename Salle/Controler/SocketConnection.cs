using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using Salle.Model.Commun;

namespace Salle.Controler
{
    class SocketConnection
    {
        public void Socket()
        {
            // Socket 
            Socket sckt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // endpoint = ip local + port
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            try
            {
                sckt.Connect(endPoint);
                /* On envoie la commande
                 sckt.Shutdown(SocketShutdown.Both);  
                 sckt.Close();
                 */

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
        }
    }
}
