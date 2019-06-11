﻿using ConsoleApp1.Socket;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commun;

namespace ConsoleApp1.Model
{
    abstract class Observable
    {
        private List<Chef> listChef = new List<Chef>();
        private List<Plunger> listPlunger = new List<Plunger>();
        private List<SocketApp> listSocketApp = new List<SocketApp>();

        private List<System.Object> listOnDesk = new List<System.Object>();
        private List<MaterialPaquet> listMaterialDemander = new List<MaterialPaquet>();




        // Ajoute de nouveaux abonnés observeur à l'observable
        public void AttachChef(Chef chef)
        {
            if (!this.listChef.Contains(chef)) this.listChef.Add(chef);
        }

        public void AttachPlunger(Plunger plunger)
        {
            if (!this.listPlunger.Contains(plunger)) this.listPlunger.Add(plunger);
        }

        public void AttachSocket(SocketApp socket)
        {
            if (!this.listSocketApp.Contains(socket)) this.listSocketApp.Add(socket);
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

        public void DettachSocket(SocketApp socket)
        {
            if (this.listSocketApp.Contains(socket)) this.listSocketApp.Remove(socket);
        }


        // Notify les abonnés 
        protected void NotifyChef(string message)
        {
            foreach (Chef observer in this.listChef) observer.update(this, message);
        }

        protected void NotifyPlunger(string message)
        {
            foreach (Plunger observer in this.listPlunger) observer.update(this, message);
        }

        protected void NotifySocket(string message)
        {
            foreach (SocketApp observer in this.listSocketApp) observer.update(this, message);
        }


        public List<object> ListOnDesk { get => listOnDesk; set => listOnDesk = value; }
        public List<MaterialPaquet> ListMaterialDemander { get => listMaterialDemander; set => listMaterialDemander = value; }
    }
}
