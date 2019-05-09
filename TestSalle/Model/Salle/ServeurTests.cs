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
    public class ServeurTests
    {
        private int stockPain;
        private int stockEau;
     

        [TestMethod()]
        public void ServeurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ramasserAssietteCouvertsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void servirClientsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void debarrasserTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void servirPainTest()
        {
            int stockPainFinal = stockPain - 1;
            Assert.AreNotEqual(stockPainFinal, stockPain);
            // Assert.Fail();
        }

        [TestMethod()]
        public void servirEauTest()
        {
            int stockEauFinal = stockEau - 1;
            Assert.AreNotEqual(stockEauFinal, stockEau);
            // Assert.Fail();
        }

        [TestMethod()]
        public void servirVinTest()
        {

            Assert.Fail();
        }

        [TestMethod()]
        public void updateTest()
        {
            Assert.Fail();
        }
    }
}