using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using entitys.players;
using interfaces.GameData;
using Observers.HealthBar;
using rooms;

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

    public void displayUIinfo(HealthBar healthBar, Room CurrentRoom)
    {
        Console.Clear();
        healthBar.DisplayHealthBar();
        CurrentRoom.DisplayCurrentRoomInformation();
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