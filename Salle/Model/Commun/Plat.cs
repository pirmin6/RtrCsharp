using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Commun
{
    internal class Plat
    {
        private string recette;
        private string nom;

        public Plat(string recette, string nom)
        {
            this.recette = recette;
            this.nom = nom;
        }

        internal static void Add(Plat plat)
        {
            throw new NotImplementedException();
        }
    }
}
