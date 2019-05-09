using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Salle.Model.Salle;

namespace Vue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // On doit utilisé les coordonnés depuis le model avec le using et dans les méthodes changer les coordonés
        private void MaitreHotel(object sender, PaintEventArgs e, MaitreHotel maitreHotel)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/MaitreHotel.png");
            // Par exemple ici on mettrait en argument image, maitreHotel.x, maitreHotel.y, maitrehotel.width, maitreHotel.height
            e.Graphics.DrawImage(image, 450, 250, 100, 100);
        }

        private void ChefRang(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/ChefRang.png");
            e.Graphics.DrawImage(image, 300, 200, 100, 100);
        }


        private void Serveur(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/Serveur.png");
            e.Graphics.DrawImage(image, 150, 250, 100, 100);
        }

        private void Client(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/Client.png");
            e.Graphics.DrawImage(image, 300, 350, 100, 100);
        }



        private void Table(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/Table.png");
            e.Graphics.DrawImage(image, 0, 0, 150, 150);
        }

        private void Table2(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/Table.png");
            e.Graphics.DrawImage(image, 300, 0, 150, 150);
        }

        private void Table3(object sender, PaintEventArgs e)
        {
            Image image = Image.FromFile("C:/Users/Meyer/Projet-Programmation-Systeme/Salle/Vue/Properties/Table.png");
            e.Graphics.DrawImage(image, 600, 0, 150, 150);
        }

    }
}
