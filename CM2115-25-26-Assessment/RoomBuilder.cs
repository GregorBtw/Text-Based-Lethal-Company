using System.Diagnostics.Contracts;
using System.Dynamic;
using items;
using rooms;

public class RoomBuilder
{
    private String Name;

    public Item[] Items { get; set; }

    public String Information { get; set; }

    public Dictionary<String, Room> SurroundingRooms { get; set; }

    public String name
    {
        get { return Name; }
        set{
            if (value.Length < 1){
                Console.WriteLine("Please enter a valid username.");
                return;
            }
            else if (value.Length > 15){
                Console.WriteLine("Username too long, MUST be less than 15 characters.");
                return;
            }
            else{
                Name = value;
            }
        }
    }

    //Constructors

    public RoomBuilder addName(string name)
    {
        this.Name = name;
        return this;
    }
    public RoomBuilder addItems(Item[] items)
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

