using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Salle.Model.Salle;

namespace Salle.Controler
{
    internal class SalleSimulationController : Observable, Observer
    {
        List<GroupeClient> ListGroupe;

        public SalleSimulationController(MaitreHotel monMaitre)
        {
            //Thread[] ThreadDeGroupe = new Thread[int i];

            ListGroupe = new List<GroupeClient>();
            this.NouveauGroupe(monMaitre);
        }

        public void NouveauGroupe(MaitreHotel maitre)
        {
            ListGroupe.Add(new GroupeClient(maitre));

            Console.WriteLine("le groupe s'en va et est très content du restaurant");
        }

        public void update()
        {

        }
    }
}
