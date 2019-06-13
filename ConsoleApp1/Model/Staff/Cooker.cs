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
        private string name;
        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image imageChefSection = Image.FromFile("C:/asset/Staff/chef-section.png");
        Sprite sprite;

        private List<Clerk> commisList;
        private Boolean isWorking;
        private KitchenMaterialStock materialStock; private IngredientStock ingredientStock; private Fridge fridge;
        private static Mutex mutex_lock = new Mutex();

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public Cooker(Clerk commis1, Clerk commis2, KitchenMaterialStock materialStock, IngredientStock ingredientStock, Fridge fridge, string name)
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

            this.materialStock = materialStock; this.ingredientStock = ingredientStock; this.fridge = fridge; this.name = name;

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
                    Console.WriteLine("{0} récupère la recette pour plat commandé", name);
                    Console.WriteLine("Il y a {0} étapes dans la recette", DomainApp.Menu.ElementAt(i).Recipe.Count);

                    for (int j = 0; j < DomainApp.Menu.ElementAt(i).Recipe.Count; j++)
                    {
                        Console.WriteLine("{0} fait l'étape numéro {1} de la recette", name, j);
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
                Thread.Sleep(500);

                mutex_lock.WaitOne();
                Clerk commisEpluche = ChooseClerk();
                mutex_lock.ReleaseMutex();


                //lancer la méthode dans le commit
                Thread th = new Thread(() => commisEpluche.Peel(step));
                th.Start();
                
            }
            else
            {
                Console.WriteLine("{0} va chercher les ustencils dont il a besoin");
                // chercher ustencils
                if (step.ListUstencils.Count != 0) this.SearchUstencils(step, this.Sprite.PositionX, this.Sprite.PositionY);

                mutex_lock.WaitOne();
                Clerk commisIngredient = ChooseClerk();
                mutex_lock.ReleaseMutex();

                Thread th = new Thread(() => commisIngredient.SearchIngredient(step, this.Sprite.PositionX, this.Sprite.PositionY));
                th.Start();
                //th.Join();
                Console.WriteLine("{0} a finis de chercher les ingrédients pour le cuisiniers il est disponible..", commisIngredient.Name);
                commisIngredient.IsWorking = false;

                //Cuisine et repose les ustencils
                Thread.Sleep(step.TimeToCook);
                if (step.ListUstencils.Count != 0) this.ReleaseUstencils(step, this.Sprite.PositionX, this.Sprite.PositionY);
            }
        }

        private Clerk ChooseClerk()
        {
            while (true)
            {
                for (int i = 0; i < commisList.Count; i++)
                {
                    if (commisList.ElementAt(i).IsWorking == false)
                    {
                        Console.WriteLine("{0} assigne le travail a {1}", name, commisList.ElementAt(i).Name);
                        commisList.ElementAt(i).IsWorking = true;
                        return commisList.ElementAt(i);
                    }
                }
            }
        }

        //private Clerk ChooseClerk()
        //{
        //    while (true)
        //    {
        //        bool commisTrouver = false;
        //        Clerk monCommis;

        //        mutex_lock.WaitOne();
        //        while (true)
        //        {
        //            for (int i = 0; i < commisList.Count; i++)
        //            {
        //                if (commisList.ElementAt(i).IsWorking == false)
        //                {
        //                    Console.WriteLine("{0} assigne le travail a {1}", name, commisList.ElementAt(i).Name);
        //                    commisList.ElementAt(i).IsWorking = true;
        //                    return commisList.ElementAt(i);
        //                    commisTrouver = true;

        //                }
        //            }
        //        }
        //        mutex_lock.ReleaseMutex();
        //        //return monCommis;
        //    }

        //}

        public void SearchUstencils(RecipeStep step, int backX, int backY)
        {
            this.Sprite.Move(materialStock.Sprite.PositionX, materialStock.Sprite.PositionY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).getMaterial();
                Console.WriteLine("{0} a besoin de l'ustencil : {1}", name, step.ListUstencils.ElementAt(i).getName());
                //Console.WriteLine("Il ne reste plus que {0} {1} dans le Stock de Materiel", step.ListUstencils.ElementAt(i).getnbrItemAvailable(), step.ListUstencils.ElementAt(i).getName());
            }

            Thread.Sleep(100);
            this.Sprite.Move(backX, backY);
        }

        public void ReleaseUstencils(RecipeStep step, int backX, int backY)
        {
            this.Sprite.Move(materialStock.Sprite.PositionX, materialStock.Sprite.PositionY);
            for (int i = 0; i < step.ListUstencils.Count; i++)
            {
                step.ListUstencils.ElementAt(i).releaseMaterial();
                Console.WriteLine("{0} replace l'ustencil : {1}", name, step.ListUstencils.ElementAt(i).getName());
                //Console.WriteLine("Il y a {0} {1} dans le Stock de Materiel", step.ListUstencils.ElementAt(i).getnbrItemAvailable(), step.ListUstencils.ElementAt(i).getName());
            }

            Thread.Sleep(100);
            this.Sprite.Move(backX, backY);
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
        public string Name { get => name; set => name = value; }
    }
}
