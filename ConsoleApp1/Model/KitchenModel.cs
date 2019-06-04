using ConsoleApp1.Model.Object;
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



            Desk kitchenDesk = new Desk();
            Sink kitchenSink = new Sink();

            objects.Add(kitchenDesk.SpriteDesk);
            objects.Add(kitchenSink.SpriteSink);
            //Thread thChefSection = new Thread(createChefSection);
            //thChefSection.Start();

            Chef chef = new Chef();
            Clerk commis1 = new Clerk();
            Clerk commis2 = new Clerk();
            Cooker cuisinier1 = new Cooker(commis1, commis2);
            Cooker cuisinier2 = new Cooker(commis1, commis2);
            Plunger plongeur = new Plunger();

            personnel.Add(chef.Sprite);
            personnel.Add(cuisinier1.Sprite);
            personnel.Add(cuisinier2.Sprite);
            personnel.Add(commis1.Sprite);
            personnel.Add(commis2.Sprite);
            personnel.Add(plongeur.Sprite);



            Console.WriteLine(personnel.Count);


            
        }


        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
