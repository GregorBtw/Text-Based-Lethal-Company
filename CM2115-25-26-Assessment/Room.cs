using CM2115_25_26_Assessment;

public class Room : IRoom
{

    //Attributes
    public String Name { get; set; }

    public Item[] Items { get; set; }

    public String Information { get; set; }

    public Dictionary<String, Room> SurroundingRooms { get; set; }

    //Constructor
    
    public Room(String name, Item[] items, String information, Dictionary<String, Room> surroundingRooms)
    {
        this.Name = name;
        this.Items = items;
        this.Information = information;
        this.SurroundingRooms = surroundingRooms;
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