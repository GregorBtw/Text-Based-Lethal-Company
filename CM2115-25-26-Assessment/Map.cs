using System.Collections.Generic;
using interfaces.movebehaviours;
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
    public void AddRoom(Room room)
    {
        //Implementation of adding room to the map
    }
}