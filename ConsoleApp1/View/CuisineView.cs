using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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


            this.monModel = Model;



            Thread kitchenView = new Thread(RefreshRender);
            kitchenView.Start();

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

        public void RefreshRender()
        {
            Boolean refresh = true;
            
            while ( refresh == true)
            {
                this.Paint += new System.Windows.Forms.PaintEventHandler(this.Render);

                Thread.Sleep(100);
            }
            
        }

        public void Render(object sender, PaintEventArgs e)
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/damier.jpg");
            e.Graphics.DrawImage(damier, 0, 0, 1000, 600);

            for (int i = 0; i < monModel.Objects.Count; i++)
            {
                e.Graphics.DrawImage(monModel.Objects.ElementAt(i).getImage,
                    monModel.Objects.ElementAt(i).getX,
                    monModel.Objects.ElementAt(i).getY,
                    monModel.Objects.ElementAt(i).getWidth,
                    monModel.Objects.ElementAt(i).getHeight
                    );
            }

            for (int j = 0; j < monModel.Personnel.Count; j++)
            {
                e.Graphics.DrawImage(monModel.Personnel.ElementAt(j).getImage,
                    monModel.Personnel.ElementAt(j).getX,
                    monModel.Personnel.ElementAt(j).getY,
                    monModel.Personnel.ElementAt(j).getWidth,
                    monModel.Personnel.ElementAt(j).getHeight
                    );
            }
        }
    }
}
