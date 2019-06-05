using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Chef
    {
        public int xPositionInit = 200;
        public int yPositionInit = 100;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageChef = Image.FromFile("C:/asset/Staff/chef.png");

        Sprite sprite;

        

        public Chef()
        {
            sprite = new Sprite(imageChef, xPositionInit, yPositionInit, widthInit, heightInit);
        }


        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
