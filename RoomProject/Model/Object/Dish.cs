using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Object
{
    public class Dish
    {
        private string nom;
        private int id;

        public Dish(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;

        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        internal static void Add(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
