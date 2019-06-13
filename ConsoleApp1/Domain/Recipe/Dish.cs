using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    public class Dish
    { 
        private int idDish;
        private string name;
        private List<RecipeStep> recipe;

        public Dish(int idDish, string name)
        {
            this.idDish = idDish; this.name = name;
            Recipe = new List<RecipeStep>();
        }

        public int IdDish { get => idDish;}
        internal List<RecipeStep> Recipe { get => recipe; set => recipe = value; }
    }
}
