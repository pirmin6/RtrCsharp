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
    public partial class CuisineView : Form
    {
        public appModel monModel;

        public CuisineView(appModel Model)
        {
            InitializeComponent();
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.damier);

            this.monModel = Model;

            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.getSprite);
            /*
            System.Timers.Timer monTimer = new System.Timers.Timer(1)
            {
                AutoReset = true
            };
            monTimer.Start();
            monTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.render);
            
            //vérifier ses histoire de Timer
            */
        }

        public void Render(PaintEventArgs e)
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/damier.jpg");
            e.Graphics.DrawImage(damier, 0, 0, 1000, 600);

            for (int i = 0; i > monModel.Objects.Count; i++)
            {
                e.Graphics.DrawImage(monModel.Objects.ElementAt(i).getImage,
                    monModel.Objects.ElementAt(i).getX,
                    monModel.Objects.ElementAt(i).getY,
                    monModel.Objects.ElementAt(i).getWidth,
                    monModel.Objects.ElementAt(i).getHeight
                    );
            }

            for (int i = 0; i > monModel.Personnel.Count; i++)
            {
                e.Graphics.DrawImage(monModel.Personnel.ElementAt(i).getImage,
                    monModel.Personnel.ElementAt(i).getX,
                    monModel.Personnel.ElementAt(i).getY,
                    monModel.Personnel.ElementAt(i).getWidth,
                    monModel.Personnel.ElementAt(i).getHeight
                    );
            }
        }

        /*
        public void render(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.getSprite);
        }
        */

           
        
    }
}
