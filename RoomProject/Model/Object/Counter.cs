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

        private List<Order> commandeEnvoie;
        private List<Order> commandeReçu;
        private List<Material> materialEnvoie;
        private List<Material> materialRecu;


        public Counter(Waiter waiter1, Waiter waiter2)
        {
            CommandeEnvoie = new List<Order>();
            AttachServeur(waiter1);
            AttachServeur(waiter2);

        }

        public List<Order> CommandeReçu
        {

            get
            {
                return CommandeReçu;
            }
            set
            {
                this.CommandeReçu = value;
                NotifyServeur("ServirClient");
            }
        }

        public List<Order> CommandeEnvoie {
            get
            {
                return commandeEnvoie;
            }
            set
            { 
            this.commandeEnvoie = value;
            //NotifySocket("commandeEnvoie");
            }
        }

    


       


        public List<Material> MaterialEnvoie
        {
            get
            {
                return materialEnvoie;
            }
            set
            {
                this.materialEnvoie = value;
                //NotifySocket("materialEnvoie");
            }
        }

        public List<Material> MaterialRecu
        {
            get
            {
                return materialRecu;
            }
            set
            {
                this.materialRecu = value;
                //NotifyServeur("dresserTable");
            }
        }


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
