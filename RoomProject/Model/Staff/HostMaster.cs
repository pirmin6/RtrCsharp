using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using ConsoleApp2.Model.Object;
using ConsoleApp2.Model;
using ConsoleApp2.Model.Client;
using ConsoleApp2.Model.Staff;
using RoomProject.Model.Staff;

namespace RoomProject.Model.Staff
{
    public class HostMaster : Observable, IWaiter
    {
        public int xPositionInit = 200;
        public int yPositionInit = 100;
        public int widthInit = 100;
        public int heightInit = 100;
        static Image image = Image.FromFile("C:/asset/Staff/maitre-hotel.png");

        Sprite sprite;

        private Square _Carre1;
        private Square _Carre2;


        List<Table> Carre1TableDispo;
        List<Table> Carre2TableDispo;

        List<RankLeader> listchefRang;

        List<GroupClient> ListGroupe;

        private Rank chefRang;
        private int Attente;
        private List<Table> tablesLibres;

        public HostMaster(RankLeader chefRang1, RankLeader chefRang2, Square Carre1, Square Carre2)
        {
            ListGroupe = new List<GroupClient>();

            listchefRang = new List<RankLeader>();
            listchefRang.Add(chefRang1);
            listchefRang.Add(chefRang2);

            ObserversChefRang.Add(chefRang1);
            //ObserversChefRang.Add(chefRang2);


            sprite = new Sprite(image, xPositionInit, yPositionInit, widthInit, heightInit);

            //Console.WriteLine("Le HostMaster à été instancié");
            _Carre1 = Carre1;
            _Carre2 = Carre2;
            
            this.RecupererTableDispo();
            //this.AttribuerTable();

            
        }

        public void RecupererTableDispo()
        {
            Carre1TableDispo = _Carre1.getTablesDispo();
            Carre2TableDispo = _Carre2.getTablesDispo();

            Console.WriteLine("Il y a {0} tables dispo dans le carre 1 et {1} dispo dans le carre 2", Carre1TableDispo.Count(), Carre2TableDispo.Count());
        }

        public void AttribuerTable(GroupClient Groupe)
        {
            // Console.WriteLine("on y est");            
            //int nbrClient = 7;
            Thread.Sleep(1000);
            if (Carre1TableDispo.Count() <= Carre2TableDispo.Count())
            {
                List<int> Associe = new List<int>();

                for (int i = 0; i < Carre2TableDispo.Count(); i++)
                {
                    Associe.Add(Carre2TableDispo[i].getNbrPlaces());
                    //Associe.Add(Groupe.IdGroupe);
                }

                for (int i = 0; i <= Associe.Count(); i++)
                {
                    if (Groupe.NbrClient <= Associe[i])
                    {
                        Groupe.AttachChefRang(listchefRang[0]);
                        Console.WriteLine("On associe le groupe {2} à la Table {0} qui a {1} places", Carre2TableDispo[i].ID, Associe[i], Groupe.ID);
                        _Carre2.ChefRangCarre.placerClientTable(Groupe, Carre2TableDispo[i]);
                        break;
                    }
                }
            }

            else
            {
                List<int> Associe2 = new List<int>();

                for (int i = 0; i < Carre1TableDispo.Count(); i++)
                {
                    Associe2.Add(Carre1TableDispo[i].getNbrPlaces());
                }

                for (int i = 0; i <= Associe2.Count(); i++)
                {
                    if (Groupe.NbrClient <= Associe2[i])
                    {
                        Console.WriteLine("On associe la Table {0} qui a {1} places", Carre1TableDispo[i].ID, Associe2[i]);
                        Groupe.AttachChefRang(listchefRang[1]);
                        _Carre1.ChefRangCarre.placerClientTable(Groupe, Carre1TableDispo[i]);
                        

                        break;
                    }
                }
            }

            Thread.Sleep(500);
            //Console.WriteLine("Le maitre d'hotel appel le chef de rang");
            //Console.WriteLine(ObserversChefRang.Count());
            //NotifyChefRang("PlacerClient");
        }

        public void encaisseClient(GroupClient groupe)
        {
            Console.WriteLine("Le maitre d'hotel encaisse les clients");
            Thread.Sleep(2000);
            Console.WriteLine("Le groupe s'en va !");
            groupe = null;
        }

        /*
        public void appelleChefRang()
        {
            //NotifyChefRang();
        }

        public void ajouteClient()
        {

        }
        */


        public void Update(Observable observable, string actionUpdate)
        {
            GroupClient groupe = (GroupClient)observable;

            switch (actionUpdate)
            {
                case "demanderTable":
                    this.AttribuerTable(groupe);
                    break;

                case "Payer":
                    this.encaisseClient(groupe);
                    break;

                
            }
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
        public List<GroupClient> ListGroupe1 { get => ListGroupe; set => ListGroupe = value; }
    }
}