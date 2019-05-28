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

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.damier);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.imageDessin);
            
        }

        public void damier(object sender, PaintEventArgs e)
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/damier.jpg");
            e.Graphics.DrawImage(damier, 0, 0, 1000, 600);
        }

        private void imageDessin(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/Staff/chef.png");
            e.Graphics.DrawImage(image, 500, 250, 100, 100);
        }

    }
}
