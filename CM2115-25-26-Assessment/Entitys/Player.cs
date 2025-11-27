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
    //Attributes
    private static Player instance = null;

    public HealthBar HealthBar = new HealthBar();

    public bool isPlaying = true;

    public int EnemysKilled = 0;

    public int PuzzlesSolved = 0;

    public int ScrapValueCollected = 0;

    public Inventory Inventory { get; set; }

    public Room CurrentRoom { get; set; }


    //Constructor
    private Player(String name, int hp, Room currentRoom, Inventory inventory) : base(name, hp)
    {
        this.Inventory = inventory;
        this.CurrentRoom = currentRoom;
    }


    //Methods

    public static Player Initialise(Room startRoom)
    {
        Console.WriteLine("\nPlease enter a username! (Greater than 3 characters, fewer than 15): ");
        String Username = Console.ReadLine();

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

    public static void Move()
    {
        Console.WriteLine($"\nWhere would you like to move {instance.Name}?");

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
                Thread.Sleep(500);
                Console.Clear();
            }
            instance.CurrentRoom = nextRoom; // move the player
            Console.Clear();
            Console.WriteLine($"You moved to {nextRoom.Name}.\n");
        }
        else
        {
            Console.WriteLine("Invalid choice, please try again.");
        }
    }

    public void AttackEnemy()
    {
        
        Console.WriteLine("What item would you like to use to attack?: \n");

        Inventory.DisplayWeapons();

        String? Str = Console.ReadLine();
        String Input = Str.ToLower();

        Item? Weapon = Inventory.GetItem(Input);

        Weapon.ItemBehaviour.Use(CurrentRoom.Enemy);

    }

    public void SellScrap(int quota)
    {
        Console.Clear();

        Console.WriteLine("Are you sure you want to sell your scrap, 'yes' or 'no'?\n");
        Console.WriteLine("Once you do, you can not go back into the Warehouse");
        String? Str = Console.ReadLine();
        String? Input = Str.ToLower();

        if (Input == "yes")
        {
            var Loading = "Loading";

            for(var i = 0; i < 4; i++)
            {
                Console.WriteLine(Loading);
                Loading+=".";
                Thread.Sleep(500);
                Console.Clear();
            }

            if (ScrapValueCollected >= quota)
            {
                Console.WriteLine("Congratulations, you beat the quota, have a nice day!");
                Thread.Sleep(2500);
                isPlaying=false;
            }else if(ScrapValueCollected < quota)
            {
                Console.Clear();
                Console.WriteLine("You have no items to sell! Go into the warehouse to find some.");
                Thread.Sleep(2500);
                Console.Clear();
                return;
            }         
        }else if(Input == "no")
        {
            Console.Clear();
            return;
        }

  
    }

    public void CompleteAction(GameData gameData, Moon moon)
    {
        var CompletingActions = true;

        while (CompletingActions)
        {
            bool ItemsInRoom = false;
            bool HasItems = false;

            CurrentRoom.CheckForEnemy(instance);
            CurrentRoom.CheckForPuzzle(instance);

            if (HP > 0)
            {
                    gameData.displayUIinfo(HealthBar, CurrentRoom);
                    Console.WriteLine($"What would you like to do next {instance.Name}?\n");
                    Thread.Sleep(500);

                    bool inShip = moon.CheckIfInShip(instance);

                    if (inShip)
                    {
                        Console.WriteLine("• Use ship terminal- Press [T]");
                    }

                    if (CurrentRoom.Items.Count > 0)
                    {
                        Console.WriteLine("• Equip an item in this room - Press [E]");
                        ItemsInRoom = true;
                    }
                    Console.WriteLine("• Move to another room - Press [M]");
                    if(Inventory.Items.Count > 0)
                    {
                        Console.WriteLine("• Drop an item in this room - Press [D]");
                        HasItems = true;
                    }
                    String RawInput = Console.ReadLine();
                    String Input = RawInput.Trim().ToLower();

                    if (Input == "e"&&ItemsInRoom)
                    {
                        gameData.displayUIinfo(HealthBar, CurrentRoom);
                        CurrentRoom.PickUpItem(Inventory);
                        Inventory.updateCollectedScrap(instance);
                    }
                    else if(Input == "m")
                    {
                        CompletingActions = false;
                        gameData.displayUIinfo(HealthBar, CurrentRoom);
                        Move();
                    }
                    else if(Input == "d"&&HasItems)
                    {
                        gameData.displayUIinfo(HealthBar, CurrentRoom);
                        CurrentRoom.DropItem(Inventory);
                        Inventory.updateCollectedScrap(instance);
                    }
                    else if(Input == "t")
                    {
                        gameData.GameDataPrompt();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input for an action");
                        Thread.Sleep(1000);
                    }               
            }else if (HP <= 0)
            {
                Console.Clear();
                Console.WriteLine("You died, thanks for playing!");
                Thread.Sleep(3000);
                isPlaying = false;
                return;
            }

        }

    }
 
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
        Console.WriteLine("Puzzles Solved:\n");
        Console.WriteLine(EnemysKilled);       
    }
}