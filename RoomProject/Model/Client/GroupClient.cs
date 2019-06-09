﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Object;

namespace ConsoleApp2.Model.Client
{

        public class GroupClient : Observable
        {
            //private List<IClient> Clients;
            private List<IClient> Clients = new List<IClient>();
            List<IClient> GroupClients = new List<IClient>();
            List<int> CommandeGroupeClients = new List<int>();

        private int idGroupe;

            private Table _TableGroupe;

            Random random = new Random();
            Boolean reservation;
            Boolean Repas = false;

            private int _painCorbeille = 3;
            private bool _vin = true;
            private bool _eau = true;
            private int nbrClient;


            public GroupClient(HostMaster hostMaster)
            {
                Console.WriteLine("\nDes clients sont arrivés");

                int rdmNb = random.Next(1, 9);

                AttachMaitreHotel(hostMaster);
                

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

                NbrClient = GroupClients.Count();
                IdGroupe = IdGroupe++;

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
                this._TableGroupe = TableGroupe;
                _TableGroupe._TableOccuper = false;
                Console.WriteLine("Le Groupe est assis à une table");
            }

            public void clientsCommande(Menu menu)
            {
            //   faire un IF pour dire qu'ils commandent du pain (NotifyServeur) ou de la bouf (NotifyChefRang)

            Thread.Sleep(2000);

                for (int i = 0; i < NbrClient; i++)
                {
                    GroupClients[i].choisirRepas(menu);
                    CommandeGroupeClients.Add(GroupClients[i].ClientCommande);
                    Console.WriteLine("Le client {0} à choisi le repas : {1}", i, GroupClients[i].ClientCommande);
               
                }

            Console.WriteLine("Les clients ont choisi et appele le chef de rang");
            Console.WriteLine(ObserversChefRang.Count());
            NotifyChefRang("PrendreCommande");

            

            


            // previens le chef de rang qu'il veut commander.

            }

            public void MangerRepas(IClient client)
        {
            foreach (IClient client2 in GroupClients)
            {
                client2.mangerPlat();
            }
        }

            public void quitterTable()
            {

    //           supprime le référent de l'objet table correspondant dans cette classe

                NotifyServeur("debarasserTable");

                //maitreHotel.encaisseClient();
                GroupClients = null;

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
            public List<int> CommandeGroupeClients1 { get => CommandeGroupeClients; set => CommandeGroupeClients = value; }
        public int IdGroupe { get => idGroupe; set => idGroupe = value; }
        public bool Repas1 { get => Repas; set => Repas = value; }
        /*
public List<IClient> _Clients
{
get { return this.Clients; }
set { this.Clients = value; }
//}
//*/
    }
    }
    