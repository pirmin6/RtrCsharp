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
            HeatingPlate plaque1 = new HeatingPlate();
            HeatingPlate plaque2 = new HeatingPlate();
            HeatingPlate plaque3 = new HeatingPlate();
            Dishwasher laveVaisselle = new Dishwasher();
            LaundryMachine laveLinge = new LaundryMachine();
            DishesStock stockVaisselle = new DishesStock();
            DirtyDishesStock stockVaiselleSale = new DirtyDishesStock();

            objects.Add(kitchenDesk.Sprite);
            objects.Add(kitchenSink.Sprite);
            objects.Add(plaque1.Sprite);
            objects.Add(plaque2.Sprite);
            objects.Add(plaque3.Sprite);
            objects.Add(laveVaisselle.Sprite);
            objects.Add(laveLinge.Sprite);
            objects.Add(stockVaisselle.Sprite);
            objects.Add(stockVaiselleSale.Sprite);
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


            Console.WriteLine("Instanciation du Controller sans problèmes");
        }


        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
