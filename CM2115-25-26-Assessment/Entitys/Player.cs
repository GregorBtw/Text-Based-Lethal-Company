using System;
using entitys;
using inventory;
using rooms;
using maps;


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
    public static Player Initialise(Room room)
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
            instance = new Player(Username, 100, room, new Inventory());
        }

        return instance;
    }
}