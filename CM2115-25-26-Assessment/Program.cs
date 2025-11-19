using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Runtime.InteropServices.Marshalling;
using behaviours.movebehaviours;
using entitys.players;
using rooms;
using Moons;
using Game_Data;

public class Program
{
    public static void Main()
    {
        //Initialise Moon
        Moon Moon = new Moon(new Assurance());
        Moon.Initialise();

        //Initialise Player settings
        Player User = Player.Initialise(Moon.Ship.Rooms["0,0"]);

        //Movement
        while (User.isPlaying)
        {
           User.DisplayCurrentRoomInformation();
           User.Move();
        }
   
    }
}