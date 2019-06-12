using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using ConsoleApp2.Model.Staff;
using ConsoleApp2.Model;
using ConsoleApp2.Model.Client;
using ConsoleApp2.Model.Object;
using Commun;


namespace RoomProject.Model.Staff
{
    public class RankLeader : Observable, IWaiter
    {
        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/chef-rang.png");

        public bool State { get; set; }
        Sprite sprite;
        private int id;
        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;
        Menu Menu = new Menu();
        private List<Observer> groupesClients;
        private int nbrCartes = 400;
        private static Counter counter;

        public static Counter Counter { get => counter; set => counter = value; }

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
            id = id++;
        }

        public void distribueCartes(GroupClient client)
        {
            // Se déplace vers la table et dis au client de commander
            State = false;
            nbrCartes = nbrCartes - client.NbrClient;
            Console.WriteLine("Le chef de rnag à distribué {0} carte au groupe {1} ", client.NbrClient, client.ID);
            Console.WriteLine("Les clients choisissent leurs repas . . .");
            Thread.Sleep(5000);
            client.clientsCommande(Menu);
            State = true;
        }

        public void prendreCommande(GroupClient client)
        {
            State = false;
            Console.WriteLine("Le chef de rang prends la commande il va maintenant la poser sur le comptoir");
            nbrCartes = nbrCartes + client.NbrClient;

            // se déplacer a la table puis au comptoir et envoie commande
            //this.PoserCommandeComptoir(client, counters[0]);

            //Thread.Sleep(1000);
            //counters[0].CommandeEnvoie1.Add(client.CommandeGroupeClients1);
            //Console.WriteLine("La commande à était déposée sur le comptoir");
            //Console.WriteLine("Sur le comptoir il y a " + counters[0].CommandeEnvoie1.Count() + " commande à envoyer à la cuisine");
            State = true;
        }

        public void PoserCommandeComptoir(GroupClient groupeClient, Counter counter)
        {
            State = false;
            Thread.Sleep(1000);


            //Console.WriteLine("La commande à était déposée sur le comptoir");

            
            Console.WriteLine(groupeClient.CommandeGrp1.ListPlats[2]);
            counter.CommandeEnvoie.Add(groupeClient.CommandeGrp1);
            counter.CommandeEnvoie.Add(new CommandePaquet(1, groupeClient.CommandeGroupeClientsPlats1));
            State = true;
        }

        public void placerClientTable(GroupClient client, Table TableGroupe)
        {
            State = false;
            //est appeller par le maitreHotel
            Console.WriteLine("Le chef de rang emmène les clients à leurs tables");
            client.suivreChefRang(TableGroupe);

            // bouger(x,y)
            State = true;
            this.distribueCartes(client);
        }

        public void dresserTable()
        {
            State = false;
            //attend que le serveur est débarasser la table
            State = true;
        }



        public void Update(Observable observable, string actionUpdate)
        {
            GroupClient groupe = (GroupClient)observable;
            
            //Counter counter = (Counter)observable;

            //Table TableGroupe = (Table)observable;


            switch (actionUpdate)
            {
                case "DistribueCarte":
                    this.distribueCartes(groupe);
                    break;

                case "PrendreCommande":
                    this.prendreCommande(groupe);       //va prendre la commande du groupe qui l'a demandé
                    break;

                //case "PlacerClient":
                //    this.placerClientTable(groupe, TableGroupe);
                //    break;

            }

        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
    }
}
