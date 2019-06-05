using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Clerk
    {

        public int xPositionInit;
        public int yPositionInit;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/clerk.png");

        Sprite sprite;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public Clerk()
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            firstInstanciated = nbrInstanciated == 1;
            if (firstInstanciated)
            {
                xPositionInit = 200;
                yPositionInit = 300;
            }
            else
            {
                xPositionInit = 300;
                yPositionInit = 300;
            }
            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        internal Sprite Sprite { get => sprite; }
    }
}
