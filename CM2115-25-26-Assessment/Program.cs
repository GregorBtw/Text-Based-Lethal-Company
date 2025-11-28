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
        // --- Initialize the Moon ---
        // Creates a moon with a specific type (Assurance) and sets up its Ship and Warehouse maps.
        Moon Moon = new Moon(new Assurance());
        Moon.Initialise();

        // --- Display game introduction ---
        // Shows instructions and waits for player input to begin.
        GameData.displayGameInfo();

        // --- Initialize Player ---
        // Prompts the player for a username and sets initial stats in the Ship starting room.
        Player User = Player.Initialise(Moon.Ship.Rooms["0,0"]);

        // --- Initialize GameData ---
        // Sets game-wide data such as quota and references to the player.
        GameData gameData = GameData.Initialise(150, User);

        // --- Attach player's health bar as an observer to track HP changes ---
        User.AttachObserver(User.HealthBar);
        User.SetHp(User.HP); // Triggers health bar display

        // --- Main Game Loop ---
        // Continues running while the player is alive and playing.
        while (User.isPlaying)
        {
           // Handles player actions like moving, picking up items, solving puzzles, and combat.
           User.CompleteAction(gameData, Moon);
        }
    }
}
