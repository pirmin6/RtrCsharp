using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KitchenProject.Controller;
using KitchenProject.Model;
using KitchenProject.View;


namespace KitchenProject
{
    class KitchenApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("projet Cuisine");
            
            KitchenModel kitchenModel = new KitchenModel();

            KitchenView kitchenView = new KitchenView(kitchenModel);

            KitchenController kitchenController = new KitchenController(kitchenModel, kitchenView);

            Thread th = new Thread(kitchenModel.socket.testCuisine);
            th.Start();


            Application.Run(kitchenView);


            Console.ReadKey();
        }
    }
}
