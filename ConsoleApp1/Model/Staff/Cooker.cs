using ConsoleApp1.Domain;
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
    public class Cooker
    {

        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image imageChefSection = Image.FromFile("C:/asset/Staff/chef-section.png");
        Sprite sprite;

        private List<Clerk> commisList;
        private Boolean isWorking;
        private KitchenMaterialStock materialStock; private IngredientStock ingredientStock; private Fridge fridge;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public Cooker(Clerk commis1, Clerk commis2, KitchenMaterialStock materialStock, IngredientStock ingredientStock, Fridge fridge)
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            firstInstanciated = nbrInstanciated == 1;
            if (firstInstanciated)
            {
                xPositionInit = 200;
                yPositionInit = 200;
            }
            else
            {
                xPositionInit = 300;
                yPositionInit = 200;
            }

            commisList = new List<Clerk>();
            commisList.Add(commis1);
            commisList.Add(commis2);

            this.materialStock = materialStock; this.ingredientStock = ingredientStock; this.fridge = fridge;

            // Creationn du Sprite rattaché au cuisinier
            sprite = new Sprite(imageChefSection, xPositionInit, yPositionInit, widthInit, heightInit);

            isWorking = false;
        }

        public void MakeDish(int idDish)
        {
            //isWorking = true;
            
            for (int i = 0; i <  DomainApp.Menu.Count; i++)
            {
                if (DomainApp.Menu.ElementAt(i).IdDish == idDish)
                {
                    Console.WriteLine("Le cuisiner récupère la recette pour plat commandé");
                    for (int j = 0; j < DomainApp.Menu.ElementAt(i).Recipe.Count; j++)
                    {
                        Console.WriteLine("Le cuisinier fait l'étape numéro {0} de la recette", j);
                        MakeDishStep(DomainApp.Menu.ElementAt(i).Recipe.ElementAt(j));
                    }
                }
            }

            // Il a finit il ne travaille plus
            isWorking = false;
        }

        public void MakeDishStep(RecipeStep step)
        {
            if (step.PeelIngredient == true)
            {
                Console.WriteLine("L'étape consiste à éplucher des aliments");
                Clerk commisEpluche = ChooseClerk();
                Console.WriteLine("Le cuisinier choisis un commis pour s'en occuper");

                //lancer la méthode dans le commit
                Thread th = new Thread(new ParameterizedThreadStart(commisEpluche.Peel));
                th.Start(step);
                
            }
            else
            {
                Console.WriteLine("Le cuisinier va chercher les ustencils dont il a besoin");
                // chercher ustencils
                this.SearchUstencils(step, this.Sprite.PositionX, this.Sprite.PositionY);
                

                //Move
                Clerk commisIngredient = ChooseClerk();
                commisIngredient.IsWorking = true;

                Thread th = new Thread(() => commisIngredient.SearchIngredient(step, this.Sprite.PositionX, this.Sprite.PositionY));

                Thread.Sleep(step.TimeToCook);
                commisIngredient.IsWorking = false;

                this.ReleaseUstencils(step, this.Sprite.PositionX, this.Sprite.PositionY);
            }
        }

        private Clerk ChooseClerk()
        {
            while (true)
            {
                for (int i = 0; i < commisList.Count; i++)
                {
                    if (commisList.ElementAt(i).IsWorking == false) return commisList.ElementAt(i);
                }
            }
        }

        public void SearchUstencils(RecipeStep step, int backX, int backY)
        {
            this.Sprite.Move(materialStock.Sprite.PositionX, materialStock.Sprite.PositionY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).getMaterial();
                Console.WriteLine("Le Cuisinier a besoin de l'ustencil : {0}", step.ListUstencils.ElementAt(i).getName());
                Console.WriteLine("Il ne reste plus que {0} {1} dans le Stock de Materiel", step.ListUstencils.ElementAt(i).getnbrItemAvailable(), step.ListUstencils.ElementAt(i).getName());
            }

            Thread.Sleep(1000);
            this.Sprite.Move(backX, backY);
        }

        public void ReleaseUstencils(RecipeStep step, int backX, int backY)
        {
            //this.Sprite.Move(backX, backY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).releaseMaterial();
            }

            Thread.Sleep(500);
            this.Sprite.Move(backX, backY);
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
    }
}
