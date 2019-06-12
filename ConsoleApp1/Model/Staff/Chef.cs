using Commun;
using ConsoleApp1.Model;
using ConsoleApp1.Model.Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Chef : IObserver
    {
        public int xPositionInit = 200;
        public int yPositionInit = 100;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageChef = Image.FromFile("C:/asset/Staff/chef.png");

        Sprite sprite;

        List<CommandePaquet> listWaitCommande;
        List<Cooker> listCuisiniers;


        public Chef(Cooker cuisinier1, Cooker cuisinier2)
        {
            sprite = new Sprite(imageChef, xPositionInit, yPositionInit, widthInit, heightInit);

            listCuisiniers = new List<Cooker>();
            listCuisiniers.Add(cuisinier1);
            listCuisiniers.Add(cuisinier2);
        }
        
        // Méthodes qui permet d'attribuer le travail aux cuisiniers
        private void WorkScheduling()
        {
            
        }

        public void update(Desk observable, string message)
        {
            for (int i = 0; i < observable.ListCommandeGet.Count; i++)
            {
                this.listWaitCommande.Add(observable.ListCommandeGet.ElementAt(i));
            }
        }


        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
