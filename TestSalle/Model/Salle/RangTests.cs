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
    public class RangTests
    {
        int nbreTables;
        int[] nbrPlacesParTable = new int[6] { 1, 2, 3, 4, 5, 6, };
        private List<Table> Tables;
        [TestMethod()]
        public void RangTest()
        {
            Tables = new List<Table>();
            for (int i = 0; i < nbreTables; i++)
            {
                Tables.Add(new Table(nbrPlacesParTable[i]));
            }
            Assert.IsNotNull(Tables);

        }
    

        [TestMethod()]
        public void TableDisponible()
        {
            List<Table> tableDispo = new List<Table>();

            foreach (Table table in Tables)
            {
                if (table.getGroupeClient() == null)
                {
                    tableDispo.Add(table);
                }
            }
            Assert.IsNotNull(tableDispo);
        }
    }
}