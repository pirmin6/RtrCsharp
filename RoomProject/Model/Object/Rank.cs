using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Client;

namespace ConsoleApp2.Model.Object
{
    public class Rank
    {
        private List<Table> tables;

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

        public Rank(int[] TableauTables)
        {
            Tables = new List<Table>();

            for (int i = 0; i < TableauTables.Length; i++)
            {
                Tables.Add(new Table(TableauTables[i]));
            }

            //Console.WriteLine("Le rang contient {0} tables", TableauTables.Length);
        }

        public List<Table> Tables { get => tables; set => tables = value; }

        public List<Table> GetTableDisponible()
        {
            List<Table> tableDispo = new List<Table>();

            foreach (Table table in Tables)
            {
                if (table.TableOccuper == true)
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

