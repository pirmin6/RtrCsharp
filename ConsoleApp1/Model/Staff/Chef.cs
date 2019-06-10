using ConsoleApp1.Model;
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

        List<Cooker> listCuisiniers;


        public Chef(Cooker cuisinier1, Cooker cuisinier2)
        {
            sprite = new Sprite(imageChef, xPositionInit, yPositionInit, widthInit, heightInit);

            listCuisiniers = new List<Cooker>();
            listCuisiniers.Add(cuisinier1);
            listCuisiniers.Add(cuisinier2);
        }

        public void update(Observable observable, string message)
        {

        }


        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
