using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenProject.Model.Staff
{
    class Cooker
    {

        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image imageChefSection = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef-section.png");
        Sprite sprite;

        private List<Clerk> commisList;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public Cooker(Clerk commis1, Clerk commis2)
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            firstInstanciated = nbrInstanciated == 1;
            if (firstInstanciated)
            {
                xPositionInit = 200;
                yPositionInit = 200;
            }
            else
            {
                xPositionInit = 300;
                yPositionInit = 200;
            }

            commisList = new List<Clerk>();
            commisList.Add(commis1);
            commisList.Add(commis2);
            // Creationn du Sprite rattaché au cuisinier
            sprite = new Sprite(imageChefSection, xPositionInit, yPositionInit, widthInit, heightInit);

            Thread deplacement = new Thread(sprite.Move);
            deplacement.Start();
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
