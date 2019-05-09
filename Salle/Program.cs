using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controler;



namespace Salle
{
    internal class Program
    {
        private static void Main(string[] args)
        {


            SalleCreationController Salle = new SalleCreationController();

            SalleCreationController SalleController = new SalleCreationController();

           
            SalleSimulationController ClientController = new SalleSimulationController(SalleController.monMaitre);


            Console.ReadKey();

        }

    }
}
