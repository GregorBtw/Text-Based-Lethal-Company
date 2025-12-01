using rooms;
using interfaces.ImapBehaviour;

namespace interfaces.map;

public interface IMap
{
    // Properties
    Dictionary<string, Room> Rooms { get; set; }

    IMapBehaviour MapBehaviour { get; set; }

    //Method signature

    void AddRoom(Room room);
}
