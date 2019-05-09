using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Salle.Model.Salle.Tests
{
    [TestClass()]
    public class GroupeClientTest
    {
        [TestMethod()]
        public void GroupeClientTests()
        {
            GroupeClient test = new GroupeClient();

            //Assert.IsNotNull(test);

            foreach (IClient client in test._Clients) Assert.IsNotNull(client);
            //Assert.AreEqual(nbrType, 1);

           // Assert.IsNotNull();
           //Assert.AreEqual(nbrClient, nbrClientTest);



                /*
                List<IClient> Clients = new List<IClient>();
                Clients.Add(ClientFactory.getClient("Client1"));
                Assert.IsNotNull(Clients);
                */
        }

        [TestMethod()]
        public void suivreChefRangTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void clientsCommandeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void quitterTableTest()
        {
            List<IClient> Clients = new List<IClient>();
            Clients.Add(ClientFactory.getClient("Client1"));
            Clients = null;
            Assert.IsNull(Clients);
        }

        [TestMethod()]
        public void updateTest()
        {
            Assert.Fail();
        }
    }
}