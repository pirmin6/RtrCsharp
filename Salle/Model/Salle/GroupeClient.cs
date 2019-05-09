using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Salle.Model.Salle
{
    public class GroupeClient : Observable
    {
        //private List<IClient> Clients;
        private List<IClient> Clients = new List<IClient>();
        //private List<Test1> Clients = new List<Test1>();

        private Table _TableGroupe;

        Random random = new Random();
        Boolean reservation;

        private int _painCorbeille = 3;
        private bool _vin = true;
        private bool _eau = true;
        

        public GroupeClient(MaitreHotel maitre)
        {            
            Console.WriteLine("Un NouveauGroupe a été Créer");

            int rdmNb = random.Next(0, 10);

            AttachMaitreHotel(maitre);
            
            Thread[] threadsClients = new Thread[rdmNb];

            for (int i = 0; i < threadsClients.Length; i++)
            {
                threadsClients[i] = new Thread(CreerClient);
                threadsClients[i].Start();
                threadsClients[i].Join();
            }
            Console.WriteLine("ce groupe contient {0} personnes", threadsClients.Length);
            NotifyMaitreHotel("demanderTable");
        }

     
        private void CreerClient()
        {
            int rdmType = random.Next(1, 2);

            if (rdmType == 1)
            {
                Clients.Add(ClientFactory.getClient("Client1"));
            }
            if (rdmType == 2)
            {
                Clients.Add(ClientFactory.getClient("Client2"));
            }
        }
        


        public void suivreChefRang(Table TableGroupe)
        {
            this._TableGroupe = TableGroupe;
            _TableGroupe._TableOccuper = false;
            Console.WriteLine("Le Groupe st assis à une table");
        }

        public void clientsCommande()
        {
            // faire un IF pour dire qu'ils commandent du pain (NotifyServeur) ou de la bouf (NotifyChefRang)

            List<IClient> Clients = new List<IClient>();
            Random random = new Random();
            int rdmNb = random.Next(1, 10);
            int rdmType = random.Next(1, 2);
            for (int i = 0; i < rdmNb; i++)
            {           
                if (rdmType == 1)
                {
                    Clients.Add(ClientFactory.getClient("Client1"));
                }
                else if (rdmType == 2)
                {
                    Clients.Add(ClientFactory.getClient("Client2"));
                }
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
        /*
        public List<IClient> _Clients
        {
            get { return this.Clients; }
            set { this.Clients = value; }
        }
        */
    }
}
