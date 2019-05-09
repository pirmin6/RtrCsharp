using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Commun
{
    internal class Vin
    {
        private string nom;
        private int annee; // dateTime.ToString https://docs.microsoft.com/fr-fr/dotnet/api/system.datetime.tostring?view=netframework-4.7.2

        public Vin(string nom, int annee)
        {
            this.nom = nom;
            this.annee = annee;
        }
    }
}
