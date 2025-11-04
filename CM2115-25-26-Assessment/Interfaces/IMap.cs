using System;
using rooms;
using interfaces.movebehaviours;

namespace interfaces.map;

public interface IMap
{
    Dictionary<string, Room> Rooms { get; set; }

    IMoveBehaviour MoveBehaviour { get; set; }

    //Method signature

    void AddRoom(Room room);
}
