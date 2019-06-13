﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domain.KitchenMaterial
{
    public class WoodenSpoon : IKitchenMaterial
    {
        public string name = "Cuillière en bois";
        private static SemaphoreSlim nbrItemAvailable = new SemaphoreSlim(0, 10);
        public int getnbrItemAvailable()
        {
            return nbrItemAvailable.CurrentCount;
        }

        public void getMaterial()
        {
            nbrItemAvailable.WaitAsync();
        }

        public void releaseMaterial()
        {
            nbrItemAvailable.Release();
        }

        public string getName()
        {
            return name;
        }
    }
}
