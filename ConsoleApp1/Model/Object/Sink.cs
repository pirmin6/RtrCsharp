using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    public class Sink
    {
        int positionX = 500;
        int positionY = 0;
        int width = 200;
        int height = 100;
        static Image image = Image.FromFile("C:/asset/Object/kitchen-sink.png");

        Sprite sprite;

        public Sink() { sprite = new Sprite(image, positionX, positionY, width, height); }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
