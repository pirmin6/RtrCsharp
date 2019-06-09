using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    abstract class Observable
    {
        private List<Chef> listChef = new List<Chef>();
        private List<Plunger> listPlunger = new List<Plunger>();


        // Ajoute de nouveaux abonnés observeur à l'observable
        public void AttachChef(Chef chef)
        {
            if (!this.listChef.Contains(chef)) this.listChef.Add(chef);
        }

        public void AttachPlunger(Plunger plunger)
        {
            if (!this.listPlunger.Contains(plunger)) this.listPlunger.Add(plunger);
        }


        // Detache les observeur abonnés
        public void DettachChef(Chef chef)
        {
            if (this.listChef.Contains(chef)) this.listChef.Remove(chef);
        }

        public void DettachPlunger(Plunger plunger)
        {
            if (this.listPlunger.Contains(plunger)) this.listPlunger.Remove(plunger);
        }


        // Notify les abonnés 
        protected void NotifyChef()
        {
            foreach (Chef observer in this.listChef) observer.update(this);
        }

        protected void NotifyPlunger()
        {
            foreach (Plunger observer in this.listPlunger) observer.update(this);
        }
    }
}
