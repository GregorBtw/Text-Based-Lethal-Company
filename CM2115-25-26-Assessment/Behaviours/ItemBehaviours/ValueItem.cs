using entitys;
using interfaces.itembehaviours;

namespace behaviours.itembehaviours;

public class ValueItem : IItemBehaviour
{

    public void Use(Entity target)
    {
        
    }
    public void Equip()
    {
        Console.WriteLine("You picked up a valuable item!\n");
        Console.WriteLine("Take it back to the ship and sell it to complete the quota");
    }
}