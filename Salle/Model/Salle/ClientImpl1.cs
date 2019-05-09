using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public class ClientImpl1 : IClient
    {

        bool _Plat = false;

        public bool Plat { get => Plat; set => Plat = value; }

        public ClientImpl1()
        {

        }

        public void prendreRepas()
        {
             _Plat = true;
        }

        public void choisirRepas()
        {
            // Random nombre impair = repas choisi
            //  Random random = new Random();
            // random.Next(1, 10);
            //if (random == 1) 
            // {
            // on choisit le plat 1
            //  } 
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
