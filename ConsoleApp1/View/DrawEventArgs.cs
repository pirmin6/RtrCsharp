using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1.View
{
    public class DrawEventArgs : EventArgs, IDisposable
    {
        private Graphics graphics;
        private Rectangle clipRect;

        public DrawEventArgs(Graphics graphics, Rectangle clipRect)
        {
            this.graphics = graphics;
            this.clipRect = clipRect;
        }


        public Graphics Graphics { get => graphics;}
        public Rectangle ClipRect { get => clipRect;}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
