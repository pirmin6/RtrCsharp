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
        static void Main(string[] args)
        {
            Console.WriteLine("projet Cuisine");

            appModel monModel = new appModel();

            Application.Run(new CuisineView(monModel));

            Console.ReadKey();
        }
    }
}
