using System.Collections.Generic;
using interfaces.movebehaviours;
using items;
using rooms;

namespace maps;

public class Map
{
    //Attributes
    public Dictionary<string, Room> Rooms { get; set; }

    public IMoveBehaviour MoveBehaviour { get; set; }

    //Constructor

    public Map(IMoveBehaviour moveBehaviour)
    {
        this.Rooms = new Dictionary<string, Room>();
        this.MoveBehaviour = moveBehaviour;
    }

    //Methods

    public Room CreateRoom(string name, List<Item> items, string info, Dictionary<String, Room> SurroundingRooms)
    {
      return new RoomBuilder()
        .addName(name)
        .addItems(items)
        .addInformation(info)
        .addSurroundingRooms(SurroundingRooms)
        .Build();
    }

    public void AddRoom(String coord, Room room)
    {
        Rooms.Add(coord, room);
    }
    
    

}