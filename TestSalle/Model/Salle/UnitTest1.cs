using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model.Salle;

namespace TestSalle.Model.Salle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var groupe1 = new GroupeClient() { Vin = true, Eau = true} ;


            var serveur1 = new Serveur();

            groupe1.AttachServeur(serveur1);

            Assert.AreEqual(groupe1.PainCorbeille, 3);
            //Assert.AreEqual(groupe1.Vin, true);
            //Assert.AreEqual(groupe1.Eau, true);


            groupe1.PainCorbeille = 0;
            groupe1.Vin = false;


            Assert.AreEqual(groupe1.PainCorbeille, 1);
            Assert.AreEqual(groupe1.Vin, true);
            //Assert.AreEqual(groupe1.Eau, true);

        }
    }
}
