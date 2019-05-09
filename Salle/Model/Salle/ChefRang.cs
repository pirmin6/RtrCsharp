using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Model.Commun;

namespace Salle.Model.Salle
{
    public class ChefRang : Observable, IServeur
    {

        //private List<Carre> carres;
        private List<Observer> groupesClients;


        public ChefRang()
        {
        }
        
        /*
        public List<Carre> getCarres() {
            return carres;
        }
        */

        public void distribueCartes(GroupeClient client)
        {
            // se lance dès que les clients sont installés
            //int nombreClient = client._Clients.Count;    //enleve se nombre de cartes disponibles 
        }

        public void prendreCommande(GroupeClient groupe)
        {

        }

        public void placerClientTable(GroupeClient client, Table TableGroupe)
        {
            //est appeller par le maitreHotel
            client.suivreChefRang(TableGroupe);

            this.distribueCartes(client);
        }

        public void dresserTable()
        {
            //attend que le serveur est débarasser la table

        }

        public void update(Observable observable, string actionUpdate)
        {
            GroupeClient groupe = (GroupeClient)observable;

            switch(actionUpdate)
            {
                case "DistribueCarte":
                    this.distribueCartes(groupe);
                    break;

                case "PrendreCommande":
                    this.prendreCommande(groupe);       //va prendre la commande du groupe qui l'a demandé
                    break;
            }

        }
    }
}
