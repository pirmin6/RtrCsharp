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
            this.kitchenModel = kitchenModel; this.kitchenView = kitchenView;

            kitchenView.MouseMove += new MouseEventHandler(this.Mouse_Move);

            Console.WriteLine("Instanciation du Controller sans problèmes");
        }

        public void Mouse_Move(object sender, MouseEventArgs e)
        {
            int positionMouseX = e.X;
            int positionMouseY = e.Y;

            if (myTextBox != null) myTextBox.Dispose();

            for (int i = 0; i < kitchenModel.Personnel.Count; i++)
            {

                if (kitchenModel.Personnel.ElementAt(i).Hitbox.Contains(positionMouseX, positionMouseY))
                {
                    Console.WriteLine("heeh X -> {0}, Y -> {1}", kitchenModel.Personnel.ElementAt(i).PositionX, kitchenModel.Personnel.ElementAt(i).PositionY);

                    myTextBox = new TextBox();
                    myTextBox.Location = new Point(positionMouseX, positionMouseY);
                    myTextBox.BackColor = Color.Black;
                    myTextBox.Height = 100;
                    myTextBox.Width = 150;
                    myTextBox.ForeColor = Color.White;
                    myTextBox.Font = new Font("Bebas", 11);
                    myTextBox.Text = ("SALUT"+kitchenModel.Personnel.ElementAt(i).PositionX);
                    kitchenView.Controls.Add(myTextBox);
                }
            }
        }
    }
}
