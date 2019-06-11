using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Model.Object;

namespace ConsoleApp2.Model.Object
{


    public class Order
    {
        private int idTable;
        List<Dish> Dishes;

        public Order(int idTable, List<Dish> Dishes)
        {
            this.idTable = idTable;
            this.Dishes = Dishes;
        }

        public int IdTable { get => idTable; set => idTable = value; }
        public List<Dish> Dishes1 { get => Dishes; set => Dishes = value; }
    }
}
