using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Commun
{
    public class Carte
    {
        private List<Plat> plats = new List<Plat>();
        

        public Carte()
        {
            Plats.Add(new Plat(1, "kouloutou"));
            Plats.Add(new Plat(2, "Coquillette du auchan"));
            Plats.Add(new Plat(3, "le grec du mec du yilmaz qui bombarde"));

            foreach (Plat plat in Plats)
            {
                Console.WriteLine("La carte contient {0} avec l'ID : {1}", plat.Nom, plat.Id);
            }
        }

        internal List<Plat> Plats { get => plats; set => plats = value; }
    }

    
}
