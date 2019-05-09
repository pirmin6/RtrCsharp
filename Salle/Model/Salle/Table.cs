using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public class Table
    {



        private int nbrPlaces;

        private int _nbrPlaces;
        public bool TableOccuper = true;

        public GroupeClient groupeClient;



        public Table(int nbrPlaces)
        {
            this._nbrPlaces = nbrPlaces;
            Console.WriteLine("Une Table a {0} places", nbrPlaces);
        }

        public int getNbrPlaces() {
            return _nbrPlaces;
        }

        public void setGroupeClient(GroupeClient grp) {
            groupeClient = grp;
        }

        public GroupeClient getGroupeClient() {
            return groupeClient;
        }

        public bool _TableOccuper
        {
            get { return this.TableOccuper; }
            set { this.TableOccuper = value; }
        }
    }
}
