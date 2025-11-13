using System;
using entitys;
using inventory;
using rooms;
using maps;
using System.Reflection.Metadata;


namespace entitys.players;


public class Player : Entity
{
    //Attributes
    private static Player instance = null;

    public Inventory Inventory { get; set; }


    //Constructor
    private Player(String name, int hp, Room currentRoom, Inventory inventory) : base(name, hp, currentRoom)
    {
        this.Inventory = inventory;
    }


    //Methods
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
        foreach (var kvp in instance.CurrentRoom.SurroundingRooms)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value.Name}");
        }
        Console.WriteLine("-------------------------------");
        var Result = Console.ReadLine();

        if (instance.CurrentRoom.SurroundingRooms.TryGetValue(Result, out Room nextRoom))
        {
            instance.CurrentRoom = nextRoom; // move the player
            Console.Clear();
            Console.WriteLine($"You moved to {nextRoom.Name}.");
        }
        else
        {
            Console.WriteLine("Invalid choice, please try again.");
        }
    }
}