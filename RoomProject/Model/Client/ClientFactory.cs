using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Client
{
    class ClientFactory
    {
        static public IClient getClient(string ClientType)
        {
            if (ClientType == "Client1")
            {
                IClient clientType1 = new ClientImpl1();
                return clientType1;

            }
            else
            {
                return new ClientImpl2();
            }

        }
    }
}
