using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Model.Staff
{
    public interface IWaiterCounter
    {
        bool State { get; set; }
        void update(Observable observable, string action);
    }
}
