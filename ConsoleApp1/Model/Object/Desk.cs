using ConsoleApp1.Socket;
using KitchenProject.Model;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Commun;

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

        
        //private List<Commande>

        Sprite sprite;

        public Desk()
        {
        

            //listOnDesk = new List<System.Object>();
            sprite = new Sprite(image, positionX, positionY, width, height);
        }




        internal Sprite Sprite { get => sprite; }
        public List<MaterialPaquet> ListMaterialDemander
        {
            get
            {
                return this.ListMaterialDemander;
            }
            set
            {
                ListMaterialDemander = value;
                NotifyPlunger("DemandMaterial");
            }  
        }
        //public List<System.Object> ListOnDesk { get => listOnDesk; set => listOnDesk = value; }
    }
}
