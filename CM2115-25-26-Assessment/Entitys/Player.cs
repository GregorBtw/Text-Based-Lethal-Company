using System;
using entitys;
using inventory;
using rooms;

namespace entitys.players;


public class Player : Entity
{

    //Attributes

    public Inventory Inventory { get; set; }

    //Constructor
    public Player(String name, int hp, Room currentRoom, Inventory inventory) : base(name, hp, currentRoom)
    {
        this.Inventory = new Inventory();
    }

    //Methods
    public void Initialise()
    {
        //Initialise player attributes
    }
}