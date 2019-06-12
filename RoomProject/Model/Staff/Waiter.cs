using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using ConsoleApp2.Model.Client;
using ConsoleApp2.Model;
using ConsoleApp2.Model.Staff;
using ConsoleApp2.Model.Object;
using Commun;

namespace RoomProject.Model.Staff
{
    delegate void DelegateAction();

    public class Waiter : Observable, IWaiter, IWaiterCounter
    {
        private int _StockEau = 1000;
        private int _StockPain = 1000;

        public int StockEau { get => _StockEau; set => _StockEau = value; }
        public int StockPain { get => _StockPain; set => _StockPain = value; }

        string RemarquePain;
        string RemarqueEau;
        string RemarqueVin;

        public bool State { get; set; }

        private int xPositionInit;
        private int yPositionInit;
        private int widthInit = 100;
        private int heightInit = 100;
        static Image imageChefSection = Image.FromFile("C:/asset/Staff/serveur.png");

        Sprite sprite;

        private static int nbrInstanciated = 0;
        private Boolean firstInstanciated;

        List<CommandePaquet> CommandeClientServir;


        List<MaterialPaquet> materialEnvoie;
        List<MaterialPaquet> materialRecu;

        private Square carre1;
        private Square carre2;

        private static Counter counter;

        public static Counter Counter { get => counter; set => counter = value; }

        public Square Carre1 { get => carre1; set => carre1 = value; }
        public Square Carre2 { get => carre2; set => carre2 = value; }

        public Waiter(Square carre1, Square carre2)
        {
            nbrInstanciated++;
            if (nbrInstanciated > 2) throw new System.InvalidOperationException("Il ne peut y avoir que 2 cuisinier");

            firstInstanciated = nbrInstanciated == 1;
            if (firstInstanciated)
            {
                xPositionInit = 200;
                yPositionInit = 300;
            }
            else
            {
                xPositionInit = 300;
                yPositionInit = 300;
            }

            this.carre1 = carre1;
            this.carre2 = carre2;

            // Creationn du Sprite rattaché au serveur
            sprite = new Sprite(imageChefSection, xPositionInit, yPositionInit, widthInit, heightInit);
            
            
        }

        public void ramasserAssietteCouverts()
        {

        }

        public void servirClients(Counter counter)
        {
            State = false;
            CommandeClientServir = new List<CommandePaquet>();
            CommandeClientServir.Add(counter.CommandeReçu[0]);


            Console.WriteLine(CommandeClientServir[0].ListPlats.Count());

            //counter.CommandeEnvoie.Clear();
            //foreach(int eze in CommandeClientServir[0].ListPlats)
            //{
            //    Console.WriteLine(eze);
            //}

            foreach (Rank rank in carre2.ListeRang)
            {
                foreach (Table table in rank.Tables)
                {
                    if (table.ID == CommandeClientServir[0].IdTable)
                    {
                        Console.WriteLine("Les clients à la table {0} ont été servis", table.ID);
                        
                        table.groupeClient.MangerRepas();
                    }
                }
            }

            foreach (Rank rank in carre1.ListeRang)
            {
                foreach (Table table in rank.Tables)
                {
                    if (table.ID == CommandeClientServir[0].IdTable)
                    {
                        Console.WriteLine("Les clients à la table {0} ont été servis", table.ID);
                        

                    }
                }
            }
            CommandeClientServir.Clear();

            // bouger to client
            //ICLient.PrendreRepas();
            //Thread.Sleep(1500);
            //groupClient.Repas1 = true;
            //Console.WriteLine("Les clients ont leurs repas");
            //State = true;
            //groupClient.MangerRepas();

        }

