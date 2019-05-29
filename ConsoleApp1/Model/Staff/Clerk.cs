using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Staff
{
    class Clerk
    {

        public float xPositionInit;
        public float yPositionInit;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageClerk = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef.png");

        Sprite spriteClerk;



        public Clerk()
        {
            this.positionRandom();
            spriteClerk = new Sprite(imageClerk, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        public void positionRandom()
        {
            Random aleatoire = new Random();
            xPositionInit = aleatoire.Next(0, 1000);
            yPositionInit = aleatoire.Next(0, 600);
        }

        internal Sprite SpriteClerk { get => spriteClerk; set => spriteClerk = value; }
    }
}
