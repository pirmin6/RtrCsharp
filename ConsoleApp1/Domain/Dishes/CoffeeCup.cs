using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Dishes
{
    class CoffeeCup : Glass
    {
        private static SemaphoreSlim nbrItemAvailable = new SemaphoreSlim(0, 50);
        public static int getnbrItemAvailable()
        {
            return nbrItemAvailable.CurrentCount;
        }

        public static void getVaiselle()
        {
            nbrItemAvailable.Wait();
        }

        public void releaseVaiselle()
        {
            nbrItemAvailable.Release();
        }
    }
}
