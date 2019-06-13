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
                if (waitCommande.Count != 0)
                {
                    foreach(int init in waitCommande.Peek().ListPlats)
                    {
                        Cooker cuisinierChoisis = this.ChooseCooker();
                        Console.WriteLine(waitCommande.Peek().ListPlats.Count);
                        Thread th = new Thread(() => cuisinierChoisis.MakeDish(waitCommande.Peek().ListPlats[init]));
                        th.Start();
                        
                    }
                    Thread.Sleep(1000);
                    kitchenDesk.ListCommandeSend.Add(waitCommande.Peek());
                    waitCommande.Dequeue();
                }
                else
                {
                    //Console.WriteLine("La file d'attente des commandes est nulle");
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
