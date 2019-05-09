using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salle.Model.Salle
{
    public interface IServeur
    {
        void update(Observable observable, string action);
    }
}
