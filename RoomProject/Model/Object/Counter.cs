using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RoomProject.Model;


namespace ConsoleApp2.Model.Object
{
    public class Counter : Observable
    {
        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        //static Image image = Image.FromFile("C:/asset/Staff/comptoir.png");

        Sprite sprite;

        public List<List<int>> CommandeEnvoie;

        public Counter()
        {
            CommandeEnvoie = new List<List<int>>();
        }

        public List<List<int>> CommandeEnvoie1 { get => CommandeEnvoie; set => CommandeEnvoie = value; }

        public void EnvoyerCommande()
        {
            //SocketCommande socketCommande = new SocketCommande();
            //socketCommande.sendCMD(comptoir);
        }
    }
}
