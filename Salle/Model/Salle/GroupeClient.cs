using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Salle.Model.Commun;

namespace Salle.Model.Salle
{
    public class GroupeClient : Observable
    {
        //private List<IClient> Clients;
        //private List<IClient> Clients = new List<IClient>();
        List<IClient> GroupeClients = new List<IClient>();
        List<int> CommandeGroupeClients;
        //private List<Test1> Clients = new List<Test1>();

        private Table _TableGroupe;

        Random random = new Random();
        Boolean reservation;

        private int _painCorbeille = 3;
        private bool _vin = true;
        private bool _eau = true;
        private int nbrClient;

        public GroupeClient(MaitreHotel maitre)
        {            
            Console.WriteLine("Un NouveauGroupe a été Créer");
            
            int rdmNb = random.Next(1, 8);

            AttachMaitreHotel(maitre);
            
            Thread[] threadsGroupeClients = new Thread[rdmNb];

            for (int i = 0; i < rdmNb; i++)
            {
                int rdmType = random.Next(1, 3);
                Console.WriteLine("{0}", rdmType);

                if (rdmType == 1)
                {
                    GroupeClients.Add(ClientFactory.getClient("Client1"));
                }
                if (rdmType == 2)
                {
                    GroupeClients.Add(ClientFactory.getClient("Client2"));
                }
            }

            NbrClient = GroupeClients.Count();
            Console.WriteLine("ce groupe contient {0} personnes", NbrClient);
            //Console.WriteLine("Le client est bien un : {0}", GroupeClients[0]);
            //Console.WriteLine("Le client est bien un : {0}", GroupeClients[1]);

            this.clientsCommande(Carte);

            NotifyMaitreHotel("demanderTable");
        }


        public void suivreChefRang(Table TableGroupe)
        {
            this._TableGroupe = TableGroupe;
            _TableGroupe._TableOccuper = false;
            Console.WriteLine("Le Groupe st assis à une table");
        }

        public void clientsCommande(Carte carte)
        {
            // faire un IF pour dire qu'ils commandent du pain (NotifyServeur) ou de la bouf (NotifyChefRang)
            new List<int>();

            for (int i = 0; i < NbrClient; i++)
            {
                GroupeClients[i].choisirRepas(carte);
                CommandeGroupeClients.Add(GroupeClients[i].ClientCommande);
                Console.WriteLine("Le client {0} à choisi le repas : {1}", i, GroupeClients[i].Repas);
            }

            NotifyChefRang("prendreCommande");


            //previens le chef de rang qu'il veut commander.

        }

        public void quitterTable()
        {

            //supprime le référent de l'objet table correspondant dans cette classe

            NotifyServeur("debarasserTable");
            
        //    maitreHotel.encaisseClient();
        //    Clients = null; 

        }

        public void update()
        {

        }

        /*
         * ----------------------------------------------------------------------------------------------------
         * -----------------------------------GET--SET--------------------------------------------------------
         * ---------------------------------------------------------------------------------------------------
         */

        public int PainCorbeille
        {
            get { return this._painCorbeille; }
            set
            {
                this._painCorbeille = value;
                if (this._painCorbeille == 0) NotifyServeur("ManquePain");
            }
        }

        public bool Vin
        {
            get { return this._vin; }
            set
            {
                this._vin = value;
                if (this._vin == false) NotifyServeur("ManqueVin");
            }
        }

        public bool Eau
        {
            get { return this._eau; }
            set
            {
                this._eau = value;
                if (this._eau == false) NotifyServeur("ManqueEau");
            }
        }

        public int NbrClient { get => nbrClient; set => nbrClient = value; }
        /*
public List<IClient> _Clients
{
get { return this.Clients; }
set { this.Clients = value; }
}
*/
    }
}
