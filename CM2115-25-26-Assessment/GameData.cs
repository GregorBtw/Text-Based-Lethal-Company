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
    //Attributes
    private static GameData instance = null;
    public int Quota { get; set; }
    public Player Player;

    //Constructor
    private GameData(int quota, Player player)
    {
        this.Quota = quota;
        this.Player = player;
    }

    //Methods

    public static GameData Initialise(int quota, Player player)
    {
        if (instance == null)
        {
            instance = new GameData(quota, player);
        }

        return instance;
    }

    private void DisplayQuota()
    {
        Console.WriteLine(Quota);
    }

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
        Console.WriteLine("Once you have been inside the warehouse once, you cannot enter back in.\n");
        Thread.Sleep(2000);

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

    public void displayUIinfo(HealthBar healthBar, Room CurrentRoom)
    {
        Console.Clear();
        healthBar.DisplayHealthBar();
        CurrentRoom.DisplayCurrentRoomInformation();
    }

    public static void displayBattleHealth(Player User, Creature enemy)
    {
        Console.WriteLine("Players Health: ");
        User.HealthBar.DisplayHealthBar();
        
        Console.WriteLine("\nEnemys Health: ");
        enemy.SetHp(User.HP);
        enemy.HealthBar.DisplayHealthBar(); 
        Console.WriteLine("-------------------------------");      
    }



    public void GameDataPrompt()
    {
        bool Looping = true;

        while (Looping)
        {
            Console.WriteLine("Please enter a keyword to execute an action\n");

            var Commands = new Dictionary<string, Action>
            {
                { "quota", DisplayQuota},
                { "scrapvaluecollected", Player.DisplayScrapValueCollected},
                { "inventory", Player.Inventory.DisplayItems},
                { "enemyskilled", Player.DisplayEnemysKilled},
                { "puzzlessolved", Player.DisplayPuzzlesSolved},
                { "sellscrap", () => Player.SellScrap(Quota)}
            };

            foreach(var i in Commands)
            {
                Console.WriteLine($"• {i.Key}");           
            }

            Console.WriteLine("\n");

            String? Str = Console.ReadLine();
            String? Input = Str.ToLower();
            
            if (Commands.TryGetValue(Input, out Action method))
            {
                Console.Clear();
                method();

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
            else
            {
                Console.WriteLine("Invalid Action");
            }            
        }

        

    }

}