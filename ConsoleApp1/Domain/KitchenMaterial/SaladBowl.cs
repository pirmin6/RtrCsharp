using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.KitchenMaterial
{
    class SaladBowl : IKitchenMaterial
    {
        private static SemaphoreSlim nbrItemAvailable = new SemaphoreSlim(0, 5);
        public int getnbrItemAvailable()
        {
            return nbrItemAvailable.CurrentCount;
        }

        public void getMaterial()
        {
            nbrItemAvailable.Wait();
        }

        public void releaseMaterial()
        {
            nbrItemAvailable.Release();
        }
    }
}
