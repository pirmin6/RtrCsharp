using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    class Dish
    { 
        private int idDish;
        private string name;
        private List<RecipeStep> recipe;

        public Dish(int idDish, string name)
        {
            this.idDish = idDish; this.name = name;
            recipe = new List<RecipeStep>();
        }
    }
}
