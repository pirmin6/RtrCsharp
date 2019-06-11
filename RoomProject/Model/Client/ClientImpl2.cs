using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp2.Model.Object;

namespace ConsoleApp2.Model.Client
{

    public class ClientImpl2 : IClient

    {

        public int ClientCommande { get; set; }
        public Dish Repas { get; set; }
        public bool Mange { get; set; }

        public ClientImpl2()
        {
            Mange = false;
        }

        public void choisirRepas(Menu menu)
        {

            Random random = new Random();
            int rdmplat = random.Next(2, 4);

            switch (rdmplat)
            {
                case 1:
                    ClientCommande = menu.Plats[0].Id;
                    Repas = menu.Plats[0];
                    break;

                case 2:
                    ClientCommande = menu.Plats[1].Id;
                    Repas = menu.Plats[1];
                    break;

                case 3:
                    ClientCommande = menu.Plats[2].Id;
                    Repas = menu.Plats[2];
                    break;


            }

        }

        //public void commandervin(serveur serveur)
        //{
        //     chosir le vin sur la carte
        //    serveur.servirvin(groupeclient groupe);
        //}

        //public void commandereau(serveur serveur)
        //{
        //    serveur.servireau(this);
        //}

        //public void commanderpain(serveur serveur)
        //{
        //}

        public void mangerPlat()
        {
            Mange = true;
            Console.WriteLine("Le Client mange son repas");
            Thread.Sleep(5000);
            Mange = false;
            Console.WriteLine("Le Client mange à fini son repas");
        }

        public void prendreRepas()
        {

        }
    }
}

