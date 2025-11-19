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

    public void AddRoom(String coord, Room room)
    {
        Rooms.Add(coord, room);
    }
    
    

}