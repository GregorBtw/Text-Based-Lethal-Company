using interfaces.room;
using items;

namespace rooms;

public class Room
{

    //Attributes
    public String Name;

    public List<Item> Items;

    public String Information;

    public Dictionary<String, Room> SurroundingRooms;

    //Constructor

    public Room(RoomBuilder Builder)
    {
        this.Name = Builder.Name;
        this.Items = Builder.Items;
        this.Information = Builder.Information;
        this.SurroundingRooms = Builder.SurroundingRooms;
    }

    



    //Methods

    public void DisplayScrap()
    {
        //Display the items in the room to the player
    }
    public void DisplayRooInfo()
    {
        //Display the room information to the player
    }
}