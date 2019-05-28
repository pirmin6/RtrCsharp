using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp1.Model;
using ConsoleApp1.View;


namespace ConsoleApp1
{
    class Program
    {
        public static App appModel;
        static void Main(string[] args)
        {
            Console.WriteLine("projet Cuisine");

            //Cuisine maCuisine = new Cuisine(); 

            appModel = new App();
            Application.Run(new Cuisine());

            Console.ReadKey();
        }
    }
}
