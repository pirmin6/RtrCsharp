using Commun;
using ConsoleApp1.Domain.Recipe;
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
        private static Mutex mutex_lock = new Mutex();

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
        //private void WorkScheduling()
        //{

        //    Console.WriteLine("Le Chef de Cuisine récupère les commandes et assigne les plats à ses cuisiniers");
        //    while (true)
        //    {
        //        while (waitCommande.Count > 0)
        //        {
        //            CommandePaquet commande = waitCommande.Peek();

        //            for (int i = 0; i < waitCommande.Peek().ListPlats.Count; i++)
        //            {
        //                int PlatsSend = waitCommande.Peek().ListPlats.ElementAt(i);
        //                //Console.WriteLine(commande.ListPlats.Count);
        //                Cooker cookerChoisis = this.ChooseCooker();
        //                Thread th = new Thread(() => cookerChoisis.MakeDish(PlatsSend));
        //                th.Start();
        //            }

        //            //kitchenDesk.ListCommandeSend.Add(waitCommande.Peek());
        //            waitCommande.Dequeue();
        //        }
        //        Thread.Sleep(100);
        //    }
        //}

        private void WorkScheduling()
        {

            Console.WriteLine("Le Chef de Cuisine récupère les commandes et assigne les plats à ses cuisiniers");
            while (true)
            {
                if (waitCommande.Count > 0)
                {
                    
                    //CommandePaquet commande = waitCommande.Peek();
                    Thread[] thPlats = new Thread[waitCommande.Peek().ListPlats.Count];

                    for (int i = 0; i < thPlats.Length; i++)
                    {
                        int PlatsSend = waitCommande.Peek().ListPlats.ElementAt(i);
                        Cooker cookerChoisis = this.ChooseCooker();
                        thPlats[i] = new Thread(() => cookerChoisis.MakeDish(PlatsSend));
                        thPlats[i].Start();
                    }
                    foreach (var thread in thPlats)
                    {
                        thread.Join();
                    }
                    kitchenDesk.ListCommandeSend.Add(waitCommande.Peek());
                    Console.WriteLine("Liste CommandeSend : {0}", kitchenDesk.ListCommandeSend.Count);
                    waitCommande.Dequeue();
                }
                Thread.Sleep(100);
            }
        }

        private Cooker ChooseCooker()
        {
            while (true)
            {
                mutex_lock.WaitOne();
                    for (int i = 0; i < listCuisiniers.Count; i++)
                    {
                        if (listCuisiniers.ElementAt(i).IsWorking == false)
                        {
                            Console.WriteLine("Le Chef assigne le plat a {0}", listCuisiniers.ElementAt(i).Name);
                            listCuisiniers.ElementAt(i).IsWorking = true;
                            mutex_lock.ReleaseMutex();
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
                var temp = observable.ListCommandeGet.ElementAt(i);
                this.waitCommande.Enqueue(temp);
                observable.ListCommandeGet.Clear();
            }
        }


        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
