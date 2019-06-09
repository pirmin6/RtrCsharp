using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Client;

namespace ConsoleApp2.Model.Object
{
    public class Table : Observable
    {



        private int nbrPlaces;

        private int _nbrPlaces;
        public bool TableOccuper = true;
        static int numéroTable;

        public GroupClient groupeClient;
        



        public Table(int nbrPlaces)
        {
            this._nbrPlaces = nbrPlaces;
            //Console.WriteLine("Une Table a {0} places", nbrPlaces);
            //numéroTable = Interlocked.Increment(ref numéroTable); https://stackoverflow.com/questions/9262221/c-sharp-class-auto-increment-id
        }

        public int getNbrPlaces()
        {
            return _nbrPlaces;
        }

        public void setGroupeClient(GroupClient grp)
        {
            groupeClient = grp;
        }

        public GroupClient getGroupeClient()
        {
            return groupeClient;
        }

        public bool _TableOccuper
        {
            get { return this.TableOccuper; }
            set { this.TableOccuper = value; }
        }

        public int NuméroTable { get => numéroTable; set => numéroTable = value; }
    }
}
