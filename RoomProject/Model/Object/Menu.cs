using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Object
{
    public class Menu
    {
        List<Dish> menu;
        public Menu()
        {
            menu = new List<Dish>();

            menu.Add(new Dish(1, "Burger Classique"));
            menu.Add(new Dish(2, "Burger Poulet"));
            menu.Add(new Dish(3, "Burger Montagnard"));
            menu.Add(new Dish(4, "Burger Vegan"));



        }

        public List<Dish> Menu1 { get => menu; set => menu = value; }
    }
}
