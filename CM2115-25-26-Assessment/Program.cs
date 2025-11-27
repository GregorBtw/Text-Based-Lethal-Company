using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Runtime.InteropServices.Marshalling;
using behaviours.movebehaviours;
using entitys.players;
using rooms;
using Moons;
using Game_Data;
using Observers.HealthBar;

public class Program
{
    public static void Main()
    {
        //Initialise Moon
        Moon Moon = new Moon(new Assurance());
        Moon.Initialise();

        //Introduction
        GameData.displayGameInfo();

        //Initialise Player settings
        Player User = Player.Initialise(Moon.Ship.Rooms["0,0"]);
        GameData gameData = GameData.Initialise(150, User);
        User.AttachObserver(User.HealthBar);
        User.SetHp(User.HP);

        //Movement
        while (User.isPlaying)
        {
           User.CompleteAction(gameData);

        }

    }
}