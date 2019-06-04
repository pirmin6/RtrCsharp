using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Commun
{
    internal class Plat
    {

        private string nom;
        private int id;

        public Plat(int id, string nom)
        {
            this.Id = id;
            this.Nom = nom;

        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        internal static void Add(Plat plat)
        {
            throw new NotImplementedException();
        }
    }
}
