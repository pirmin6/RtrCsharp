using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Salle.View
{
    internal interface IView
    {
        void initialiserComposant();
        void update();
    }
}
