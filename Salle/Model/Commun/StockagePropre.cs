using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Commun
{
    internal class StockagePropre
    {
        private List<Vaiselle> vaiselleDispo = new List<Vaiselle>();
        private List<Textile> textileDispo = new List<Textile>();

        public StockagePropre(List<Vaiselle> vaiselleDispo, List<Textile> textileDispo)
        {
        }
    }
}
