using Commun;
using ConsoleApp1.Model;
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
    public class Chef : IObserver
    {
        public int xPositionInit = 200;
        public int yPositionInit = 100;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageChef = Image.FromFile("C:/asset/Staff/chef.png");

        Sprite sprite;

        Queue<CommandePaquet> waitCommande;
        List<Cooker> listCuisiniers;
        private Desk kitchenDesk;


        public Chef(Cooker cuisinier1, Cooker cuisinier2, Desk kitchenDesk)
        {
            sprite = new Sprite(imageChef, xPositionInit, yPositionInit, widthInit, heightInit);

            waitCommande = new Queue<CommandePaquet>();
            listCuisiniers = new List<Cooker>();
            listCuisiniers.Add(cuisinier1);
            listCuisiniers.Add(cuisinier2);

            this.kitchenDesk = kitchenDesk;

            Thread thWorkScheduling = new Thread(WorkScheduling);
            thWorkScheduling.Start();
        }
        
        // Méthodes qui permet d'attribuer le travail aux cuisiniers
        private void WorkScheduling()
        {

            Console.WriteLine("Le Chef de Cuisine récupère les commandes et assigne les plats à ses cuisiniers");
            while (true)
            {
                while (waitCommande.Count > 0)
                {
                    CommandePaquet commande = waitCommande.Peek();

                    foreach (int init in commande.ListPlats)
                    {
                        Console.WriteLine(commande.ListPlats.Count);
                        Thread th = new Thread(() => this.ChooseCooker().MakeDish(commande.ListPlats[init -1]));
                        th.Start();
                    }
                    
                    kitchenDesk.ListCommandeSend.Add(waitCommande.Peek());
                    waitCommande.Dequeue();
                }
                


            }
        }

        private Cooker ChooseCooker()
        {
            while (true)
            {
                for (int i = 0; i < listCuisiniers.Count; i++)
                {
                    if (listCuisiniers.ElementAt(i).IsWorking == false)
                    {
                        Console.WriteLine("Le Chef assigne le plat a un cuisinier");
                        listCuisiniers.ElementAt(i).IsWorking = true;
                        return listCuisiniers.ElementAt(i);
                    }
                }
            }
        }

        public void update(Desk observable, string message)
        {
            for (int i = 0; i < observable.ListCommandeGet.Count; i++)
            {
                Console.WriteLine("Le chef ajoute cette nouvelle commande à sa liste d'attente");
                this.waitCommande.Enqueue(observable.ListCommandeGet.ElementAt(i));
            }
        }


        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
