﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Staff
{
    public interface IWaiter
    {
        void Update(Observable observable, string action);
    }
}
