using interfaces.itembehaviours;

namespace behaviours.itembehaviours;

public class ValueItem : IItemBehaviour
{
    public void Use()
    {
        //Implementation of item use logic
        // For example, apply item's effect to the user or target
    }
    public void Equip()
    {
        Console.WriteLine("You picked up a valuable item!\n");
        Console.WriteLine("Take it back to the ship and sell it to complete the quota");
    }
}