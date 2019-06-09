using KitchenProject.Model;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class Desk : Observable
    {
        int positionX = 100;
        int positionY = 100;
        int width = 100;
        int height = 500;
        static Image image = Image.FromFile("C:/asset/Object/comptoir-cuisine.png");

        Sprite sprite;

        public Desk(Chef chef, Plunger plunger)
        {
            //Ajoute les Observer à Desk
            this.AttachChef(chef);
            this.AttachPlunger(plunger);

            sprite = new Sprite(image, positionX, positionY, width, height);
        }

        internal Sprite Sprite { get => sprite;}
    }
}
