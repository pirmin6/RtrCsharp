using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp2.Model.Object;
using ConsoleApp1.Domain;

namespace ConsoleApp2.Model.Client
{
    public class ClientImpl1 : IClient
    {

        public int ClientCommande { get; set; }
        public Dish Repas { get; set; }
        public bool Mange { get; set; }


        public ClientImpl1()
        {
            Mange = false;
        }

        public void prendreRepas()
        {
            Mange = true;
        }

        public void choisirRepas(Menu menu)
        {

            Random random = new Random();
            int rdmplat = random.Next(1, 3);

            switch (rdmplat)
            {
                case 1:
                    ClientCommande = menu.Menu1[0].Id;
                    Repas = menu.Menu1[0];
                    break;

                case 2:
                    ClientCommande = menu.Menu1[1].Id;
                    Repas = menu.Menu1[1];
                    break;



            }

        }

        public void mangerPlat()
        {
            Mange = true;
            Console.WriteLine("Le Client mange son repas");
            Thread.Sleep(5000);
            Mange = false;
            Console.WriteLine("Le Client mange à fini son repas");
        }

        //public void commanderVin(Serveur serveur)
        //{
        //    // chosir le vin sur la carte
        //    //serveur.servirVin();
        //}

        //public void commanderEau(Serveur serveur)
        //{
        //    //serveur.servirEau();
        //}

        //public void commanderPain(Serveur serveur)
        //{
        //    //serveur.servirPain();
        //}
    }
}
