using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using entitys.players;
using interfaces.GameData;
using Observers.HealthBar;
using rooms;
using entitys;
using entitys.Creatures;
using inventory;

namespace Game_Data;

public class GameData : IGameData
{
    // Singleton instance of the global game controller.
    private static GameData? instance = null;

    // Required scrap value to win.
    public int Quota { get; set; }

    // Reference to the player for terminal actions and UI.
    public Player Player;

    // Private constructor: part of the Singleton pattern.
    private GameData(int quota, Player player)
    {
        this.Quota = quota;
        this.Player = player;
    }

    // Returns the shared GameData instance (creates it if missing).
    public static GameData Initialise(int quota, Player player)
    {
        if (instance == null)
        {
            instance = new GameData(quota, player);
        }

        return instance;
    }

    // Displays the current quota inside the terminal.
    private void DisplayQuota()
    {
        Console.WriteLine("Quota:\n");
        Console.WriteLine(Quota);
    }

    // Intro sequence explaining the rules of the game.
    public static void displayGameInfo()
    {
        Console.WriteLine("Welcome to text based lethal company!\n");
        Thread.Sleep(3000);
        Console.Clear();

        Console.WriteLine("Game Instructions:\n");
        Thread.Sleep(2000);
        Console.WriteLine("You must go into the warehouse and collect as much scrap as you can to complete the quota.\n");
        Thread.Sleep(2000);
        Console.WriteLine("there will be puzzles and enemys that try to stop you.\n");
        Thread.Sleep(2000);
        Console.WriteLine("and once you have collected enough scrap you must make it back to the ship in order to sell it\n");
        Thread.Sleep(2000);
        Console.WriteLine("Once you sell, you cannot go back into the warehouse, so make sure you have enough!\n\n");
        Thread.Sleep(2000);

        // Wait until the user types "read" to continue.
        Console.WriteLine("When you are ready to begin, Please enter 'Read': ");
        String? Str = Console.ReadLine();
        String? Input = Str.ToLower();

        while (Input != "read")
        {
            Console.WriteLine("Please enter 'Read' to begin: ");
            Str = Console.ReadLine();
            Input = Str.ToLower();
        }

        Console.Clear();
    }

    // Displays the player's health bar and room info on the main UI.
    public void displayUIinfo(HealthBar healthBar, Room CurrentRoom)
    {
        Console.Clear();
        healthBar.DisplayHealthBar();
        CurrentRoom.DisplayCurrentRoomInformation();
    }

    // Shows player and enemy health during battles.
    public static void displayBattleHealth(Player User, Creature enemy)
    {
        Console.Clear();

        Console.WriteLine($"{User.Name}s Health: ");
        User.HealthBar.DisplayHealthBar();

        Console.WriteLine($"\n{enemy.Name}s Health: ");
        enemy.SetHp(enemy.HP);               // Triggers observer update.
        enemy.HealthBar.DisplayHealthBar();

        Console.WriteLine("-------------------------------");
    }

    // Handles the ship terminal logic: commands, looping, and UI updates.
    public void PromptTerminal()
    {
        bool Looping = true;

        while (Looping)
        {
            Console.Clear();
            displayUIinfo(Player.HealthBar, Player.CurrentRoom);

            Console.WriteLine("Please enter a keyword to execute an action\n");

            // Command–method mapping for terminal commands.
            var Commands = new Dictionary<string, Action>
            {
                { "quota", DisplayQuota },
                { "scrapvaluecollected", Player.DisplayScrapValueCollected },
                { "inventory", Player.Inventory.DisplayItems },
                { "enemyskilled", Player.DisplayEnemysKilled },
                { "puzzlessolved", Player.DisplayPuzzlesSolved },
                { "sellscrap", () => Player.SellScrap(Quota) }
            };

            // Display available commands.
            foreach(var i in Commands)
            {
                Console.WriteLine($"• {i.Key}");
            }

            Console.WriteLine("\nOr type 'Exit' to leave the terminal\n");

            String? Str = Console.ReadLine();
            String? Input = Str.ToLower();

            // Executes terminal command if valid.
            if (Commands.TryGetValue(Input, out Action? method))
            {
                Console.Clear();
                method();

                // Terminal exits immediately if the player sells and ends the run.
                if (Player.isPlaying == false)
                {
                    return;
                }

                // Ask if they want to run another command.
                Console.WriteLine("\nIf you would like to enter another command, type 'yes', and 'exit' to leave the terminal");
                String? optionStr = Console.ReadLine();
                String? optionInput = optionStr.ToLower();

                while (optionInput != "yes" && optionInput != "exit")
                {
                    Console.WriteLine("Please enter either 'yes' or 'exit'");
                    optionStr = Console.ReadLine();
                    optionInput = optionStr.ToLower();
                }

                if (optionInput == "exit")
                {
                    Looping = false;
                }
            }
            else if (Input == "exit")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Action");
                Thread.Sleep(2000);
            }
        }
    }
}
