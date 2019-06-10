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
    public class Table 
    {



        private int nbrPlaces;

        private int _nbrPlaces;
        private bool tableOccuper = false;
        public int ID;

        private static List<bool> UsedCounter = new List<bool>();
        private static object Lock = new object();

        public GroupClient groupeClient;

        List<Material> material;
        List<Laundry> laundry;
        



        public Table(int nbrPlaces)
        {
            this._nbrPlaces = nbrPlaces;
            material = new List<Material>();
            laundry = new List<Laundry>();
            //Console.WriteLine("Une Table a {0} places", nbrPlaces);
            //numéroTable = Interlocked.Increment(ref numéroTable); https://stackoverflow.com/questions/9262221/c-sharp-class-auto-increment-id
            lock (Lock)
            {
                int nextIndex = GetAvailableIndex();
                if (nextIndex == -1)
                {
                    nextIndex = UsedCounter.Count;
                    UsedCounter.Add(true);
                }

                ID1 = nextIndex;
            }

           
        }

        private int GetAvailableIndex()
        {
            for (int i = 0; i < UsedCounter.Count; i++)
            {
                if (UsedCounter[i] == false)
                {
                    return i;
                }
            }

            // Nothing available.
            return -1;
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

        public int ID1 { get => ID; set => ID = value; }
        public bool TableOccuper { get => tableOccuper; set => tableOccuper = value; }
        public List<Material> Material { get => material; set => material = value; }
        public List<Laundry> Laundry { get => laundry; set => laundry = value; }
    }
}
