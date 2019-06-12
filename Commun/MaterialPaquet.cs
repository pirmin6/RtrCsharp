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
        private int idTable;
        private int quantity;
        private string typeMaterial;


        public MaterialPaquet(int idTable, String material, int quantity) : base(TypePaquet.Material)
        {
            this.idTable = idTable;
            this.quantity = quantity;
            this.typeMaterial = material;
        }

        public int IdTable { get => idTable; set => idTable = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string TypeMaterial { get => typeMaterial; set => typeMaterial = value; }
    }
}


