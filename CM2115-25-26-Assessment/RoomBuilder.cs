using System.Diagnostics.Contracts;
using System.Dynamic;
using items;
using rooms;

public class RoomBuilder
{
    public string Name;

    public List<Item> Items { get; set; }

    public String Information { get; set; }

    public Dictionary<String, Room> SurroundingRooms { get; set; }

    //Constructors

    public RoomBuilder addName(string name)
    {
        this.Name = name;
        return this;
    }
    public RoomBuilder addItems(List<Item> items) 
    {
        this.Items = items;
        return this;
    }
    public RoomBuilder addInformation(string information)
    {
        this.Information = information;
        return this;
    }
    public RoomBuilder addSurroundingRooms(Dictionary<String, Room> surroundingRooms)
    {
        this.SurroundingRooms = surroundingRooms;
        return this;
    }
    
    public Room Build()
    {
        return new Room(this);
    }


}

