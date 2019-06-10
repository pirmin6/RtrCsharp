using ConsoleApp1.Socket;
using KitchenProject.Model;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Object
{
    class Desk : Observable
    {
        int positionX = 100;
        int positionY = 100;
        int width = 100;
        int height = 500;
        static Image image = Image.FromFile("C:/asset/Object/comptoir-cuisine.png");

        private List<System.Object> listOnDesk;

        Sprite sprite;

        public Desk(Chef chef, Plunger plunger, SocketApp socket)
        {
            //Ajoute les Observer à Desk
            this.AttachChef(chef);
            this.AttachPlunger(plunger);
            this.AttachSocket(socket);

            //listOnDesk = new List<System.Object>();
            sprite = new Sprite(image, positionX, positionY, width, height);
        }

        public void sendRoom(System.Object obj)
        {
            listOnDesk.Add(obj);
            this.NotifySocket();
        }

        internal Sprite Sprite { get => sprite;}
        //public List<System.Object> ListOnDesk { get => listOnDesk; set => listOnDesk = value; }
    }
}
