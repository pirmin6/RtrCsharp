using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public abstract class Observable 
    {
        private List<IServeur> observersServeur = new List<IServeur>();
        private List<IServeur> observersChefRang = new List<IServeur>();
        private List<IServeur> observersMaitreHotel = new List<IServeur>();


        /*
        -------------------------------------------------------------------------------------------------------
        -----------------------------OBSERVEUR--SERVEUR--------------------------------------------------------
        -------------------------------------------------------------------------------------------------------
        */

        public void AttachServeur(IServeur serveur)
        {
            if(!this.observersServeur.Contains(serveur)) this.observersServeur.Add(serveur);
        }

        public void DettachServeur(IServeur serveur)
        {
            if(this.observersServeur.Contains(serveur)) this.observersServeur.Add(serveur);
        }

        protected void NotifyServeur(string action)
        {
            foreach (IServeur obs in this.observersServeur) obs.update(this, action);
        }


        /*
         ------------------------------------------------------------------------------------------------------
         -----------------------------OBSERVEUR--CHEF--RANG----------------------------------------------------
         ------------------------------------------------------------------------------------------------------
        */

        public void AttachChefRang(IServeur chefRang)
        {
            if (!this.observersChefRang.Contains(chefRang)) this.observersChefRang.Add(chefRang);
        }

        public void DettachChefRang(IServeur chefRang)
        {
            if (this.observersChefRang.Contains(chefRang)) this.observersChefRang.Add(chefRang);
        }

        protected void NotifyChefRang(string action)
        {
            foreach (IServeur obs in this.observersChefRang) obs.update(this, action);
        }


        /*
 ------------------------------------------------------------------------------------------------------
 -----------------------------OBSERVEUR--MAITRE--HOTEL--------------------------------------------------
 ------------------------------------------------------------------------------------------------------
*/

        public void AttachMaitreHotel(IServeur maitreHotel)
        {
            if (!this.observersMaitreHotel.Contains(maitreHotel)) this.observersChefRang.Add(maitreHotel);
        }

        public void DettachMaitreHotel(IServeur maitreHotel)
        {
            if (this.observersChefRang.Contains(maitreHotel)) this.observersChefRang.Add(maitreHotel);
        }

        protected void NotifyMaitreHotel(string action)
        {
            foreach (IServeur obs in this.observersMaitreHotel) obs.update(this, action);
        }
    }

}
