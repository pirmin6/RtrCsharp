
using RoomProject.Model;
using RoomProject.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomProject.Controller
{
    class RoomController
    {
        RoomModel roomModel;
        RoomView roomView;

        TextBox myTextBox;

        public RoomController(RoomModel roomModel, RoomView roomView)
        {
            this.roomModel = roomModel; this.roomView = roomView;

            roomView.MouseMove += new MouseEventHandler(this.Mouse_Move);

            Console.WriteLine("Instanciation du Controller sans problèmes");
        }

        public void Mouse_Move(object sender, MouseEventArgs e)
        {
            int positionMouseX = e.X;
            int positionMouseY = e.Y;

            if (myTextBox != null) myTextBox.Dispose();

            for (int i = 0; i < roomModel.Personnel.Count; i++)
            {

                if (roomModel.Personnel.ElementAt(i).Hitbox.Contains(positionMouseX, positionMouseY))
                {
                    Console.WriteLine("heeh X -> {0}, Y -> {1}", roomModel.Personnel.ElementAt(i).PositionX, roomModel.Personnel.ElementAt(i).PositionY);

                    myTextBox = new TextBox();
                    myTextBox.Location = new Point(positionMouseX, positionMouseY);
                    myTextBox.BackColor = Color.Black;
                    myTextBox.Height = 100;
                    myTextBox.Width = 150;
                    myTextBox.ForeColor = Color.White;
                    myTextBox.Font = new Font("Bebas", 11);
                    myTextBox.Text = ("SALUT" + roomModel.Personnel.ElementAt(i).PositionX);
                    roomView.Controls.Add(myTextBox);
                }
            }
        }
    }
}
