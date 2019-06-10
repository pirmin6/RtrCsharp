using ConsoleApp1.Model.Object;
using ConsoleApp1.Socket;
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
            SocketApp socket = new SocketApp();


            personnel = new List<Sprite>();
            objects = new List<Sprite>();


            Plunger plongeur = new Plunger();
            Clerk commis1 = new Clerk();
            Clerk commis2 = new Clerk();
            Cooker cuisinier1 = new Cooker(commis1, commis2);
            Cooker cuisinier2 = new Cooker(commis1, commis2);
            Chef chef = new Chef(cuisinier1 , cuisinier2);
            

            personnel.Add(chef.Sprite);
            personnel.Add(cuisinier1.Sprite);
            personnel.Add(cuisinier2.Sprite);
            personnel.Add(commis1.Sprite);
            personnel.Add(commis2.Sprite);
            personnel.Add(plongeur.Sprite);



            Desk kitchenDesk = new Desk(chef, plongeur, socket);
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

 
            Console.WriteLine("Instanciation du Controller sans problèmes");
        }


        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
