using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Plunger
    {
        public float xPositionInit;
        public float yPositionInit;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imagePlunger = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef.png");

        Sprite spritePlunger;



        public Plunger()
        {
            this.positionRandom();
            spritePlunger = new Sprite(imagePlunger, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        public void positionRandom()
        {
            Random aleatoire = new Random();
            xPositionInit = aleatoire.Next(0, 1000);
            yPositionInit = aleatoire.Next(0, 600);
        }

        internal Sprite SpritePlunger { get => spritePlunger; set => spritePlunger = value; }
    }
}
