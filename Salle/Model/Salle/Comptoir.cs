﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle.Controler;

namespace Salle.Model.Salle
{
    public class Comptoir
    {
        public List<List<int>> CommandeEnvoie;

        public Comptoir()
            {
                new List<List<int>>();
            }

        public List<List<int>> CommandeEnvoie1 { get => CommandeEnvoie; set => CommandeEnvoie = value; }

        public void EnvoyerCommande()
        {
            SocketCommande socketCommande = new SocketCommande();
            //socketCommande.sendCMD(comptoir);
        }
    }
}
