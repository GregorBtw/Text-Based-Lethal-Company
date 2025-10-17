using CM2115_25_26_Assessment;

public class Room : IRoom
{

    //Attributes
    public String Name { get; set; }

    public Item[] Items { get; set; }

    public String Information { get; set; }

    public Dictionary<String, Room> SurroundingRooms { get; set; }

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