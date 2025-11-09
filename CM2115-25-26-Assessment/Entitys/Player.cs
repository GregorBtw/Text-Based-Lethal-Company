using System;
using entitys;
using inventory;
using rooms;
using maps;


namespace entitys.players;


public class Player : Entity
{


     /*Moon.Ship.Rooms["0,0"]*/


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
        Console.WriteLine("Please enter a username!: ");
        var Username = Console.ReadLine();

        if (instance == null)
        {
            instance = new Player(Username, 100, room, new Inventory());
        }

        return instance;
    }
}