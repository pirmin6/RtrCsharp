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
        private int nbrCartes = 400;

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
            // Se déplace vers la table et dis au client de commander
            nbrCartes = nbrCartes - client.NbrClient;
        }

        public void prendreCommande(GroupeClient client)
        {
            nbrCartes = nbrCartes + client.NbrClient;
            // se déplacer a la table puis au comptoir et envoie commande
        }

        public void PoserCommandeComptoir(Comptoir comptoir, GroupeClient groupeClient)
        {
            comptoir.CommandeEnvoie1.Add(groupeClient.CommandeGroupeClients1);
            Console.WriteLine("La commande à était déposée sur le comptoir");
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
