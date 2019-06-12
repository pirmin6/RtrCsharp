using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    class IngredientQuantity
    {
        private int quantity;
        private Ingredient ingredient;

        public IngredientQuantity(int quantity, Ingredient ingredient)
        {
            this.quantity = quantity; this.ingredient = ingredient;
        }

        public int Quantity { get => quantity; }
        internal Ingredient Ingredient { get => ingredient; }
    }
}
