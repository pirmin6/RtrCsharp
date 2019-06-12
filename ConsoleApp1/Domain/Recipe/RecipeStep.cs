using ConsoleApp1.Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    class RecipeStep
    {
        private string desc;
        private List<IngredientQuantity> ingredientQuantities;
        private List<KitchenMaterial> listUstencils;
        private Boolean cutVegetables;
        private int timeToCook;
    }
}
