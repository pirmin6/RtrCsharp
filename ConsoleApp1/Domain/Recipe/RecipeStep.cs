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

        public RecipeStep(string desc, int timeToCook)
        {
            this.desc = desc; this.timeToCook = timeToCook;
            ingredientQuantities = new List<IngredientQuantity>();
            listUstencils = new List<KitchenMaterial>();
        }

        public string Desc { get => desc; set => desc = value; }
        public bool CutVegetables { get => cutVegetables; set => cutVegetables = value; }
        public int TimeToCook { get => timeToCook; set => timeToCook = value; }
        internal List<IngredientQuantity> IngredientQuantities { get => ingredientQuantities; set => ingredientQuantities = value; }
        internal List<KitchenMaterial> ListUstencils { get => listUstencils; set => listUstencils = value; }
    }


}
