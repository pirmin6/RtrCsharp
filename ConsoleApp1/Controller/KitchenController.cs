using KitchenProject.Model;
using KitchenProject.View;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace KitchenProject.Controller
{
    class KitchenController
    {
        private KitchenModel kitchenModel;
        private KitchenView kitchenView;

        TextBox myTextBox;

        public KitchenController(KitchenModel kitchenModel, KitchenView kitchenView)
        {
            Console.WriteLine("salut");
            this.kitchenModel = kitchenModel; this.kitchenView = kitchenView;

            kitchenView.MouseMove += new MouseEventHandler(this.Mouse_Move);
        }

        public void Mouse_Move(object sender, MouseEventArgs e)
        {
            int positionMouseX = e.X;
            int positionMouseY = e.Y;

            for (int i = 0; i < kitchenModel.Personnel.Count; i++)
            {
                if (positionMouseX == kitchenModel.Personnel.ElementAt(i).PositionX && positionMouseY == kitchenModel.Personnel.ElementAt(i).PositionY)
                {
                        Console.WriteLine("heeh X -> {0}, Y -> {1}", kitchenModel.Personnel.ElementAt(i).PositionX, kitchenModel.Personnel.ElementAt(i).PositionY);

                        myTextBox = new TextBox();
                        myTextBox.BackColor = Color.Black;
                        myTextBox.Height = 100;
                        myTextBox.Width = 150;
                        myTextBox.ForeColor = Color.White;
                        myTextBox.Font = new Font("Bebas", 11);
                        myTextBox.Text = ("/n SALUT"+kitchenModel.Personnel.ElementAt(i).PositionX);
                        kitchenView.Controls.Add(myTextBox);
                }
            }
            //if (myTextBox != null) myTextBox.Dispose();
        }
    }
}
