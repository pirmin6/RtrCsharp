using ConsoleApp1.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class appModel
    {
        private List<Sprite> personnel;
        private List<Sprite> objects;
        public appModel()
        {
            personnel = new List<Sprite>();
            objects = new List<Sprite>();

            Chef monChef = new Chef();
            ChefSection monChefSection = new ChefSection();

            personnel.Add(monChef.SpriteChef);
            personnel.Add(monChefSection.SpriteChefSection);
        }

        internal List<Sprite> Personnel { get => personnel; }
        internal List<Sprite> Objects { get => objects; }
    }
}
