using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model.Salle;
using Salle.Model.Commun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSalle
{
    [TestClass()]
    public class ChefRangTests
    {
        private Carre carre;
        private Carte carte;
        private ChefRang chefRang;

        [TestMethod()]
        public void ChefRangTest()
        {

        }

        [TestMethod()]
        public void distribueCartesTest()
        {
            chefRang = new ChefRang();
            carte = new Carte();

        }

        [TestMethod()]
        public void prendreCommandeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void placerClientTableTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void dresserTableTest()
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