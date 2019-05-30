﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Staff
{
    class ChefSection
    {

        public float xPositionInit = 100;
        public float yPositionInit = 200;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image imageChefSection = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef-section.png");

        Sprite spriteChefSection;



        public ChefSection()
        {
            //this.positionRandom();
            spriteChefSection = new Sprite(imageChefSection, xPositionInit, yPositionInit, widthInit, heightInit);
            spriteChefSection.Move();
        }

        public void positionRandom()
        {
            Random aleatoire = new Random();
            xPositionInit = aleatoire.Next(0, 1000);
            yPositionInit = aleatoire.Next(0, 600);
            aleatoire = null;
        }

        internal Sprite SpriteChefSection { get => spriteChefSection; set => spriteChefSection = value; }
    }
}
