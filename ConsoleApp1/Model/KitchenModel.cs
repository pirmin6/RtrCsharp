﻿using ConsoleApp1.Model.Object;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenProject.Model
{
    public class KitchenModel
    {
        private List<Sprite> personnel;
        private List<Sprite> objects;
        public KitchenModel()
        {
            personnel = new List<Sprite>();
            objects = new List<Sprite>();

            Chef monChef = new Chef();
            ChefSection monChefSection = new ChefSection();
            Plunger monPlongeur = new Plunger();

            Desk kitchenDesk = new Desk();
            Sink kitchenSink = new Sink();
            

            //Thread thChefSection = new Thread(createChefSection);
            //thChefSection.Start();

            personnel.Add(monChef.SpriteChef);
            personnel.Add(monChefSection.SpriteChefSection);
            personnel.Add(monPlongeur.SpritePlunger);

            objects.Add(kitchenDesk.SpriteDesk);
            objects.Add(kitchenSink.SpriteSink);

            Console.WriteLine(personnel.Count);


            
        }

        public void createChefSection()
        {
            ChefSection monChefSection2 = new ChefSection();
            personnel.Add(monChefSection2.SpriteChefSection);
        }

        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
