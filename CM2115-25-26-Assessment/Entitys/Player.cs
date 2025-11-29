using System;
using entitys;
using inventory;
using rooms;
using maps;
using System.Reflection.Metadata;
using Observers.HealthBar;
using Game_Data;
using interfaces.Observer;
using behaviours.attackbehaviours;
using items;
using Moons;

namespace entitys.players;

public class Player : Entity 
{
    // Singleton player instance — ensures only one player exists in the game.
    private static Player? instance = null;

    // Determines whether the player is still in the game loop.
    public bool isPlaying = true;

    // Basic gameplay stats.
    public int EnemysKilled = 0;
    public int PuzzlesSolved = 0;
    public int ScrapValueCollected = 0;

    // Inventory system and current room the player is located in.
    public Inventory Inventory { get; set; }
    public Room CurrentRoom { get; set; }

    // Private constructor because Player is a singleton.
    private Player(String name, int hp, Room currentRoom, Inventory inventory)
        : base(name, hp)
    {
        this.Inventory = inventory;
        this.CurrentRoom = currentRoom;
    }

    // Creates or returns the single player instance.
    // Handles username validation and starting values.  
    public static Player Initialise(Room startRoom)
    {
        Console.WriteLine("\nPlease enter a username! (Greater than 3 characters, fewer than 15): ");
        String? Username = Console.ReadLine();

        // Simple username length validation loop.
        while ((Username ?? "").Length <= 3 || (Username ?? "").Length >= 15)
        {
            Console.Clear();
            Console.WriteLine("Username must be longer than 3 characters, and shorter than 15");
            Console.WriteLine("Please enter a username!: ");
            Username = Console.ReadLine();
        }

        string validUsername = Username!;

        // Only create the player once.
        if (instance == null)
        {
            instance = new Player(validUsername, 100, startRoom, new Inventory());
        }

        return instance;
    }

