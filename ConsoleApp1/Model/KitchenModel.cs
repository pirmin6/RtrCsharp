using ConsoleApp1.Domain;
using ConsoleApp1.Domain.KitchenMaterial;
using ConsoleApp1.Domain.Recipe;
using ConsoleApp1.Model.Object;
using ConsoleApp1.Socket;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenProject.Model
{
    public class KitchenModel
    {
        private List<Sprite> personnel;
        private List<Sprite> objects;
        public KitchenModel()
        {
            
            personnel = new List<Sprite>();
            objects = new List<Sprite>();

            Desk kitchenDesk = new Desk();
            Sink kitchenSink = new Sink();
            HeatingPlate plaque1 = new HeatingPlate();
            HeatingPlate plaque2 = new HeatingPlate();
            HeatingPlate plaque3 = new HeatingPlate();
            Dishwasher laveVaisselle = new Dishwasher();
            LaundryMachine laveLinge = new LaundryMachine();
            DishesStock stockVaisselle = new DishesStock();
            DirtyDishesStock stockVaiselleSale = new DirtyDishesStock();
            Fridge kitchenFridge = new Fridge();
            KitchenMaterialStock kitchenMaterialStock = new KitchenMaterialStock();
            IngredientStock kitchenIngredientStock = new IngredientStock();

            objects.Add(kitchenDesk.Sprite);
            objects.Add(kitchenSink.Sprite);
            objects.Add(plaque1.Sprite);
            objects.Add(plaque2.Sprite);
            objects.Add(plaque3.Sprite);
            objects.Add(laveVaisselle.Sprite);
            objects.Add(laveLinge.Sprite);
            objects.Add(stockVaisselle.Sprite);
            objects.Add(stockVaiselleSale.Sprite);
            objects.Add(kitchenFridge.Sprite);
            objects.Add(kitchenMaterialStock.Sprite);
            objects.Add(kitchenIngredientStock.Sprite);


            Plunger plongeur = new Plunger(kitchenDesk, stockVaiselleSale, stockVaisselle, laveVaisselle, laveLinge, kitchenSink);
            Clerk commis1 = new Clerk(kitchenMaterialStock, kitchenIngredientStock, kitchenFridge);
            Clerk commis2 = new Clerk(kitchenMaterialStock, kitchenIngredientStock, kitchenFridge);
            Cooker cuisinier1 = new Cooker(commis1, commis2, kitchenMaterialStock, kitchenIngredientStock, kitchenFridge);
            Cooker cuisinier2 = new Cooker(commis1, commis2, kitchenMaterialStock, kitchenIngredientStock, kitchenFridge);
            Chef chef = new Chef(cuisinier1, cuisinier2);


            personnel.Add(chef.Sprite);
            personnel.Add(cuisinier1.Sprite);
            personnel.Add(cuisinier2.Sprite);
            personnel.Add(commis1.Sprite);
            personnel.Add(commis2.Sprite);
            personnel.Add(plongeur.Sprite);


            SocketApp socket = new SocketApp();

            SocketListener.kitchenDesk = kitchenDesk;

            // Ajouter des abonnés observer à l'observable Comptoir
            kitchenDesk.AttachChef(chef);
            kitchenDesk.AttachPlunger(plongeur);
            kitchenDesk.AttachSocket(socket);



            //// Créations des Ingrédients
            //Ingredient steak = new Ingredient("Steak", "Viande");
            //Ingredient poulet = new Ingredient("Poulet", "Viande");
            //Ingredient poisson = new Ingredient("Poisson", "Poisson");
            //Ingredient pain = new Ingredient("Pain", "Pain");
            //Ingredient salade = new Ingredient("Salade", "Vegetables");
            //Ingredient tomate = new Ingredient("Tomate", "Vegetables");
            //Ingredient oignon = new Ingredient("Oignon", "Vegetables");
            //Ingredient cheddar = new Ingredient("Cheddar", "Frommage");
            //Ingredient raclette = new Ingredient("Raclette", "Fromage");
            //Ingredient sauce = new Ingredient("Sauce", "Sauce");

            //// Instanciation Object Cuisine Material
            //KitchenKnife kitchenKnife = new KitchenKnife();
            //Pans kitchenCasserolle = new Pans();
            //Stove kitchenPoêle = new Stove();
            //WoodenSpoon kitchenCuillière = new WoodenSpoon();
            //SaladBowl kitchenBolSalade = new SaladBowl();


            //// Creation des etapes des recettes
            //RecipeStep prepareSteak = new RecipeStep("Cuire le Steak", 10);
            //prepareSteak.IngredientQuantities.Add(new IngredientQuantity(1, steak));
            //prepareSteak.ListUstencils.Add(kitchenPoêle);

            //RecipeStep preparePoulet = new RecipeStep("Cuire le Poulet", 10);
            //preparePoulet.IngredientQuantities.Add(new IngredientQuantity(1, poulet));
            //preparePoulet.ListUstencils.Add(kitchenPoêle);

            //RecipeStep preparePoisson = new RecipeStep("Cuire le Poisson", 10);
            //preparePoisson.IngredientQuantities.Add(new IngredientQuantity(1, poisson));
            //preparePoisson.ListUstencils.Add(kitchenPoêle);

            //RecipeStep prepareVegetables = new RecipeStep("Preparer les légumes", 5);
            //prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(1, salade));
            //prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(2, tomate));
            //prepareVegetables.IngredientQuantities.Add(new IngredientQuantity(1, oignon));
            //prepareVegetables.ListUstencils.Add(kitchenBolSalade);
            //prepareVegetables.ListUstencils.Add(kitchenCuillière);
            //prepareVegetables.ListUstencils.Add(kitchenKnife);

            //RecipeStep prepareRaclette = new RecipeStep("Préparer le frommage à Raclette", 5);
            //prepareRaclette.IngredientQuantities.Add(new IngredientQuantity(2, raclette));
            //prepareRaclette.ListUstencils.Add(kitchenKnife);

            //RecipeStep prepareCheddar = new RecipeStep("Préparer le Cheddar", 5);
            //prepareCheddar.IngredientQuantities.Add(new IngredientQuantity(2, cheddar));
            //prepareCheddar.ListUstencils.Add(kitchenKnife);

            //RecipeStep assemblerBurger = new RecipeStep("Assembler le Burger", 5);
            //assemblerBurger.IngredientQuantities.Add(new IngredientQuantity(1, pain));
            //assemblerBurger.IngredientQuantities.Add(new IngredientQuantity(1, sauce));


            //// Creations des plats
            //Dish burgerClassic = new Dish(1, "Burger Classique");
            //burgerClassic.Recipe.Add(prepareSteak);
            //burgerClassic.Recipe.Add(prepareVegetables);
            //burgerClassic.Recipe.Add(prepareCheddar);
            //burgerClassic.Recipe.Add(assemblerBurger);

            //Dish burgerChicken = new Dish(2, "Burger Poulet");
            //burgerChicken.Recipe.Add(preparePoulet);
            //burgerChicken.Recipe.Add(prepareVegetables);
            //burgerChicken.Recipe.Add(prepareCheddar);
            //burgerChicken.Recipe.Add(assemblerBurger);

            //Dish burgerMountain = new Dish(3, "Burger Montagnard");
            //burgerMountain.Recipe.Add(prepareSteak);
            //burgerMountain.Recipe.Add(prepareVegetables);
            //burgerMountain.Recipe.Add(prepareCheddar);
            //burgerMountain.Recipe.Add(assemblerBurger);

            //Dish burgerVegan = new Dish(4, "Burger Vegan");
            //burgerVegan.Recipe.Add(preparePoisson);
            //burgerVegan.Recipe.Add(prepareVegetables);
            //burgerVegan.Recipe.Add(prepareCheddar);
            //burgerVegan.Recipe.Add(prepareRaclette);
            //burgerVegan.Recipe.Add(assemblerBurger);

            DomainApp domainApp = new DomainApp();

            Console.WriteLine("Instanciation du Controller sans problèmes");
        }


        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
