using entitys.players;
using interfaces.itembehaviours;

namespace interfaces.items
{
    public interface IItem
    {
        string Name { get; set; }
        int Value { get; set; }
        IItemBehaviour ItemBehaviour { get; set; }
        string Description { get; set; }

        void Use(Player user);
        void Equip();
    }
}
