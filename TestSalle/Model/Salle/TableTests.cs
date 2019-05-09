using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.Model.Salle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSalle
{
    [TestClass()]
    public class TableTests
    {
        private int nbrPlaces = 4;

        [TestMethod()]
        public void TableTest()
        {
            this.nbrPlaces = nbrPlaces;
            Assert.IsNotNull(nbrPlaces);
        }
    }
}