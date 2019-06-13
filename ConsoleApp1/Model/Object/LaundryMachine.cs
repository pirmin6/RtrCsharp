using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    public class LaundryMachine
    {
        int positionX = 800;
        int positionY = 0;
        int width = 100;
        int height = 100;
        static Image image = Image.FromFile("C:/asset/Object/laundry-washer.png");

        Sprite sprite;


        public LaundryMachine() { sprite = new Sprite(image, positionX, positionY, width, height);  }

        internal Sprite Sprite { get => sprite; }
    }
}
