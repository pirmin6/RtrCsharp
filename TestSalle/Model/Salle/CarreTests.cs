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
    public class CarreTests
    {
        private List<rang> listeRang;
        private int nmbreRang;
        int[] nbrTableParRang;
        int[][] nbrPlacesParTable;
        [TestMethod()]
        public void CarreTest()
        {
            listeRang = new List<rang>();

            for (int i = 0; i < nmbreRang; i++)
            {
                for (int j = 0; j < nbrTableParRang[i]; i++)
                    listeRang.Add(new rang(nbrTableParRang[i], nbrPlacesParTable[j]));
            }
            Assert.IsNotNull(listeRang);
        }

        [TestMethod()]
        public void getTablesDispoTest()
        {
            int[] nbrPlacesParTable = new int[5];
            int nbreTables;
            List<Table> tablesDispo = new List<Table>();
            rang rang = new rang(1, nbrPlacesParTable);
            listeRang = new List<rang>();
            foreach (object test in listeRang)
            {

                foreach (Table table in rang.Tables)
                {

                    if (table.groupeClient == null)
                    {
                        tablesDispo.Add(table);
                    }
                }
            }
            Assert.IsNotNull(tablesDispo);

        }
    }
}