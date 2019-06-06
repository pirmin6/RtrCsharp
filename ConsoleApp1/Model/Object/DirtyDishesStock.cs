using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class DirtyDishesStock
    {
        int positionX = 450;
        int positionY = 0;
        int width = 50;
        int height = 100;
        static Image image = Image.FromFile("C:/asset/Object/dirty-dishes-stock.png");

        Sprite sprite;


        public DirtyDishesStock() { sprite = new Sprite(image, positionX, positionY, width, height);  }

        public Sprite Sprite { get => sprite;}
    }
}
