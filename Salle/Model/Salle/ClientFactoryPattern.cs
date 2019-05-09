using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public class ClientFactoryPattern
    {
        public ClientFactoryPattern()
        {
            ClientFactory ClientFactory = new ClientFactory();
            IClient client = ClientFactory.getClient("Client1");
            IClient client2 = ClientFactory.getClient("Client2");

        }

    }
}
