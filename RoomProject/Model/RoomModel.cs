using RoomProject.Model.Staff;
using System;
using System.Collections.Generic;
using RoomProject.Model.Staff;
using ConsoleApp2.Model.Client;
using ConsoleApp2.Model.Object;
using ConsoleApp2.Model.Staff;
using System.Threading;
using RoomProject.Socket;

namespace RoomProject.Model
{
    public class RoomModel
    {
        private List<Sprite> personnel;
        private List<Sprite> objects;

        Square Carre1;
        Square Carre2;

        RankLeader ChefRangCarre1;
        RankLeader ChefRangCarre2;

        RankLeader chefRang1;
        RankLeader chefRang2;

        Menu Menu;

        Counter counter;

        List<GroupClient> ListGroupe;
        


        public RoomModel()
        {
            SocketApp socket = new SocketApp();
            
  

            personnel = new List<Sprite>();
            objects = new List<Sprite>();

            //Instanciation des objects de la salle et affecté à une liste pour la vue



            //Instanciation du personnel de la salle et affecté à une liste pour la vue
            Waiter serveur1;
            Waiter serveur2;
            HostMaster maitreHotel;

            serveur1 = new Waiter();
            serveur2 = new Waiter();
            chefRang1 = new RankLeader();
            chefRang2 = new RankLeader();
            this.CreationTable();
            maitreHotel = new HostMaster(chefRang1, chefRang2, Carre1, Carre2);
            this.CreationMenu();
            counter = new Counter(serveur1, serveur2);

            personnel.Add(maitreHotel.Sprite);
            personnel.Add(serveur1.Sprite);
            personnel.Add(serveur2.Sprite);
            personnel.Add(chefRang1.Sprite);
            personnel.Add(chefRang2.Sprite);

            Thread.Sleep(1000);
            Console.WriteLine("Le nombre de personel est de :" + personnel.Count);

            Thread.Sleep(2000);
            Console.WriteLine("Les clients vont arriver !");

            ListGroupe = new List<GroupClient>();

            
                Thread.Sleep(2000);


            GroupClient groupClient = new GroupClient(maitreHotel, serveur1, serveur2);
            maitreHotel.ListGroupe1.Add(groupClient);
            foreach (RankLeader rankLeader in groupClient.ObserversChefRang)
            {
                rankLeader.PoserCommandeComptoir(groupClient, counter);
            }
            serveur1.servirClients(groupClient);

            //groupClient.clientsCommande(Menu);
            //chefRang1.prendreCommande(counter, groupClient);
            //Thread.Sleep(5000);
            //serveur1.servirClients(groupClient);
            //groupClient.MangerRepas();



            Console.WriteLine("Instanciation du Model sans problèmes \n \n");

            


            Console.WriteLine("Instanciation du Model sans problèmes");


           // this.CreateCustomers();  

        }

        public void CreateCustomers()
        {

            

        }

        private void CreationTable()
        {
            /********************CREER TABLEAU POUR PREMIER CARRE******************************/

            int[][] TablesCarre1 = new int[2][];
            TablesCarre1[0] = new int[5];
            TablesCarre1[0][0] = 2;
            TablesCarre1[0][1] = 4;
            TablesCarre1[0][2] = 6;
            TablesCarre1[0][3] = 8;
            TablesCarre1[0][4] = 4;

            TablesCarre1[1] = new int[5];
            TablesCarre1[1][0] = 2;
            TablesCarre1[1][1] = 4;
            TablesCarre1[1][2] = 6;
            TablesCarre1[1][3] = 8;
            TablesCarre1[1][4] = 4;



            /********************DEUXIEME CARRE******************************/

            int[][] TablesCarre2 = new int[2][];
            TablesCarre2[0] = new int[6];
            TablesCarre2[0][0] = 2;
            TablesCarre2[0][1] = 4;
            TablesCarre2[0][2] = 8;
            TablesCarre2[0][3] = 6;
            TablesCarre2[0][4] = 4;
            TablesCarre2[0][5] = 2;


            TablesCarre2[1] = new int[4];
            TablesCarre2[1][0] = 2;
            TablesCarre2[1][1] = 4;
            TablesCarre2[1][2] = 8;
            TablesCarre2[1][3] = 10;

            Carre1 = new Square(TablesCarre1, chefRang1);
            Carre2 = new Square(TablesCarre2, chefRang2);
            Console.WriteLine("Les 2 carrés ont été instanciés");
            Thread.Sleep(1000);
        }

        private void CreationChefsRang()
        {
            ChefRangCarre1 = new RankLeader();
            ChefRangCarre2 = new RankLeader();
        }

        private void CreationMenu()
        {
            Menu = new Menu();
        }

        private void GenerateClients()
        {
                

        }
        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}

