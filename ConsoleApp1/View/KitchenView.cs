using KitchenProject.Model;
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



namespace KitchenProject.View
{
    public partial class KitchenView : Form
    {
        // Creation d'un nouveau Timer pour redessiner la vue a interval de temps définie
        static System.Windows.Forms.Timer my_Timer = new System.Windows.Forms.Timer();

        // Declaration d'un Objet Graphics qui va permettre de dessiner dessus
        private Graphics graphicsElement;

        public KitchenModel kitchenModel;


        public KitchenView(KitchenModel kitchenModel)
        {
            InitializeComponent();

            this.kitchenModel = kitchenModel;

            GraphicsElement = this.CreateGraphics();

            my_Timer.Tick += new EventHandler(this.Render);
           
            my_Timer.Interval = 100;

            my_Timer.Start();

            Console.WriteLine("L'instanciation de la View est Réussis");
        }

        public void Render(object sender, EventArgs e)
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/damier.jpg");
            GraphicsElement.DrawImage(damier, 0, 0, 1000, 600);

            for (int i = 0; i < kitchenModel.Objects.Count; i++)
            {
                GraphicsElement.DrawImage(kitchenModel.Objects.ElementAt(i).SpriteImage,
                    kitchenModel.Objects.ElementAt(i).PositionX,
                    kitchenModel.Objects.ElementAt(i).PositionY,
                    kitchenModel.Objects.ElementAt(i).Width,
                    kitchenModel.Objects.ElementAt(i).Height
                    );
            }

            for (int j = 0; j < kitchenModel.Personnel.Count; j++)
            {
                GraphicsElement.DrawImage(kitchenModel.Personnel.ElementAt(j).SpriteImage,
                    kitchenModel.Personnel.ElementAt(j).PositionX,
                    kitchenModel.Personnel.ElementAt(j).PositionY,
                    kitchenModel.Personnel.ElementAt(j).Width,
                    kitchenModel.Personnel.ElementAt(j).Height
                    );
            }
        }

        public Graphics GraphicsElement { get => graphicsElement; set => graphicsElement = value; }
    }
}

