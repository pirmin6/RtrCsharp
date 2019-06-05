using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoomProject.Model.Staff
{
    class RankLeader
    {
        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image image = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef-rang.png");

        Sprite sprite;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        public RankLeader()
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 Chef de Rang");

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

            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);
        }
        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
