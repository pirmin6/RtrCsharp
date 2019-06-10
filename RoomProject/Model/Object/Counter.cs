using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RoomProject.Model;
using ConsoleApp2.Model.Client;
using RoomProject.Model.Staff;


namespace ConsoleApp2.Model.Object
{
    public class Counter : Observable
    {
        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        //static Image image = Image.FromFile("C:/asset/Staff/comptoir.png");

        public GroupClient groupeClient;
        Sprite sprite;

        private List<List<Dish>> commandeEnvoie;
        private List<List<Dish>> commandeReçu;

        public Counter(Waiter waiter1, Waiter waiter2)
        {
            CommandeEnvoie = new List<List<Dish>>();
            AttachServeur(waiter1);
            AttachServeur(waiter2);
            
        }
        
        public List<List<Dish>> CommandeReçu
        {

            get
            {
                return commandeEnvoie;
            }
            set
            {
                this.commandeEnvoie = value;
                NotifyServeur("ServirClient");
            }
        }
        public List<List<Dish>> CommandeEnvoie { get => commandeReçu; set => commandeReçu = value; }

        public void EnvoyerCommande()
        {
            //SocketCommande socketCommande = new SocketCommande();
            //socketCommande.sendCMD(comptoir);
        }

        public void ServeurServir()
        {
            //NotifyServeur("ServirClient");
        }
    }
}
