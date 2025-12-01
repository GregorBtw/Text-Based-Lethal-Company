using entitys;
using interfaces.itembehaviours;

namespace behaviours.itembehaviours;

public class ValueItem : IItemBehaviour
{
    // Use method doesn't do anything, as it's more of a collectible value item
    public void Use(Entity target, int Multiplier)
    {
        Console.WriteLine("You have used a valuable item");
    }

    // Equip method informs the player that the item is valuable and might be sold
    public void Equip()
    {
        Console.WriteLine("You picked up a valuable item!\n");
        Console.WriteLine("Take it back to the ship and sell it to complete the quota");
    }
}
