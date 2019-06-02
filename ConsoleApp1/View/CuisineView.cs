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
        static System.Windows.Forms.Timer my_Timer = new System.Windows.Forms.Timer();

        Graphics monGraph;


        //public delegate void EventHandler(object sender, EventArgs e);

        //public event DelegueEventHandler Draw;

        public appModel monModel;

        public CuisineView(appModel Model)
        {
            InitializeComponent();

            monGraph = this.CreateGraphics();
            

            this.monModel = Model;
            this.backRender();

            //this.Draw += new DelegueDrawEventHandler(this.Render);

            my_Timer.Tick += new EventHandler(this.Render);

            my_Timer.Interval = 100;

            
            my_Timer.Start();

            
            //Thread kitchenView = new Thread(RefreshRender);
            //kitchenView.Start();

        }



        public void RefreshRender()
        {
            Boolean refresh = true;

            while (refresh == true)
            {
                
            }
        }

        public void backRender()
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/damier.jpg");
            monGraph.DrawImage(damier, 0, 0, 1000, 600);
        }
        public void Render(object sender, EventArgs e)
        {

            for (int i = 0; i < monModel.Objects.Count; i++)
            {
                monGraph.DrawImage(monModel.Objects.ElementAt(i).getImage,
                    monModel.Objects.ElementAt(i).getX,
                    monModel.Objects.ElementAt(i).getY,
                    monModel.Objects.ElementAt(i).getWidth,
                    monModel.Objects.ElementAt(i).getHeight
                    );
            }

            for (int j = 0; j < monModel.Personnel.Count; j++)
            {
                monGraph.DrawImage(monModel.Personnel.ElementAt(j).getImage,
                    monModel.Personnel.ElementAt(j).getX,
                    monModel.Personnel.ElementAt(j).getY,
                    monModel.Personnel.ElementAt(j).getWidth,
                    monModel.Personnel.ElementAt(j).getHeight
                    );
            }
        }
    }
}

