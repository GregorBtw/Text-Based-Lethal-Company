using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;
using System.Runtime.InteropServices.Marshalling;
using behaviours.movebehaviours;
using entitys.players;
using rooms;
using Moons;

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
      
        while (User.HP > 0)
        {
            Console.WriteLine($"{User.Name} Where would you like to move?");

            foreach (var kvp in User.CurrentRoom.SurroundingRooms)
            {
                Console.WriteLine(kvp.Key);
            }
            var Result = Console.ReadLine();

            Console.Clear();

            if (User.CurrentRoom.SurroundingRooms.TryGetValue(Result, out Room nextRoom))
            {
                User.CurrentRoom = nextRoom; // move the player
                Console.WriteLine($"You moved to {nextRoom.Name}.");
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        


        }
   
    }
}