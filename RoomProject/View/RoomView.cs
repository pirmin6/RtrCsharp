
using RoomProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RoomProject.View
{
    public partial class RoomView : Form
    {
        RoomModel roomModel;

        // Creation d'un nouveau Timer pour redessiner la vue a interval de temps définie
        static System.Windows.Forms.Timer my_Timer = new System.Windows.Forms.Timer();

        // Declaration d'un Objet Graphics qui va permettre de dessiner dessus
        private Graphics graphicsElement;


        public RoomView(RoomModel roomModel)
        {
            this.roomModel = roomModel;
            
            InitializeComponent();

            GraphicsElement = this.CreateGraphics();

            my_Timer.Tick += new EventHandler(this.Render);

            my_Timer.Interval = 100;

            my_Timer.Start();

            Console.WriteLine("L'instanciation de la View est Réussis");
        }


        public void Render(object sender, EventArgs e)
        {
            Image damier = Image.FromFile("D:/POO/CSHARP/RtrCsharp/asset/room-floor.jpg");
            GraphicsElement.DrawImage(damier, 0, 0, 1000, 600);

            for (int i = 0; i < roomModel.Objects.Count; i++)
            {
                GraphicsElement.DrawImage(roomModel.Objects.ElementAt(i).SpriteImage,
                    roomModel.Objects.ElementAt(i).PositionX,
                    roomModel.Objects.ElementAt(i).PositionY,
                    roomModel.Objects.ElementAt(i).Width,
                    roomModel.Objects.ElementAt(i).Height
                    );
            }

            for (int j = 0; j < roomModel.Personnel.Count; j++)
            {
                GraphicsElement.DrawImage(roomModel.Personnel.ElementAt(j).SpriteImage,
                    roomModel.Personnel.ElementAt(j).PositionX,
                    roomModel.Personnel.ElementAt(j).PositionY,
                    roomModel.Personnel.ElementAt(j).Width,
                    roomModel.Personnel.ElementAt(j).Height
                    );
            }
        }

        public Graphics GraphicsElement { get => graphicsElement; set => graphicsElement = value; }
    }
}
