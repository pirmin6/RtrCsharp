﻿using ConsoleApp1.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public interface IObserver
    {
        void update(Desk observable, string message);
    }
}
