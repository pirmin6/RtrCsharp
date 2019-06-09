using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.Dishes
{
    class RegularPlate : Plate
    {
        public static SemaphoreSlim semaphore = new SemaphoreSlim(0, 3);
    }
}
