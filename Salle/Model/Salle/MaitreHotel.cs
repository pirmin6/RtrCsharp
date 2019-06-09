using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{



    public class MaitreHotel : Observable, IServeur

    {
        private Carre _Carre1;
        private Carre _Carre2;


        List<Table> Carre1TableDispo;
        List<Table> Carre2TableDispo;

        private ChefRang chefRang;
        private int Attente;
        private List<Table> tablesLibres;

        public MaitreHotel(Carre Carre1, Carre Carre2)

        {
            Console.WriteLine("Bonjour je suis BEN");
            _Carre1 = Carre1;
            _Carre2 = Carre2;

            this.RecupererTableDispo();
            //this.AttribuerTable();
        }

        public void RecupererTableDispo()
        {
            Carre1TableDispo = _Carre1.getTablesDispo();
            Carre2TableDispo = _Carre2.getTablesDispo();

            Console.WriteLine("Il y a {0} tables dispo dans le carre 1 et {1} dispo dans le carre 2", Carre1TableDispo.Count(), Carre2TableDispo.Count());
        }

        public void AttribuerTable(GroupeClient Groupe)
        {
            Console.WriteLine("ich bin da");
            int nbrClient = 7;

            if (Carre1TableDispo.Count() <= Carre2TableDispo.Count())
            {
                List<int> Associe = new List<int>();

                for (int i = 0; i < Carre2TableDispo.Count(); i++)
                {
                    Associe.Add(Carre2TableDispo[i].getNbrPlaces());
                }

                for (int i = 0; i <= Associe.Count(); i++)
                {
                    if (nbrClient <= Associe[i])
                    {
                        Console.WriteLine("On associe la Table {0} qui a {1} places", Carre2TableDispo[i], Associe[i]);
                        _Carre2.ChefRangCarre.placerClientTable(Groupe, Carre2TableDispo[i]);

                        break;
                    }
                }
            }

            else
            {
                List<int> Associe2 = new List<int>();

                for (int i = 0; i < Carre1TableDispo.Count(); i++)
                {
                    Associe2.Add(Carre1TableDispo[i].getNbrPlaces());
                }

                for (int i = 0; i <= Associe2.Count(); i++)
                {
                    if (nbrClient <= Associe2[i])
                    {
                        Console.WriteLine("On associe la Table {0} qui a {1} places", Carre1TableDispo[i], Associe2[i]);
                        _Carre1.ChefRangCarre.placerClientTable(Groupe, Carre1TableDispo[i]);
                        break;
                    }
                }
            }
        }


        public void encaisseClient(GroupeClient groupe)
        {
            //client se barre
        }

        /*
        public void appelleChefRang()
        {
            //NotifyChefRang();
        }

        public void ajouteClient()
        {

        }
        */

        public void update(Observable observable, string actionUpdate)
        {
            GroupeClient groupe = (GroupeClient)observable;

            switch (actionUpdate)
            {
                case "demanderTable":
                    this.AttribuerTable(groupe);
                    break;

                case "ManqueEau":
                    this.encaisseClient(groupe);
                    break;
            }
        }
    }
}
