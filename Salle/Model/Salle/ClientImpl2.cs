using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{

    public class ClientImpl2 : IClient

    {


        bool _Plat = false;

        public bool Plat { get => Plat; set => Plat = value; }

        private string humeur = "mange lentement";


        public void choisirRepas()
        {
            // Random nombre paire = plat choise
          //  Random random = new Random();
           // random.Next(1, 10);
            //!if (random == 1) 
           // {
                // on choisit le plat 1
          //  } 
            
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
