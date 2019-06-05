using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model.Commun;

namespace Salle.Model.Salle
{
    

    public interface IClient
    {

        int ClientCommande { get; set; }
        string Repas { get; set; }
        bool Mange { get; set; }


        void prendreRepas();
        void choisirRepas(Carte carte);
        void mangerPlat();
        void commanderVin(Serveur serveur);
        void commanderEau(Serveur serveur);
        void commanderPain(Serveur serveur);

    }
}
