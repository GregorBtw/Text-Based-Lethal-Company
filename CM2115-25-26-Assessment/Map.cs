using CM2115_25_26_Assessment;
using System.Collections.Generic;

public class Map
{
    //Attributes
    public Dictionary<string, Room> Rooms { get; set; }

    public IMoveBehaviour MoveBehaviour { get; set; }

    //Methods
    public void AddRoom(Room room)
    {
        //Implementation of adding room to the map
    }
}