using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1.View
{
    public partial class Cuisine : Form
    {

        public Cuisine()
        {
            InitializeComponent();

            FromImageImage(PaintEventArgs e);

            void FromImageImage(PaintEventArgs e)
            {
                Image imageFile = Image.FromFile("smiley.jpg");
                Graphics commis = Graphics.FromImage(imageFile);

                commis.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);
                e.Graphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));
            }
        }

    }
}
