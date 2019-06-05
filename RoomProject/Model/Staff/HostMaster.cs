using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoomProject.Model.Staff
{
    class HostMaster
    {
        public int xPositionInit = 200;
        public int yPositionInit = 100;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/maitre-hotel.png");

        Sprite sprite;

       
        public HostMaster()
        {
            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
