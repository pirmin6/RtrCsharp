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
    public class ClientImpl1Tests
    {
        [TestMethod()]
        public void prendreRepasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void choisirRepasTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void mangerPlatTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void commanderVinTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void commanderEauTest()
        {
            Serveur serveur = new Serveur();
            int StockBase = serveur.StockEau;
            //serveur.servirEau();
            int stockFinal = serveur.StockEau;
            Assert.AreNotEqual(StockBase, stockFinal);
        }

        [TestMethod()]
        public void commanderPainTest()
        {
            Serveur serveur = new Serveur();
            int StockBase = serveur.StockPain;
            //serveur.servirPain();
            int stockFinal = serveur.StockPain;
            Assert.AreNotEqual(StockBase, stockFinal);
        }
    }
}