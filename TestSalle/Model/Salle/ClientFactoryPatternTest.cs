using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle.Tests
{
    [TestClass()]
    public class ClientFactoryPatternTest
    {
        [TestMethod()]
        public void ClientFactoryPatternneTest()
        {
            IClient client1 = ClientFactory.getClient("Client1");
            Assert.IsNotNull(client1);
        }


    }
}