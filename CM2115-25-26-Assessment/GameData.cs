using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using entitys.players;
using interfaces.GameData;
using Observers.HealthBar;
using rooms;
using entitys;
using entitys.Creatures;

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
        var Input = Console.ReadLine();

        var Commands = new Dictionary<string, Action>
        {
            { "Quota", DisplayQuota},
            { "ScrapValueCollected", Player.DisplayScrapValueCollected},
            { "Inventory", Player.DisplayInventoryItems},
            { "EnemysKilled", Player.DisplayEnemysKilled},
            { "PuzzlesSolved", Player.DisplayPuzzlesSolved}
        };

        if (Commands.TryGetValue(Input, out Action method))
        {
            method();
        }
        else
        {
            Console.WriteLine("Invalid Action");
        }
        

    }

}