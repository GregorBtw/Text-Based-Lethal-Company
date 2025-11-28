using System.Collections.Generic;
using interfaces.ImapBehaviour;
using items;
using rooms;

namespace maps;

public class Map
{
    // Stores all rooms in the map, keyed by a coordinate string (e.g., "A1", "B2").
    public Dictionary<string, Room> Rooms { get; set; }

    // Behaviour that determines how the map is generated or structured.
    // Uses Strategy Pattern so different map generation styles can be plugged in.
    public IMapBehaviour MapBehaviour { get; set; }

    // Initializes a new map with a chosen map generation behaviour.
    public Map(IMapBehaviour mapBehaviour)
    {
        this.Rooms = new Dictionary<string, Room>();
        this.MapBehaviour = mapBehaviour;
    }

    // Adds a room to the map at a specified coordinate.
    public void AddRoom(String coord, Room room)
    {
        Rooms.Add(coord, room);
    }
}
