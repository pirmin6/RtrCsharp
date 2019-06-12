using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    class Ingredient
    {
        private string name;
        private string type;

        public Ingredient(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name { get => name;}
        public string Type { get => type;}
    }
}
