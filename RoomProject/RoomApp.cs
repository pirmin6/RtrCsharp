using RoomProject.Controller;
using RoomProject.Model;
using RoomProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomProject
{
    class RoomApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Room Project . . .");

            RoomModel roomModel = new RoomModel();

            RoomView roomView = new RoomView(roomModel);

            Application.Run(roomView);

            Console.WriteLine("Les clients vont arriver !");

            RoomController roomController = new RoomController(roomModel, roomView);

            
        }
    }
}
