using interfaces.room;
using items;
using entitys.Creatures;
using puzzles;
using roomBuilder;

namespace rooms;

public class Room
{

    //Attributes
    public String Name;

    public List<Item> Items;

    public String Information;

    public Dictionary<String, Room> SurroundingRooms;

    public Creature Enemy;

    public Puzzle Puzzle;

    //Constructor

    public Room(RoomBuilder Builder)
    {
        this.Name = Builder.Name;
        this.Items = Builder.Items;
        this.Information = Builder.Information;
        this.SurroundingRooms = Builder.SurroundingRooms;
        this.Enemy = Builder.Enemy;
        this.Puzzle = Builder.Puzzle;
    }

    //Methods

    public void DisplayScrap()
    {
        //Display the items in the room to the player
    }
    public void DisplayRoomInfo()
    {
        //Display the room information to the player
    }
}