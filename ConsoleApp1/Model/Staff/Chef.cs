using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Staff
{
    class Chef
    {
        public float xPositionInit = 250;
        public float yPositionInit = 450;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageChef = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef.png");

        Sprite spriteChef;

        

        public Chef()
        {
            SpriteChef = new Sprite(imageChef, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        internal Sprite SpriteChef { get => spriteChef; set => spriteChef = value; }
    }
}
