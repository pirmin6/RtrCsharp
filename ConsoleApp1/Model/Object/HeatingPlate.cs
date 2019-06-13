using KitchenProject.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    public class HeatingPlate
    {

        public int xPosition;
        public int yPosition;
        public int width = 200;
        public int height = 100;
        static Image image;

        Sprite sprite;

        private static int nbrInstanciated = 0;

        //private Boolean firstInstanciated;


        public HeatingPlate()
        {
            nbrInstanciated++;
            if (nbrInstanciated > 3) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            switch (nbrInstanciated)
            {
                case 1:
                    xPosition = 400;
                    yPosition = 300;
                    image = Image.FromFile("C:/asset/Object/plaque-left.png");
                    break;

                case 2:
                    xPosition = 600;
                    yPosition = 300;
                    image = Image.FromFile("C:/asset/Object/plaque-right.png");
                    break;

                case 3:
                    xPosition = 600;
                    yPosition = 200;
                    image = Image.FromFile("C:/asset/Object/plaque-right-up.png");
                    break;
            }

  
            sprite = new Sprite(image, xPosition, yPosition, width, height);
        }

        internal Sprite Sprite { get => sprite; }
    }
}
