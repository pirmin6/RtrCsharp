using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.KitchenMaterial
{
    interface IKitchenMaterial
    {
        int getnbrItemAvailable();

        void getMaterial();

        void releaseMaterial();

    }
}
