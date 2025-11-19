using System;
using entitys;
using inventory;
using rooms;
using maps;
using System.Reflection.Metadata;


using interfaces.Observer;


namespace entitys.players;


public class Player : Entity
{
    //Attributes
    private static Player instance = null;

    public List<IObserver> Observers = new List<IObserver>();

    public bool isPlaying = true;

    public int EnemysKilled = 0;

    public int PuzzlesSolved = 0;

    public int ScrapValueCollected = 0;

    public Inventory Inventory { get; set; }


    //Constructor
    private Player(String name, int hp, Room currentRoom, Inventory inventory) : base(name, hp, currentRoom)
    {
        this.Inventory = inventory;
    }


    //Methods

    public void AttachObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void SetHp(int value)
    {
        HP = value;
        foreach (var observer in Observers)
            observer.Update(HP);
    }

    public static Player Initialise(Room startRoom)
    {
        Console.WriteLine("Please enter a username! (Greater than 3 characters, fewer than 15): ");
        var Username = Console.ReadLine();

        while(Username.Length<=3||Username.Length>=15)
        {
            Console.Clear();
            Console.WriteLine("Username must be longer than 3 characters, and shorter than 15");
            Console.WriteLine("Please enter a username!: ");
            Username = Console.ReadLine();
        }

        if (instance == null)
        {
            instance = new Player(Username, 100, startRoom, new Inventory());
        }

        return instance;
    }

    public void Move()
    {
        Console.WriteLine($"Where would you like to move {instance.Name}?");

        Console.WriteLine("-------------------------------");
        foreach (var room in instance.CurrentRoom.SurroundingRooms)
        {
            Console.WriteLine($"{room.Key} -> {room.Value.Name}");
        }
        Console.WriteLine("-------------------------------");
        var Result = Console.ReadLine();

        if (instance.CurrentRoom.SurroundingRooms.TryGetValue(Result, out Room nextRoom))
        {
            Console.Clear();

            var Loading = "Loading";

            for(var i = 0; i < 4; i++)
            {
                Console.WriteLine(Loading);
                Loading+=".";
                Thread.Sleep(1000);
                Console.Clear();
            }
            instance.CurrentRoom = nextRoom; // move the player
            Console.Clear();
            Console.WriteLine($"You moved to {nextRoom.Name}.");
        }
        else
        {
            Console.WriteLine("Invalid choice, please try again.");
        }
    }

    public void DisplayCurrentRoomInformation()
    {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Room Information:\n\n{CurrentRoom.Information}");
            Console.WriteLine("-------------------------------");
    }
 
    public void DisplayPuzzlesSolved()
    {
        Console.WriteLine(PuzzlesSolved);
    }

    public void DisplayScrapValueCollected()
    {
        Console.WriteLine(ScrapValueCollected);        
    }

    public void DisplayInventoryItems()
    {
        Console.WriteLine(Inventory);       
    }

    public void DisplayEnemysKilled()
    {
        Console.WriteLine(EnemysKilled);       
    }
}