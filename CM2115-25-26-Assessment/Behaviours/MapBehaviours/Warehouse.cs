using System;
using interfaces.ImapBehaviour;

namespace behaviours.mapBehaviours;
public class WareHouse : IMapBehaviour
{
    public void Move()
    {
        Console.WriteLine("You moved in the Warehouse!");
    }
}