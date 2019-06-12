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
        private int positionX;
        private int positionY;
        private int width;
        private int height;
        private Image spriteImage;
        Rectangle hitbox;

        public Sprite(Image spriteImage, int positionX, int positionY, int width, int height)
        {
            this.Width = width; this.Height = height; this.PositionX = positionX; this.PositionY = positionY; this.SpriteImage = spriteImage;

            Hitbox = new Rectangle(PositionX, PositionY, Width, Height);
        }

        public void Move(int x, int y)
        {
            while (positionX != x && positionY != y)
            {
                while (positionY != y)
                {
                    if (positionX < x)
                    {
                        positionX++;

                    }

                    if (positionY < y)
                    {
                        PositionY++;
                    }

                    if (positionX > x)
                    {
                        positionX--;

                    }

                    if (positionY > y)
                    {
                        PositionY--;
                    }

                    Thread.Sleep(20);
                }

            }
        }


        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Image SpriteImage { get => spriteImage; set => spriteImage = value; }
        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }
    }
}
