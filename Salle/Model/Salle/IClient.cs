using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public interface IClient
    {


        void prendreRepas();
        void choisirRepas();
        void mangerPlat();
        void commanderVin(Serveur serveur);
        void commanderEau(Serveur serveur);
        void commanderPain(Serveur serveur);

    }
}
