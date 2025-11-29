using System;
using entitys;
using entitys.players;
using interfaces.itembehaviours;

namespace behaviours.itembehaviours;

public class ToolItem : IItemBehaviour
{
    // Use method doesn't do anything currently, can be expanded for tool-specific actions
    public void Use(Entity target, int Multiplier)
    {
        Console.WriteLine("You have used a tool");
    }

    // Equip method provides feedback to the player when they pick up a tool
    public void Equip()
    {
        Console.WriteLine("You picked up a tool!\n");
        Console.WriteLine("This might be useful for later...");
    }
}
