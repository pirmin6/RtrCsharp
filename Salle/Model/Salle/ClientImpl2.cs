using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model.Commun;

namespace Salle.Model.Salle
{

    public class ClientImpl2 : IClient

    {

        public int ClientCommande { get; set; }
        public string Repas { get; set; }
        public bool _Plat { get; set; }

        public void choisirRepas(Carte carte)
        {
            
            Random random = new Random();
            int rdmPlat = random.Next(1, 4);

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
            }
            
        }

        public void commanderVin(Serveur serveur)
        {
            // chosir le vin sur la carte
            //serveur.servirVin(GroupeClient groupe);
        }

        public void commanderEau(Serveur serveur)
        {
            //serveur.servirEau(this);
        }

        public void commanderPain(Serveur serveur)
        {
        }

        public void mangerPlat()
        {
            // sleep
            // Plat = false;
        }

        public void prendreRepas()
        {

        }
    }
}
