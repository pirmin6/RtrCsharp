﻿using ConsoleApp1.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    class App
    {
        //C'est dans cette classe que l'on va instancier tous les modèles
        Chef grandChef; 

        public App()
        {
            grandChef = new Chef();
        }

        internal Chef GrandChef { get => grandChef;}
    }
}
