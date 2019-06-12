using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Client;

namespace ConsoleApp2.Model.Object
{
    public class Square
    {
        private List<Rank> listeRang;
        public RankLeader ChefRangCarre;

        public Square(int[][] TableauRangs, RankLeader chefRang)
        {
            ListeRang = new List<Rank>();

            //int TailleTableau = TableauTables;
            //Console.WriteLine("le Carre contient {0} rang", TableauRangs.Length);

            this.ChefRangCarre = chefRang;


            //Console.WriteLine("le Carre à un " + ChefRangCarre);


            if (chefRang != null) //Console.WriteLine("Le carré possède un chef Rang");

            for (int i = 0; i < TableauRangs.Length; i++)
            {
                int[] TableauTable = new int[TableauRangs[i].Length];

                for (int j = 0; j < TableauRangs[i].Length; j++)
                {
                    TableauTable[j] = TableauRangs[i][j];
                }

                ListeRang.Add(new Rank(TableauTable));
            }
        }


        public List<Table> getTablesDispo()
        {
            List<Table> tablesDispo = new List<Table>();

            foreach (Rank element in ListeRang)
            {
                foreach (Table table in element.Tables)
                {
                    if (table.TableOccuper == false)
                    {
                        tablesDispo.Add(table);
                    }
                }
            }

            return tablesDispo;
        }

        public RankLeader _ChefRangCarre
        {
            get { return this._ChefRangCarre; }
        }

        public List<Rank> ListeRang { get => listeRang; set => listeRang = value; }
    }
}
