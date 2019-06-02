using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenProject.Model
{
    class Sprite
    {
        private float positionX;
        private float positionY;
        private int width;
        private int height;
        private Image spriteImage;
        public Sprite(Image spriteImage, float positionX, float positionY, int width, int height)
        {
            this.Width = width; this.Height = height; this.PositionX = positionX; this.PositionY = positionY; this.SpriteImage = spriteImage;
        }

        public void Move()
        {
            for (int i = 0; i < 500; i++)
            {
                PositionX = PositionX + 1;
                //Console.WriteLine("Il Avance de 1");
                //Console.WriteLine(xPosition);
                Thread.Sleep(10);
            }

        }

        public float PositionX { get => positionX; set => positionX = value; }
        public float PositionY { get => positionY; set => positionY = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Image SpriteImage { get => spriteImage; set => spriteImage = value; }
    }
}