    // Handles player movement between connected rooms.
    // Prints available paths and performs a loading animation.
    public static void Move()
    {
        Console.WriteLine($"\nWhere would you like to move {instance!.Name}?");

        Console.WriteLine("-------------------------------");
        foreach (var room in instance.CurrentRoom.SurroundingRooms)
        {
            // Shows available movement options.
            Console.WriteLine($"{room.Key} -> {room.Value.Name}");
        }
        Console.WriteLine("-------------------------------");

        string? Str = Console.ReadLine();

        string firstPart = (Str ?? "").Substring(0,1).ToUpper();     
        string secondPart = (Str ?? "").Substring(1).ToLower();     

        string Input = firstPart + secondPart;

        // If the key exists, move to that room.
        if (instance.CurrentRoom.SurroundingRooms.TryGetValue(Input, out Room? nextRoom))
        {

            bool isRoomLocked = nextRoom.CheckForLock(instance);

            if (isRoomLocked)
            { 
                return;
            }

            Console.Clear();

            // Basic loading effect for feedback.
            var Loading = "Loading";
            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine(Loading);
                Loading += ".";
                Thread.Sleep(500);
                Console.Clear();
            }

            instance.CurrentRoom = nextRoom;
            Console.Clear();
            Console.WriteLine($"You moved to {nextRoom.Name}.\n");
        }
        else
        {
            Console.WriteLine("Invalid choice, please try again.");
            Thread.Sleep(2000);
        }
    }

    // Player uses a weapon's behaviour to attack the enemy in the current room.
    public void AttackEnemy(Item Weapon)
    {
        Weapon.ItemBehaviour.Use(CurrentRoom.Enemy, 1);
    }

    // Sells the player's scrap and ends the game.
    // If the quota is met → win. Otherwise → fail.
    public void SellScrap(int quota)
    {
        Console.Clear();

        Console.WriteLine("Are you sure you want to sell your scrap, 'yes' or 'no'?\n");
        Console.WriteLine("Once you do, you can not go back into the Warehouse");
        String? Str = Console.ReadLine();
        String? Input = (Str ?? "").ToLower();

        if (Input == "yes")
        {
            // Loading animation before result.
            var Loading = "Loading";
            for (var i = 0; i < 4; i++)
            {
                Console.WriteLine(Loading);
                Loading += ".";
                Thread.Sleep(500);
                Console.Clear();
            }

            // Compare collected scrap to quota.
            if (ScrapValueCollected >= quota)
            {
                Console.WriteLine("Congratulations, you beat the quota, have a nice day!");
                Thread.Sleep(2500);
                isPlaying = false;  // End game (success)
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You did not meet the quota\n");
                Thread.Sleep(2500);
                Console.Clear();

                // Ejecting animation for failure.
                var Ejecting = "Ejecting";
                for (var i = 0; i < 4; i++)
                {
                    Console.WriteLine(Ejecting);
                    Ejecting += ".";
                    Thread.Sleep(500);
                    Console.Clear();
                }

                isPlaying = false;  // End game (failure)
                return;
            }
        }
        else if (Input == "no")
        {
            // Player cancelled the scrap-selling action.
            Console.Clear();
            return;
        }
    }

    // Main per-room action loop for the player.
    // Handles movement, picking up items, dropping items,
    // encountering puzzles/enemies, and ship terminal use.
    public void CompleteAction(GameData gameData, Moon moon)
    {
        var CompletingActions = true;

        while (CompletingActions)
        {
            bool ItemsInRoom = false;
            bool HasItems = false;

            // Allows the room to trigger any encounters or puzzles.
            CurrentRoom.CheckForEnemy(instance!);
            CurrentRoom.CheckForPuzzle(instance!);

            // Only continue if player is alive and still playing.
            if (HP > 0 && isPlaying == true)
            {
                gameData.displayUIinfo(HealthBar, CurrentRoom);
                Console.WriteLine($"What would you like to do next {instance!.Name}?\n");
                Thread.Sleep(500);

                // Shows terminal option only if the player is in the ship.
                bool inShip = moon.CheckIfInShip(instance);
                if (inShip)
                {
                    Console.WriteLine("• Use ship terminal- Press [T]");
                }

                // Only show pickup option if items exist in the room.
                if (CurrentRoom.Items.Count > 0)
                {
                    Console.WriteLine("• Equip an item in this room - Press [E]");
                    ItemsInRoom = true;
                }

                Console.WriteLine("• Move to another room - Press [M]");

                // Only show drop option if player has items.
                if (Inventory.Items.Count > 0)
                {
                    Console.WriteLine("• Drop an item in this room - Press [D]");
                    HasItems = true;
                }

                String RawInput = Console.ReadLine();
                String Input = (RawInput ?? "").Trim().ToLower();

                // Action handling:
                if (Input == "e" && ItemsInRoom)
                {
                    gameData.displayUIinfo(HealthBar, CurrentRoom);
                    CurrentRoom.PickUpItem(Inventory);
                    Inventory.UpdateCollectedScrap(instance);
                }
                else if (Input == "m")
                {
                    // Breaks the inner loop so the main loop calls Move().
                    CompletingActions = false;
                    gameData.displayUIinfo(HealthBar, CurrentRoom);
                    Move();
                }
                else if (Input == "d" && HasItems)
                {
                    gameData.displayUIinfo(HealthBar, CurrentRoom);
                    CurrentRoom.DropItem(Inventory);
                    Inventory.UpdateCollectedScrap(instance);
                }
                else if (Input == "t")
                {
                    gameData.PromptTerminal();
                }
                else
                {
                    // Invalid inputs redisplay UI and warn the player.
                    Console.Clear();
                    gameData.displayUIinfo(HealthBar, CurrentRoom);
                    Console.WriteLine("Please enter a valid input for an action");
                    Thread.Sleep(2000);
                }
            }
            else if (HP <= 0 || isPlaying == false)
            {
                // Death or game-ending condition.
                Console.Clear();
                Console.WriteLine("You died, thanks for playing!");
                Thread.Sleep(3000);
                isPlaying = false;
                return;
            }
        }
    }

    // Simple stat display methods.
    public void DisplayPuzzlesSolved()
    {
        Console.WriteLine("Puzzles Solved:\n");
        Console.WriteLine(PuzzlesSolved);
    }

    public void DisplayScrapValueCollected()
    {
        Console.WriteLine("Scrap Value Collected:\n");
        Console.WriteLine(ScrapValueCollected);
    }

    public void DisplayEnemysKilled()
    {
        // Note: text label is incorrect (should say "Enemies Killed").
        Console.WriteLine("Puzzles Solved:\n");
        Console.WriteLine(EnemysKilled);
    }
}
