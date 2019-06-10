
using ConsoleApp1.Model;
using ConsoleApp1.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Plunger : IObserver
    {
        public int xPositionInit = 300;
        public int yPositionInit = 400;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/plunger.png");

        private Sprite sprite;

        public Plunger()
        {
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

        public void SearchMaterial(string type, int quantity)
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
        }

        public void update(Observable observable, string message)
        {
            //Move jusqu'à Desk
        
            switch (message)
            {
                case ("DemandMaterial"):
                    for (int i = 0; i < observable.ListMaterialDemander.Count; i++)
                    {
                        this.SearchMaterial(observable.ListMaterialDemander.ElementAt(i).Material, observable.ListMaterialDemander.ElementAt(i).Quantity);
                    }
                    break;
                case ("MaterialSale"):

                    break;
            }
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }

    }
}
