using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun
{
    [Serializable()]
    public class CommandePaquet : Paquet
    {
        private int idTable;
        List<int> listPlats;

        public CommandePaquet(int idTable, List<int> listPlats) : base(TypePaquet.Commande)
        {
            this.idTable = idTable;
            this.ListPlats = new List<int>();
            this.ListPlats = listPlats;
        }

        public int IdTable { get => idTable; set => idTable = value; }
        public List<int> ListPlats { get => listPlats; set => listPlats = value; }
    }
}
