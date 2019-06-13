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
            int rdmplat = random.Next(3, 5);

            switch (rdmplat)
            {

                case 3:
                    ClientCommande = menu.Menu1[2].Id;
                    Repas = menu.Menu1[2];
                    break;

                case 4:
                    ClientCommande = menu.Menu1[3].Id;
                    Repas = menu.Menu1[3];
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

