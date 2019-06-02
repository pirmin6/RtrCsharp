using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class Sprite
    {
        private float xPosition, yPosition;
        private int Width, Height;
        private Image spriteImage;
        public Sprite(Image sprite, float x, float y, int width, int height)
        {
            Width = width;
            Height = height;
            xPosition = x;
            yPosition = y;
            spriteImage = sprite;
        }

        public void Move()
        {
            for (int i = 0; i < 500; i++)
            {
                xPosition = xPosition + 1;
                Console.WriteLine("Il Avance de 1");
                Console.WriteLine(xPosition);
                //Thread.Sleep(100);
            }
            
        }


        public int getHeight
        {
            get
            {
                return this.Height;
            }
        }

        public float getX
        {
            get
            {
                return this.xPosition;
            }
            set
            {
                this.xPosition = value;
            }
        }

        public float getY
        {
            get
            {
                return this.yPosition;
            }
            set
            {
                this.yPosition = value;
            }
        }

        public Image getImage
        {
            get
            {
                return this.spriteImage;
            }
        }

        public int getWidth { get => Width; set => Width = value; }
    }

    

}
