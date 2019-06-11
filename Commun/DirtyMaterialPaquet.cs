using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun
{
    public class DirtyMaterialPaquet : Paquet
    {
        private int idTable;
        private int quantity;
        private string typeMaterial;

        public DirtyMaterialPaquet(int idTable, string typeMaterial, int quantity) : base(TypePaquet.DirtyMaterial)
        {
            this.idTable = idTable;
            this.TypeMaterial = typeMaterial;
            this.Quantity = quantity;
        }

        public int IdTable { get => idTable; set => idTable = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string TypeMaterial { get => typeMaterial; set => typeMaterial = value; }
    }
}
