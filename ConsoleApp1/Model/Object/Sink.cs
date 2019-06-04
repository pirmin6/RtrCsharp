using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class Sink
    {
        int positionX = 500;
        int positionY = 0;
        int width = 200;
        int height = 100;
        static Image sinkImage = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Object/kitchen-sink.png");

        Sprite spriteSink;

        public Sink() { spriteSink = new Sprite(sinkImage, positionX, positionY, width, height); }

        internal Sprite SpriteSink { get => spriteSink; set => spriteSink = value; }
    }
}
