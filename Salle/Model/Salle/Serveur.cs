using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    delegate void DelegateAction();

    public class Serveur : IServeur
    {
        private int _StockEau = 1000;
        private int _StockPain = 1000;

        public int StockEau { get => _StockEau; set => _StockEau = value; }
        public int StockPain { get => _StockPain; set => _StockPain = value; }

        string RemarquePain;
        string RemarqueEau;
        string RemarqueVin;

        
        public Serveur()
        {
        }

        public void ramasserAssietteCouverts()
        {

        }

        public void servirClients(IClient client)
        {
                
        }

        public void debarrasserTable(GroupeClient Groupe)
        {
            Console.WriteLine("La table a été débarassée!");

            //appelle le chef de rang pour dresser la table
        }


        public void servirPain(GroupeClient groupe)
        { 
            StockPain = StockPain -1;
            Console.WriteLine("le serveur sert du pain chez le client {0}", groupe);
            groupe.PainCorbeille = 1;

        }

        public void servirEau(GroupeClient groupe)
        {
            StockEau = StockEau - 1;
            Console.WriteLine("le serveur sert de l'eau chez le client {0}", groupe);
            groupe.Eau = true;
        }

        public void servirVin(GroupeClient groupe)
        {
            Console.WriteLine("le serveur sert du vin chez le client {0}", groupe);
            groupe.Vin = true;
        }

        public void update(Observable observable, string actionUpdate)
        {
            Console.WriteLine("Le groupe client {0} doit être servis en {1}", observable, actionUpdate);

            GroupeClient groupe = (GroupeClient) observable;
            
            switch(actionUpdate)
            {
                case "ManquePain":
                    this.servirPain(groupe);
                    break;

                case "ManqueEau":
                    this.servirEau(groupe);
                    break;

                case "ManqueVin":
                    this.servirVin(groupe);
                    break;

                case "debarrasserTable":
                    this.debarrasserTable(groupe);
                    break;
            }
        }

        
    }
}
