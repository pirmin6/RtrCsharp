using ConsoleApp1.Domain.Recipe;
using ConsoleApp1.Model.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    public class Clerk
    {

        public int xPositionInit;
        public int yPositionInit;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/clerk.png");

        Sprite sprite;
        private Boolean isWorking;
        private KitchenMaterialStock materialStock; private IngredientStock ingredientStock; private Fridge fridge; private Sink evier;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public Clerk(KitchenMaterialStock materialStock, IngredientStock ingredientStock, Fridge fridge , Sink evier)
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            firstInstanciated = nbrInstanciated == 1;
            if (firstInstanciated)
            {
                xPositionInit = 200;
                yPositionInit = 300;
            }
            else
            {
                xPositionInit = 300;
                yPositionInit = 300;
            }

            this.materialStock = materialStock; this.ingredientStock = ingredientStock; this.fridge = fridge; this.evier = evier;
            IsWorking = false;

            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        public void Peel(RecipeStep step)
        {
            // Cherche les ingrédinets nécessaires
            this.SearchIngredient(step, sprite.PositionX, sprite.PositionY);

            // Cherches les ustencils nécessaires
            this.SearchUstencils(step, sprite.PositionX, sprite.PositionY);


            // Va a l'évier pour couper
            this.Sprite.Move(evier.Sprite.PositionX, evier.Sprite.PositionY);
            Console.WriteLine("Le commis est entrain de {0}", step.Desc);

            Thread.Sleep(step.TimeToCook);

            // Replace les ustencils utilisés
            this.ReleaseUstencils(step, sprite.PositionX, sprite.PositionY);

            // Il est denouveau disponible pour travailler
            IsWorking = false;
        }

        public void SearchIngredient(RecipeStep step, int backX, int backY)
        {
            for (int i = 0; i < step.IngredientQuantities.Count; i++)
            {
                string localisationIngredient = step.IngredientQuantities.ElementAt(i).Ingredient.Localisation;

                if (localisationIngredient == "Réfrigérateur")
                {
                    Console.WriteLine("Le commis cherche {0} dans le {1}", step.IngredientQuantities.ElementAt(i).Ingredient.Name, localisationIngredient);
                    this.Sprite.Move(fridge.Sprite.PositionX, fridge.Sprite.PositionY);
                }
                if (localisationIngredient == "Stock d'Ingrédient")
                {
                    Console.WriteLine("Le commis cherche {0} dans le {1}", step.IngredientQuantities.ElementAt(i).Ingredient.Name, localisationIngredient);
                    this.Sprite.Move(ingredientStock.Sprite.PositionX, ingredientStock.Sprite.PositionY);
                }
            }
            Thread.Sleep(1000);
            this.sprite.Move(backX, backY);
        }

        public void SearchUstencils(RecipeStep step, int backX, int backY)
        {
            this.Sprite.Move(materialStock.Sprite.PositionX, materialStock.Sprite.PositionY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).getMaterial();
            }

            Thread.Sleep(1000);
            this.Sprite.Move(backX, backY);
        }

        public void ReleaseUstencils(RecipeStep step, int backX, int backY)
        {
            this.Sprite.Move(materialStock.Sprite.PositionX, materialStock.Sprite.PositionY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).releaseMaterial();
            }

            Thread.Sleep(1000);
            this.Sprite.Move(backX, backY);
        }


        internal Sprite Sprite { get => sprite; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
    }
}
