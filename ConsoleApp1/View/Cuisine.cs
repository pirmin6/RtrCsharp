using ConsoleApp1.Model;
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

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.getSprite);

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

        public void getSprite(object sender, PaintEventArgs e)
        {
            float xPosition = Program.appModel.GrandChef.SpriteChef.getX;
            float yPosition = Program.appModel.GrandChef.SpriteChef.getY;
            int width = Program.appModel.GrandChef.SpriteChef.getWidth;
            int height = Program.appModel.GrandChef.SpriteChef.getHeight;
            Image spriteImage = Program.appModel.GrandChef.SpriteChef.getImage;

            e.Graphics.DrawImage(spriteImage, xPosition, yPosition, width, height);
        }
           
        
    }
}