        public void dresserTable(Counter counter)
        {
            State = false;
            materialRecu = new List<MaterialPaquet>();
            materialRecu.Add(counter.MaterialRecu[0]);

            foreach(Rank rank in carre1.ListeRang)
            {
                foreach(Table table in rank.Tables)
                {
                    foreach(MaterialPaquet materialPaquet in materialRecu)
                    {
                        if(materialPaquet.IdTable == table.ID)
                        {
                            table.Material.Add(materialPaquet);
                            Console.WriteLine(table.Material.Count());
                        }
                    }
                }
            }

            foreach (Rank rank in carre2.ListeRang)
            {
                foreach (Table table in rank.Tables)
                {
                    foreach (MaterialPaquet materialPaquet in materialRecu)
                    {
                        if (materialPaquet.IdTable == table.ID)
                        {
                            table.Material.Add(materialPaquet);
                            Console.WriteLine(table.Material.Count());
                        }
                    }
                }
            }

            materialRecu.Clear();
            Console.WriteLine("La table a été dréssée!");



            State = true;
            
        }

        public void debarrasserTable(GroupClient groupe)
        {
            materialEnvoie = new List<MaterialPaquet>();
            State = false;
            Console.WriteLine("Le serveur débarasse la table");
            foreach(Rank rank in Carre2.ListeRang)
            {
                foreach(Table table in rank.Tables)
                {
                    if(table.ID == groupe.TableGroupe1.ID)
                    {

                        foreach (MaterialPaquet materialPaquet in table.Material)
                        {
                            materialPaquet.Dirty = true;
                            Console.WriteLine(materialPaquet.IdTable);
                            materialEnvoie.Add(materialPaquet);
                            
                        }
                        table.Material.Clear();
                    }
                }
            }

            foreach (Rank rank in Carre1.ListeRang)
            {
                foreach (Table table in rank.Tables)
                {
                    if (table.ID == groupe.TableGroupe1.ID)
                    {

                        foreach (MaterialPaquet materialPaquet in table.Material)
                        {
                            materialPaquet.Dirty = true;
                            Console.WriteLine(materialPaquet.IdTable);
                            materialEnvoie.Add(materialPaquet);
                            
                        }
                        table.Material.Clear();
                    }
                }
            }

            foreach (MaterialPaquet materialPaquet in materialEnvoie)
            {
                counter.AddMaterialEnvoie(materialPaquet);
            }
            materialEnvoie.Clear();
            State = true;
        }


        public void servirPain(GroupClient groupe)
        {
            State = false;
            StockPain = StockPain - 1;
            Console.WriteLine("le serveur sert du pain chez le client {0}", groupe.ID);
            groupe.PainCorbeille = 1;
            State = true;

        }

        public void servirEau(GroupClient groupe)
        {
            State = false;
            StockEau = StockEau - 1;
            Console.WriteLine("le serveur sert de l'eau chez le client {0}", groupe.ID);
            groupe.Eau = true;
            State = true;
        }

        public void servirVin(GroupClient groupe)
        {
            State = false;
            Console.WriteLine("le serveur sert du vin chez le client {0}", groupe.ID);
            groupe.Vin = true;
            State = true;
        }

        public void Update(Observable observable, string actionUpdate)
        {
            //Console.WriteLine("Le groupe client {0} doit être servis en {1}", observable, actionUpdate);

            GroupClient groupe = (GroupClient)observable;

            switch (actionUpdate)
            {
                case "ManquePain":
                    this.servirPain(groupe);
                    break;

                case "ManqueEau":
                    this.servirEau(groupe);
                    break;

                case "ManqueVin":
                    this.servirVin(groupe);
                    break;

                case "DebarasserTable":
                    this.debarrasserTable(groupe);
                    break;

                
            }
        }

        public void update(Observable observable, string actionUpdate)
        {
            //Console.WriteLine("Le groupe client {0} doit être servis en {1}", observable, actionUpdate);

            Counter counter = (Counter)observable;

            switch (actionUpdate)
            {
                case "ServirClient":
                    this.servirClients(counter);
                    break;

                case "dresserTable":
                    this.dresserTable(counter);
                    break;

            }
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
        public List<MaterialPaquet> MaterialEnvoie { get => materialEnvoie; set => materialEnvoie = value; }
        public List<MaterialPaquet> MaterialRecu { get => materialRecu; set => materialRecu = value; }

    }
}
