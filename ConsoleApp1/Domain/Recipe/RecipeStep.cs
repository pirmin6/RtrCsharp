using ConsoleApp1.Domain.KitchenMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    public class RecipeStep
    {
        private string desc;
        private List<IngredientQuantity> ingredientQuantities;
        private List<IKitchenMaterial> listUstencils;
        private Boolean peelIngredient;
        private int timeToCook;

        public RecipeStep(string desc, int timeToCook)
        {
            this.desc = desc; this.timeToCook = timeToCook;
            ingredientQuantities = new List<IngredientQuantity>();
            listUstencils = new List<IKitchenMaterial>();
            peelIngredient = false;

           // IngredientQuantity steakQuantity = new IngredientQuantity()
        }

        public string Desc { get => desc; set => desc = value; }
        public bool PeelIngredient { get => peelIngredient; set => peelIngredient = value; }
        public int TimeToCook { get => timeToCook; set => timeToCook = value; }
        internal List<IngredientQuantity> IngredientQuantities { get => ingredientQuantities; set => ingredientQuantities = value; }
        internal List<IKitchenMaterial> ListUstencils { get => listUstencils; set => listUstencils = value; }
    }


}
