
using ConsoleApp1.Model;
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

        public void update(Observable observable)
        {

        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
