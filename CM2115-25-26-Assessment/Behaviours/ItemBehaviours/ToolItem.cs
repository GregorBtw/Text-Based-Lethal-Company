using System;
using interfaces.itembehaviours;

namespace behaviours.itembehaviours;
public class ToolItem : IItemBehaviour
{

    //Attributes

    //Methods

    public void Use()
    {
        //Implementation of item use logic
        // For example, apply item's effect to the user or target
    }
    public void Equip()
    {
        Console.WriteLine("You picked up a useful item!\n");
        Console.WriteLine("");
    }
}