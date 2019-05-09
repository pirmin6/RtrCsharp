using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    class Test1
    {
        public Test1(int nmbre)
        {
            if (nmbre == 1)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("A");
                }
            }
            if (nmbre == 2)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("B");
                }
            }
        }
    }
}
