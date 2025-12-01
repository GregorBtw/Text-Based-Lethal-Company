using entitys.players;
using interfaces.itembehaviours;

namespace interfaces.items
{
    public interface IItem
    {
        // Properties
        string Name { get; set; }
        int Value { get; set; }
        IItemBehaviour ItemBehaviour { get; set; }
        string Description { get; set; }

        //Method signature
        void Use(Player user);
        void Equip();
    }
}
