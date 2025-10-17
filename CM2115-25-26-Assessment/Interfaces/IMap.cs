using System;

namespace CM2115_25_26_Assessment;

public interface IMap
{
    Dictionary<string, Room> Rooms { get; set; }

    IMoveBehaviour MoveBehaviour { get; set; }

    //Method signature

    void AddRoom(Room room);
}
