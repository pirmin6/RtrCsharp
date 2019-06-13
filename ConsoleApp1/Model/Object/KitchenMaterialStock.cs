using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    public class KitchenMaterialStock
    {
        int positionX = 950;
        int positionY = 100;
        int width = 50;
        int height = 100;
        static Image image = Image.FromFile("C:/asset/Object/MaterialStock.png");

        Sprite sprite;


        public KitchenMaterialStock() { sprite = new Sprite(image, positionX, positionY, width, height); }

        public Sprite Sprite { get => sprite; }
    }
}
