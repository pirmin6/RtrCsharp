using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenProject.View
{
    public class DrawEventArgs : EventArgs, IDisposable
    {
        public DrawEventArgs()
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
