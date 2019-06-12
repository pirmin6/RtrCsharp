
using ConsoleApp1.Model;
using ConsoleApp1.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model.Object;

using Commun;

namespace KitchenProject.Model.Staff
{
    class Plunger : IObserver
    {
        public int xPositionInit = 300;
        public int yPositionInit = 400;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/plunger.png");

        Desk kitchenDesk;
        DirtyDishesStock stockVaisselleSale;
        DishesStock stockVaisselle;
        Dishwasher laveVaisselle;
        LaundryMachine laveLinge;
        Sink kitchenSink;

        private Sprite sprite;

        public Plunger(Desk kitchenDesk, DirtyDishesStock stockVaisselleSale, DishesStock stockVaisselle, Dishwasher laveVaisselle, LaundryMachine laveLinge, Sink kitchenSink)
        {
            this.kitchenDesk = kitchenDesk;
            this.stockVaisselleSale = stockVaisselleSale;
            this.stockVaisselle = stockVaisselle;
            this.laveVaisselle = laveVaisselle;
            this.laveLinge = laveLinge;
            this.kitchenSink = kitchenSink;

            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        public void WashDishes()
        {

        }

        public void WashMaterial()
        {

        }

        public void Peel()
        {

        }

        public void SearchMaterial(int idTable, string type, int quantity)
        {
            switch (type)
            {
                case ("SmallPlate"):
                    for (int i = 0; i < quantity; i++)
                    {
                        SmallPLate.getVaiselle();
                    }
                    Console.WriteLine("Il y a {0} petites assiettes", SmallPLate.getnbrItemAvailable());
                    break;
            }
            MaterialPaquet ap = new MaterialPaquet(idTable, type, quantity);
            kitchenDesk.ListMaterialSend.Add(ap);
        }

        public void update(Desk observable, string message)
        {
            //Move jusqu'à Desk
        
            switch (message)
            {
                case ("DemandMaterial"):
                    for (int i = 0; i < observable.ListMaterialGet.Count; i++)
                    {
                        this.SearchMaterial(observable.ListMaterialGet.ElementAt(i).IdTable, observable.ListMaterialGet.ElementAt(i).TypeMaterial, observable.ListMaterialGet.ElementAt(i).Quantity);
                    }
                    break;
                case ("DirtyMaterial"):
                    for (int i = 0; i < observable.ListDirtyMaterial.Count; i++)
                    {

                        this.SearchMaterial(observable.ListDirtyMaterial.ElementAt(i).IdTable, observable.ListDirtyMaterial.ElementAt(i).TypeMaterial, observable.ListDirtyMaterial.ElementAt(i).Quantity);
                    }
                    break;
            }
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }

    }
}
