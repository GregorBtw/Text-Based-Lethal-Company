using System;
using rooms;
using items;

namespace interfaces.room;

public interface IRoom
{
    //Attributes
    String Name { get; set; }

    Item[] Items { get; set; }

    String Information { get; set; }

    Dictionary<String, Room> SurroundingRooms { get; set; }

    //Method signatures
    void DisplayScrap();
    void DisplayRooInfo();
}
