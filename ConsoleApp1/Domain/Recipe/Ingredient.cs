using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    public class Ingredient
    {
        private string name;
        private string localisation;

        public Ingredient(string name, string localisation)
        {
            this.name = name;
            this.localisation = localisation;
        }

        public string Name { get => name;}
        public string Localisation { get => localisation;}
    }
}
