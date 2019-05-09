using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public class rang
    {
        public List<Table> Tables;

        int nmbreTables;

        /*
        public rang(int nbreTables, int[] nbrPlacesParTable)
        {
            Tables = new List<Table>();
            for (int i = 0; i < nbreTables; i++)
            {
                Tables.Add(new Table(nbrPlacesParTable[i]));
            }

        }
        */

        public rang(int[] TableauTables)
        {
            Tables = new List<Table>();

            for (int i = 0; i < TableauTables.Length; i++)
            {
                Tables.Add(new Table(TableauTables[i]));
            }

            Console.WriteLine("Le rang contient {0} tables", TableauTables.Length);
        }

        public List<Table> GetTableDisponible()
        {
            List<Table> tableDispo = new List<Table>();
            
            foreach(Table table in Tables)
            {
                if(table.TableOccuper == true)
                {
                    tableDispo.Add(table);
                }
            }

            return tableDispo;
        }

        /*
         *         public List<Table> GetTableDisponible()
        {
            List<Table> tableDispo = new List<Table>();
            
            foreach(Table table in Tables)
            {
                if(table.getGroupeClient() == null)
                {
                    tableDispo.Add(table);
                }
            }

            return tableDispo;
        }
        */
        
    }
}
