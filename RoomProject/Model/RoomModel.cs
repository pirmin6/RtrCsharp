using RoomProject.Model.Staff;
using System;
using System.Collections.Generic;

namespace RoomProject.Model
{
    public class RoomModel
    {
        private List<Sprite> personnel;
        private List<Sprite> objects;
        public RoomModel()
        {
            personnel = new List<Sprite>();
            objects = new List<Sprite>();

            //Instanciation des objects de la salle et affecté à une liste pour la vue



            //Instanciation du personnel de la salle et affecté à une liste pour la vue
            HostMaster maitreHotel = new HostMaster();
            Waiter serveur1 = new Waiter();
            Waiter serveur2 = new Waiter();
            RankLeader chefRang1 = new RankLeader();
            RankLeader chefRang2 = new RankLeader();

            personnel.Add(maitreHotel.Sprite);
            personnel.Add(serveur1.Sprite);
            personnel.Add(serveur2.Sprite);
            personnel.Add(chefRang1.Sprite);
            personnel.Add(chefRang2.Sprite);


            Console.WriteLine(personnel.Count);


            Console.WriteLine("Instanciation du Model sans problèmes");
        }


        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}

