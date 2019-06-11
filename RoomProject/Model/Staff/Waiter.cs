﻿using System;
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

    public class Waiter : Observable, IWaiter
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

        List<Material> materialEnvoie;
        List<Material> materialRecu;



        public Waiter()
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

            // Creationn du Sprite rattaché au serveur
            sprite = new Sprite(imageChefSection, xPositionInit, yPositionInit, widthInit, heightInit);
        }

        public void ramasserAssietteCouverts()
        {

        }

        public void servirClients(GroupClient groupClient)
        {
            State = false;
            // bouger to client
            //ICLient.PrendreRepas();
            Thread.Sleep(1500);
            groupClient.Repas1 = true;
            Console.WriteLine("Les clients ont leurs repas");
            State = true;
            groupClient.MangerRepas();
            
        }

        public void debarrasserTable(GroupClient Groupe)
        {
            State = false;
            Thread.Sleep(1500);
            //Groupe.TableGroupe1.material.Clear();
            //Groupe.TableGroupe1.laundry.Clear();
            Console.WriteLine("La table a été débarassée!");
            State = true;
            //appelle le chef de rang pour dresser la table
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

                case "debarrasserTable":
                    this.debarrasserTable(groupe);
                    break;

                case "ServirClient":
                    this.servirClients(groupe);
                    break;

                case "dresserTable":
                    this.debarrasserTable(groupe);
                    break;
            }
        }

        internal Sprite Sprite { get => sprite; set => sprite = value; }
        public List<Material> MaterialEnvoie { get => materialEnvoie; set => materialEnvoie = value; }
        public List<Material> MaterialRecu { get => materialRecu; set => materialRecu = value; }
    }
}
