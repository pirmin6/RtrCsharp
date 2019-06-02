using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1.Model;
using ConsoleApp1.View;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("projet Cuisine");

            appModel monModel = new appModel();

            Application.Run(new CuisineView(monModel));

            //Console.ReadKey();
            /*
            Thread[] spriteThread = new Thread[monModel.Personnel.Count()]; 


            for (int j = 0; j < monModel.Personnel.Count(); j++)
            {
                spriteThread[j] = new Thread(monModel.Personnel.ElementAt(j).Move);
                spriteThread[j].Start();
            }

            Console.WriteLine("nombre de ligne dans le tableau de Threads : {0}", spriteThread.Count());
            */
                Console.ReadKey();
        }
    }
}
