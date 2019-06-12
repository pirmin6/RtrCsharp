using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class IngredientStock
    {
        int positionX = 900;
        int positionY = 200;
        int width = 100;
        int height = 200;
        static Image image = Image.FromFile("C:/asset/Object/refrigerator-empty.png");

        Sprite sprite;


        public IngredientStock() { sprite = new Sprite(image, positionX, positionY, width, height); }

        public Sprite Sprite { get => sprite; }
    }
}
