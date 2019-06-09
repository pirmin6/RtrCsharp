using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class DishesStock
    {
        int positionX = 900;
        int positionY = 0;
        int width = 100;
        int height = 100;
        static Image image = Image.FromFile("C:/asset/Object/dishes-stock.png");

        Sprite sprite;

     
        public DishesStock() { sprite = new Sprite(image, positionX, positionY, width, height);  }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
