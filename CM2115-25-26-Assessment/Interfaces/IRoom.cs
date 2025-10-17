using System;

namespace CM2115_25_26_Assessment;

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
