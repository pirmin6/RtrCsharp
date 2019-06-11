using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Object;
using Commun;

namespace ConsoleApp2.Model.Client
{

        public class GroupClient : Observable
        {
            //private List<IClient> Clients;
            private List<IClient> Clients = new List<IClient>();
            List<IClient> GroupClients = new List<IClient>();
            List<int> CommandeGroupeClientsPlats = new List<int>();
            CommandePaquet CommandeGrp;

        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();

        

            private Table TableGroupe;

            Random random = new Random();
            Boolean reservation;
            Boolean Repas = false;

            private int _painCorbeille = 3;
            private bool _vin = true;
            private bool _eau = true;
            private int nbrClient;
            private int iD;
        private int IdTable;



        public GroupClient(HostMaster hostMaster, Waiter waiter1, Waiter waiter2)
            {
                Console.WriteLine("\nDes clients sont arrivés");

                int rdmNb = random.Next(1, 9);

                AttachMaitreHotel(hostMaster);
                AttachServeur(waiter1);
                AttachServeur(waiter2);

                Thread[] threadsGroupeClients = new Thread[rdmNb];
            
                for (int i = 0; i < rdmNb; i++)
                {
                    int rdmType = random.Next(1, 3);
                    //Console.WriteLine("{0}", rdmType);

                    if (rdmType == 1)
                    {
                        GroupClients.Add(ClientFactory.getClient("Client1"));
                    }
                    if (rdmType == 2)
                    {
                        GroupClients.Add(ClientFactory.getClient("Client2"));
                    }
                }

            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                ID = nextIndex;
            }

            NbrClient = GroupClients.Count();


                Console.WriteLine("ce groupe contient {0} personnes", NbrClient);

            //Console.WriteLine("Le client est bien un : {0}", GroupClients[0]);
            //Console.WriteLine("Le client est bien un : {0}", GroupClients[1]);
            Thread.Sleep(1000);
            Console.WriteLine("on a notifié le maitre de l'arrivée des clients");
            NotifyMaitreHotel("demanderTable");
            
           
                
            }


            public void suivreChefRang(Table TableGroupe)
            {
                Thread.Sleep(4000);
                this.TableGroupe1 = TableGroupe;
            
                TableGroupe._TableOccuper = false;
                Console.WriteLine("Le Groupe est assis à une table");
                
            }

            public void clientsCommande(Menu menu)
            {
            //   faire un IF pour dire qu'ils commandent du pain (NotifyServeur) ou de la bouf (NotifyChefRang)

            Thread.Sleep(2000);


                for (int i = 0; i < NbrClient; i++)
                {
                    GroupClients[i].choisirRepas(menu);
                    CommandeGroupeClientsPlats1.Add(GroupClients[i].ClientCommande);
                    Console.WriteLine("Le client {0} à choisi le repas : {1}", i, GroupClients[i].Repas.Nom);
               
                }

            CommandeGrp1 = new CommandePaquet(TableGroupe.ID, CommandeGroupeClientsPlats1);

            Random random = new Random();
            int rdmcmd = random.Next(1, 8);

            switch (rdmcmd)
            {
                case 1:
                    NotifyServeur("ManqueEau");
                    break;

                case 2:
                    NotifyServeur("ManquePain");
                    break;

                case 3:
                    NotifyServeur("ManqueVin");
                    break;

                case 4:
                    NotifyServeur("ManqueEau");
                    NotifyServeur("ManquePain");
                    break;

                case 5:
                    NotifyServeur("ManqueEau");
                    NotifyServeur("ManqueVin");
                    break;

                case 6:
                    NotifyServeur("ManqueEau");
                    NotifyServeur("ManquePain");
                    break;

                case 7:
                    NotifyServeur("ManqueEau");
                    NotifyServeur("ManquePain");
                    NotifyServeur("ManqueVin");
                    break;

            }
            Console.WriteLine("Les clients ont choisi et appele le chef de rang");
            //Console.WriteLine(ObserversChefRang.Count());
            Console.WriteLine(ObserversChefRang.Count());
            NotifyChefRang("PrendreCommande");

            
            
            


            // previens le chef de rang qu'il veut commander.

            }

            public void MangerRepas()
        {
            Thread.Sleep(7000);
            Repas = false;
            Console.WriteLine("Le groupe à fini son repas et va partir");
            NotifyMaitreHotel("Payer");
        }

        public void commandervin()
        {
            Console.WriteLine("Le Groupe demande du Vin");
            NotifyServeur("ManqueVin");
        }

        public void commandereau()
        {
            Console.WriteLine("Le Groupe demande de l'eau");
            NotifyServeur("ManqueEau");
        }

        public void commanderpain()
        {
            Console.WriteLine("Le Groupe demande du Pain");
            NotifyServeur("ManquePain");
        }

        public void quitterTable()
            {

    //           supprime le référent de l'objet table correspondant dans cette classe

                NotifyServeur("debarasserTable");

                //maitreHotel.encaisseClient();
                GroupClients = null;

            }

        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
        }

        public void update()
            {

            }

    //        /*
    //         * ----------------------------------------------------------------------------------------------------
    //         * -----------------------------------GET--SET--------------------------------------------------------
    //         * ---------------------------------------------------------------------------------------------------
    //         */

            public int PainCorbeille
            {
                get { return this._painCorbeille; }
                set
                {
                    this._painCorbeille = value;
                    if (this._painCorbeille == 0) NotifyServeur("ManquePain");
                }
            }

            public bool Vin
            {
                get { return this._vin; }
                set
                {
                    this._vin = value;
                    if (this._vin == false) NotifyServeur("ManqueVin");
                }
            }

            public bool Eau
            {
                get { return this._eau; }
                set
                {
                    this._eau = value;
                    if (this._eau == false) NotifyServeur("ManqueEau");
                }
            }

            public int NbrClient { get => nbrClient; set => nbrClient = value; }


        public bool Repas1 { get => Repas; set => Repas = value; }
        public int ID { get => iD; set => iD = value; }
        public int IdTable1 { get => IdTable; set => IdTable = value; }
        public CommandePaquet CommandeGrp1 { get => CommandeGrp; set => CommandeGrp = value; }
        public List<int> CommandeGroupeClientsPlats1 { get => CommandeGroupeClientsPlats; set => CommandeGroupeClientsPlats = value; }
        public Table TableGroupe1 { get => TableGroupe; set => TableGroupe = value; }


        /*
public List<IClient> _Clients
{
get { return this.Clients; }
set { this.Clients = value; }
//}
//*/
    }
    }
    
