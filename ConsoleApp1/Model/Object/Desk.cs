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

        private ObservableCollection<MaterialPaquet> listMaterialGet;
        private ObservableCollection<MaterialPaquet> listMaterialSend;

        private ObservableCollection<CommandePaquet> listCommandeGet;
        private ObservableCollection<CommandePaquet> listCommandeSend;

        private ObservableCollection<DirtyMaterialPaquet> listDirtyMaterial;

        Sprite sprite;

        public Desk()
        {

        listMaterialGet = new ObservableCollection<MaterialPaquet>();
        listMaterialSend = new ObservableCollection<MaterialPaquet>();

        listCommandeGet = new ObservableCollection<CommandePaquet>();
        listCommandeSend = new ObservableCollection<CommandePaquet>();

        listDirtyMaterial = new ObservableCollection<DirtyMaterialPaquet>();

        
        // Ajout des Delegate aux évènements "Ajout dans la collection"
        ListMaterialSend.CollectionChanged += ListMaterialSend_CollectionChanged;
        ListMaterialGet.CollectionChanged += ListMaterialGet_CollectionChanged;
        ListDirtyMaterial.CollectionChanged += ListDirtyMaterialGet_CollectionChanged;
        ListCommandeSend.CollectionChanged += ListCommandeSend_CollectionChanged;
        ListCommandeGet.CollectionChanged += ListCommandeGet_CollectionChanged;


        sprite = new Sprite(image, positionX, positionY, width, height);
        }



        private void ListCommandeGet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifyChef("CommandeGet");
            }
        }

        private void ListMaterialGet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifyPlunger("DemandMaterial");
            }
        }

        private void ListDirtyMaterialGet_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifyPlunger("DirtyMaterial");
            }
        }

        private void ListCommandeSend_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifySocket("SendCommand");
            }
        }

        private void ListMaterialSend_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifySocket("SendMaterial");
            }
        }



        //------------------------OVERRIDE
        internal Sprite Sprite { get => sprite; }
        public ObservableCollection<MaterialPaquet> ListMaterialSend { get => listMaterialSend; set => listMaterialSend = value; }
        public ObservableCollection<CommandePaquet> ListCommandeSend { get => listCommandeSend; set => listCommandeSend = value; }
        public ObservableCollection<MaterialPaquet> ListMaterialGet { get => listMaterialGet; set => listMaterialGet = value; }
        public ObservableCollection<CommandePaquet> ListCommandeGet { get => listCommandeGet; set => listCommandeGet = value; }
        public ObservableCollection<DirtyMaterialPaquet> ListDirtyMaterial { get => listDirtyMaterial; set => listDirtyMaterial = value; }
    }
}
