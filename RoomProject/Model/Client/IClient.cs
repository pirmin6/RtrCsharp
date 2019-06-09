using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Model.Object;

namespace ConsoleApp2.Model.Client
{
    public interface IClient
    {

        int ClientCommande { get; set; }
        string Repas { get; set; }
        bool Mange { get; set; }


        void prendreRepas();
        void choisirRepas(Menu menu);
        void mangerPlat();
        //void commanderVin(Serveur serveur);
        //void commanderEau(Serveur serveur);
        //void commanderPain(Serveur serveur);

    }
}
