using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Material
{
    class Stove : KitchenMaterial
    {
        private static SemaphoreSlim nbrItemAvailable = new SemaphoreSlim(0, 10);
        public static int getnbrItemAvailable()
        {
            return nbrItemAvailable.CurrentCount;
        }

        public static void getMaterial()
        {
            nbrItemAvailable.Wait();
        }

        public void releaseMaterial()
        {
            nbrItemAvailable.Release();
        }
    }
}
