using System.Collections.Generic;
using interfaces.ImapBehaviour;
using items;
using rooms;

namespace maps;

public class Map
{
    //Attributes
    public Dictionary<string, Room> Rooms { get; set; }

    public IMapBehaviour MapBehaviour { get; set; }

    //Constructor

    public Map(IMapBehaviour mapBehaviour)
    {
        this.Rooms = new Dictionary<string, Room>();
        this.MapBehaviour = mapBehaviour;
    }

    //Methods

    public void AddRoom(String coord, Room room)
    {
        Rooms.Add(coord, room);
    }


    
    

}