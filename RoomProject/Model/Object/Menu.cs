using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Object
{
    public class Menu : Observable
    {
        private List<Dish> plats = new List<Dish>();

        public Menu()
        {
            Plats.Add(new Dish(1, "kouloutou"));
            Plats.Add(new Dish(2, "Coquillette du auchan"));
            Plats.Add(new Dish(3, "le grec du mec du yilmaz qui bombarde"));

        }

        public List<Dish> Plats { get => plats; set => plats = value; }
    }
}
