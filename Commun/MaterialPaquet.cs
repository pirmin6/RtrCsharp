using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun
{
    [Serializable()]
    public class MaterialPaquet : Paquet
    {
        public String Material { get; private set; }
        public int Quantity { get; private set; }

        public MaterialPaquet(String material, int quantity) : base(TypePaquet.Material)
        {
            this.Material = material;
            this.Quantity = quantity;
        }
    }
}
