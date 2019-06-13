using ConsoleApp1.Domain.KitchenMaterial;
using ConsoleApp1.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain
{
    public class DomainApp
    {
        private static List<Dish> menu = new List<Dish>();
        public DomainApp()
        {

            // Créations des Ingrédients
            Ingredient steak = new Ingredient("Steak", "Refrigérateur");
            Ingredient poulet = new Ingredient("Poulet", "Refrigérateur");
            Ingredient poisson = new Ingredient("Poisson", "Refrigérateur");
            Ingredient pain = new Ingredient("Pain", "Stock d'Ingrédient");
            Ingredient salade = new Ingredient("Salade", "Stock d'Ingrédient");
            Ingredient tomate = new Ingredient("Tomate", "Stock d'Ingrédient");
            Ingredient oignon = new Ingredient("Oignon", "Stock d'Ingrédient");
            Ingredient cheddar = new Ingredient("Cheddar", "Refrigérateur");
            Ingredient raclette = new Ingredient("Raclette", "Refrigérateur");
            Ingredient sauce = new Ingredient("Sauce", "Stock d'Ingrédient");

            // Instanciation Object Cuisine Material
            KitchenKnife kitchenKnife = new KitchenKnife();
            Pans kitchenCasserolle = new Pans();
            Stove kitchenPoêle = new Stove();
            WoodenSpoon kitchenCuillière = new WoodenSpoon();
            SaladBowl kitchenBolSalade = new SaladBowl();


            // Creation des etapes des recettes
            RecipeStep prepareSteak = new RecipeStep("Cuire le Steak", 5000);
            prepareSteak.IngredientQuantities.Add(new IngredientQuantity(1, steak));
            prepareSteak.ListUstencils.Add(kitchenPoêle);

            RecipeStep preparePoulet = new RecipeStep("Cuire le Poulet", 5000);
            preparePoulet.IngredientQuantities.Add(new IngredientQuantity(1, poulet));
            preparePoulet.ListUstencils.Add(kitchenPoêle);

            RecipeStep preparePoisson = new RecipeStep("Cuire le Poisson", 5000);
            preparePoisson.IngredientQuantities.Add(new IngredientQuantity(1, poisson));
            preparePoisson.ListUstencils.Add(kitchenPoêle);

            RecipeStep prepareVegetables = new RecipeStep("Couper les légumes", 1000);
            prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(1, salade));
            prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(2, tomate));
            prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(1, oignon));
            prepareVegetables.ListUstencils.Add(kitchenBolSalade);
            prepareVegetables.ListUstencils.Add(kitchenCuillière);
            prepareVegetables.ListUstencils.Add(kitchenKnife);
            prepareVegetables.PeelIngredient = true;

            RecipeStep prepareRaclette = new RecipeStep("Préparer le frommage à Raclette", 1000);
            prepareRaclette.IngredientQuantities.Add(new IngredientQuantity(2, raclette));
            prepareRaclette.ListUstencils.Add(kitchenKnife);
            prepareRaclette.PeelIngredient = true;

            RecipeStep prepareCheddar = new RecipeStep("Préparer le Cheddar", 1000);
            prepareCheddar.IngredientQuantities.Add(new IngredientQuantity(2, cheddar));
            prepareCheddar.ListUstencils.Add(kitchenKnife);
            prepareCheddar.PeelIngredient = true;


            RecipeStep assemblerBurger = new RecipeStep("Assembler le Burger", 1000);
            assemblerBurger.IngredientQuantities.Add(new IngredientQuantity(1, pain));
            assemblerBurger.IngredientQuantities.Add(new IngredientQuantity(1, sauce));


            // Creations des plats
            Dish burgerClassic = new Dish(1, "Burger Classique");
            burgerClassic.Recipe.Add(prepareVegetables);
            burgerClassic.Recipe.Add(prepareSteak);
            burgerClassic.Recipe.Add(prepareCheddar);
            burgerClassic.Recipe.Add(assemblerBurger);

            Dish burgerChicken = new Dish(2, "Burger Poulet");
            burgerChicken.Recipe.Add(preparePoulet);
            burgerChicken.Recipe.Add(prepareCheddar);
            burgerChicken.Recipe.Add(prepareVegetables);
            burgerChicken.Recipe.Add(assemblerBurger);

            Dish burgerMountain = new Dish(3, "Burger Montagnard");
            burgerMountain.Recipe.Add(prepareVegetables);
            burgerMountain.Recipe.Add(prepareCheddar);
            burgerMountain.Recipe.Add(prepareSteak);
            burgerMountain.Recipe.Add(assemblerBurger);

            Dish burgerVegan = new Dish(4, "Burger Vegan");
            burgerVegan.Recipe.Add(prepareVegetables);
            burgerVegan.Recipe.Add(prepareCheddar);
            burgerVegan.Recipe.Add(preparePoisson);
            burgerVegan.Recipe.Add(prepareRaclette);
            burgerVegan.Recipe.Add(assemblerBurger);
              
            // Ajout des plats dans la liste Menu static
            menu.Add(burgerClassic);
            menu.Add(burgerChicken);
            menu.Add(burgerMountain);
            menu.Add(burgerVegan);
        }

        public static List<Dish> Menu { get => menu;}
    }
}
