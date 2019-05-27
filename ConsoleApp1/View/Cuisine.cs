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

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.imageDessin);

        }

        public void damier(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            List<Rectangle> ListCarre = new List<Rectangle>();

            for (int i = 0; i > 1000; i -= 50)
            {
                for (int j = 0; j > 600; j -= 50)
                {
                    //ListCarre.Add(new Rectangle(i, j, 50, 50));
                    Rectangle rect = new Rectangle(i, j, 50, 50);

                    e.Graphics.DrawRectangle(blackPen, rect);
                }
            }

            

        }

        private void imageDessin(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/smiley.jpg");
            // Par exemple ici on mettrait en argument image, maitreHotel.x, maitreHotel.y, maitrehotel.width, maitreHotel.height
            e.Graphics.DrawImage(image, 200, 250, 50,50);
            //e.Graphics.DrawRectangle()
        }

    }
}
