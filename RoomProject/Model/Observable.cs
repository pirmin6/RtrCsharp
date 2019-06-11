using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Model.Staff;
using RoomProject.Socket;

namespace ConsoleApp2.Model
{
    public abstract class Observable
    {
        private List<IWaiter> ObserversServeur = new List<IWaiter>();
        public List<IWaiter> ObserversChefRang = new List<IWaiter>();
        private List<IWaiter> ObserversMaitreHotel = new List<IWaiter>();
        private List<IWaiter> ObserversSocket = new List<IWaiter>();




        //        /*
        //        -------------------------------------------------------------------------------------------------------
        //        -----------------------------OBSERVEUR--SERVEUR--------------------------------------------------------
        //        -------------------------------------------------------------------------------------------------------
        //        */

        public void AttachServeur(IWaiter serveur)
        {
            if (!this.ObserversServeur.Contains(serveur)) this.ObserversServeur.Add(serveur);
        }

        public void DettachServeur(IWaiter serveur)
        {
            if (this.ObserversServeur.Contains(serveur)) this.ObserversServeur.Add(serveur);
        }

        protected void NotifyServeur(string action)
        {
            foreach (IWaiter obs in this.ObserversServeur)
            {
                if (obs.State == true)
                {
                    continue;
                }

                else
                {
                    obs.Update(this, action);
                    break;
                }
            }
        }


//        /*
//         ------------------------------------------------------------------------------------------------------
//         -----------------------------OBSERVEUR--CHEF--RANG----------------------------------------------------
//         ------------------------------------------------------------------------------------------------------
//        */

        public void AttachChefRang(IWaiter chefRang)
        {
            if (!this.ObserversChefRang.Contains(chefRang)) this.ObserversChefRang.Add(chefRang);
        }

        public void DettachChefRang(IWaiter rankLeader)
        {
            if (this.ObserversChefRang.Contains(rankLeader)) this.ObserversChefRang.Add(rankLeader);
        }

        protected void NotifyChefRang(string action)
        {
            foreach (IWaiter obs in this.ObserversChefRang)
                if (obs.State == true)
                {
                    continue;
                }

                else
                { 
                    obs.Update(this, action);
                    break;
                }
            }


//        /*
// ------------------------------------------------------------------------------------------------------
// -----------------------------OBSERVEUR--MAITRE--HOTEL--------------------------------------------------
// ------------------------------------------------------------------------------------------------------
//*/

        public void AttachMaitreHotel(IWaiter hostMaster)
        {
            if (!this.ObserversMaitreHotel.Contains(hostMaster)) this.ObserversMaitreHotel.Add(hostMaster);

        }

                public void DettachMaitreHotel(IWaiter hostMaster)
                {
                    if (this.ObserversChefRang.Contains(hostMaster)) this.ObserversChefRang.Add(hostMaster);
                }

                protected void NotifyMaitreHotel(string action)
                {
                foreach (IWaiter obs in this.ObserversMaitreHotel)
                if (obs.State == true)
                {
                    continue;
                }

                else
                {
                    obs.Update(this, action);
                    break;
                }
        }

        /*
    // ------------------------------------------------------------------------------------------------------
    // -----------------------------OBSERVEUR--SOCKET------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------
    //*/

        public void AttachSocket(IWaiter Socket)
        {
            if (!this.ObserversSocket.Contains(Socket)) this.ObserversSocket.Add(Socket);

        }

        public void DettachSocket(IWaiter Socket)
        {
            if (this.ObserversSocket.Contains(Socket)) this.ObserversSocket.Add(Socket);
        }

        protected void NotifySocket(string action)
        {
            foreach (IWaiter obs in this.ObserversSocket) obs.Update(this, action);

        }
    }
}
