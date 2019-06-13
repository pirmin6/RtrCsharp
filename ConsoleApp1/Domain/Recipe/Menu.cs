using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Recipe
{
    public class Menu
    {
        static List<Dish> listDish;

        public Menu()
        {

            Ingredient steak = new Ingredient("Steak", "Viande");

            RecipeStep preparerSteak = new RecipeStep("Cuire le Steak", 10);
            IngredientQuantity steakQuantity = new IngredientQuantity(1, steak);


            // Création des Plats
            Dish burgerClassic = new Dish(1, "Burger Classique");
            Dish burgerChicken = new Dish(2, "Burger Poulet");
            Dish burgerMountain = new Dish(3, "Burger Montagnard");
            Dish burgerVegan = new Dish(4, "Burger Vegan");

            listDish.Add(burgerClassic);
            listDish.Add(burgerChicken);
            listDish.Add(burgerMountain);
            listDish.Add(burgerVegan);
        }
    }
}
