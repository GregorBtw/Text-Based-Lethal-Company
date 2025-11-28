using System;
using entitys;
using entitys.players;
using interfaces.itembehaviours;

namespace behaviours.itembehaviours;
public class ToolItem : IItemBehaviour
{
    //Methods

    public void Use(Entity target)
    {
        
    }

    public void Equip()
    {
        Console.WriteLine("You picked up a useful item!\n");
        Console.WriteLine("This might be useful for later...");
    }
}