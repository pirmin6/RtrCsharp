using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public class Carre
    {
        private List<rang> listeRang;
        public ChefRang ChefRangCarre;

        public Carre(int[][] TableauRangs, ChefRang chefRang)
        {
            listeRang = new List<rang>();

            //int TailleTableau = TableauTables;
            Console.WriteLine("le Carre contient {0} rang", TableauRangs.Length);

            this.ChefRangCarre = chefRang;

            if (chefRang != null) Console.WriteLine("Le carré possède un chef Rang");

            for (int i = 0; i < TableauRangs.Length; i++)
            {
                int[] TableauTable = new int[TableauRangs[i].Length];

                for (int j = 0; j < TableauRangs[i].Length; j++)
                {
                    TableauTable[j] = TableauRangs[i][j];
                }

                listeRang.Add(new rang(TableauTable)); 
            }
        }


        public List<Table> getTablesDispo()
        {
            List<Table> tablesDispo = new List<Table>();
            
            foreach (rang element in listeRang)
            {
                foreach(Table table in element.Tables)
                {
                    if (table.TableOccuper == true)
                    {
                    tablesDispo.Add(table);
                    }
                }
            }

            return tablesDispo;
        }

        public ChefRang _ChefRangCarre
        {
            get { return this._ChefRangCarre; }
        }
    }
}
