using ConsoleApp1.Socket;
using KitchenProject.Model;
using KitchenProject.Model.Staff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Commun;
using System.Collections.ObjectModel;

namespace ConsoleApp1.Model.Object
{
    class Desk : Observable
    {
        int positionX = 100;
        int positionY = 100;
        int width = 100;
        int height = 500;
        static Image image = Image.FromFile("C:/asset/Object/comptoir-cuisine.png");


        // Listes d'éléments reçues ou à envoyer, l'observable notify les observeurs concernés lorsqu'un élément est ajouté à une de ces listes
        //private List<MaterialPaquet> listMaterialGet;
        //private List<MaterialPaquet> listMaterialSend;

        //private List<CommandePaquet> listCommandeGet;
        //private List<CommandePaquet> listCommandeSend;

        //private List<DirtyMaterialPaquet> listDirtyMaterial;

        private static ObservableCollection<MaterialPaquet> listMaterialGet = new ObservableCollection<MaterialPaquet>();
        private static ObservableCollection<MaterialPaquet> listMaterialSend = new ObservableCollection<MaterialPaquet>();

        private static ObservableCollection<CommandePaquet> listCommandeGet = new ObservableCollection<CommandePaquet>();
        private ObservableCollection<CommandePaquet> listCommandeSend = new ObservableCollection<CommandePaquet>();

        private static ObservableCollection<DirtyMaterialPaquet> listDirtyMaterial = new ObservableCollection<DirtyMaterialPaquet>();

        Sprite sprite;

        public Desk()
        {
            //listMaterialSend = new List<MaterialPaquet>();
            //listCommandeGet = new List<CommandePaquet>();

            sprite = new Sprite(image, positionX, positionY, width, height);
            //
            listMaterialSend.CollectionChanged += ListMaterialGet_CollectionChanged;
        }

        private void ListMaterialGet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifyPlunger("");
            }
        }

        internal Sprite Sprite { get => sprite; }
    }
}
