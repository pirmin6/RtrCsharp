using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using RoomProject.Model;
using ConsoleApp2.Model.Client;
using ConsoleApp2.Model.Staff;
using RoomProject.Model.Staff;
using RoomProject.Socket;
using Commun;


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

        private List<CommandePaquet> commandeEnvoie;
        private List<CommandePaquet> commandeReçu;

        private List<MaterialPaquet> materialEnvoie;
        private List<MaterialPaquet> materialRecu;


        public Counter(Waiter waiter1, Waiter waiter2, SocketApp socket)
        {
            CommandeEnvoie = new List<CommandePaquet>();
            CommandeReçu = new List<CommandePaquet>();
            materialEnvoie = new List<MaterialPaquet>();
            materialRecu = new List<MaterialPaquet>();

            AttachServeur(waiter1);
            AttachServeur(waiter2);
            AttachSocket(socket);

        }

        public void AddCommandeEnvoie(CommandePaquet commandePaquet)
        {
            commandeEnvoie.Add(commandePaquet);
            NotifySocket("Commande");
        }

        public void AddCommandeRecu(CommandePaquet commandePaquet)
        {
            CommandeReçu.Add(commandePaquet);
            //nsole.WriteLine("/////////////////////////////////" + commandeReçu[0].ListPlats.Count());
            NotifyServeurCounter("ServirClient");
            commandeReçu.RemoveAt(0);

        }

        public void AddMaterialEnvoie(MaterialPaquet materialPaquet)
        {
            materialEnvoie.Add(materialPaquet);
            //Console.WriteLine("On y est");
            NotifySocket("Material");
        }

        public void AddMaterialRecu(MaterialPaquet materialPaquet)
        {
            materialRecu.Add(materialPaquet);
            NotifyServeurCounter("dresserTable");
            materialRecu.Clear();
        }




        

        //public List<CommandePaquet> CommandeEnvoie {
        //    get
        //    {
        //        return commandeEnvoie;
        //    }
        //    set
        //    { 
        //    this.CommandeEnvoie = value;
        //        Console.WriteLine("ffezfzfzefevefzffzefvefz");
        //    NotifySocket("Commande");
        //        Console.WriteLine("refgrebrzerefzfzgberefzrazf00");
        //    }
        //}

    


       


        public List<MaterialPaquet> MaterialEnvoie
        {
            get
            {
                return materialEnvoie;
            }
            set
            {
                this.materialEnvoie = value;
                NotifySocket("Material");
            }
        }

        public List<MaterialPaquet> MaterialRecu
        {
            get
            {
                return materialRecu;
            }
            set
            {
                this.materialRecu = value;
                NotifyServeur("dresserTable");
            }
        }

        public List<CommandePaquet> CommandeEnvoie { get => commandeEnvoie; set => commandeEnvoie = value; }
        public List<CommandePaquet> CommandeReçu { get => commandeReçu; set => commandeReçu = value; }

        // public List<CommandePaquet> CommandeEnvoie { get => commandeEnvoie; set => commandeEnvoie = value; }

        public void EnvoyerMaterial()
        {
            //NotifySocket("");
        }

        public void EnvoyerCommande()
        {
            //NotifySocket("")
        }

        public void ServeurServir()
        {
            //NotifyServeur("ServirClient");
        }

        
    }
}
