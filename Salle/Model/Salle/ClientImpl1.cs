using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model.Commun;

namespace Salle.Model.Salle
{
    public class ClientImpl1 : IClient
    {

        public int ClientCommande { get; set; }
        public string Repas { get; set; }
        public bool _Plat { get; set; }


        public ClientImpl1()
        {

        }

        public void prendreRepas()
        {
            _Plat = true;
        }

        public void choisirRepas(Carte carte)
        {
            Random random = new Random();
            int rdmPlat;
            rdmPlat = random.Next(5, 7);


            switch (rdmPlat)
            {
                case 1:
                    ClientCommande = carte.Plats[0].Id;
                    Repas = carte.Plats[0].Nom;
                    break;

                case 2:
                    ClientCommande = carte.Plats[1].Id;
                    Repas = carte.Plats[1].Nom;
                    break;

                case 3:
                    ClientCommande = carte.Plats[2].Id;
                    Repas = carte.Plats[2].Nom;
                    break;

                case 4:
                    ClientCommande = 4;
                    Repas = "case4";
                    break;

                case 5:
                    ClientCommande = 5;
                    Repas = "case5";
                    break;

                case 6:
                    ClientCommande = 6;
                    Repas = "case6";
                    break;

                case 7:
                    ClientCommande = 7;
                    Repas = "case7";
                    break;
            }
        }

        public void mangerPlat()
        {
            // sleep
            //Plat = false;
        }

        public void commanderVin(Serveur serveur)
        {
            // chosir le vin sur la carte
            //serveur.servirVin();
        }

        public void commanderEau(Serveur serveur)
        {
            //serveur.servirEau();
        }

        public void commanderPain(Serveur serveur)
        {
            //serveur.servirPain();
        }
    }
}
