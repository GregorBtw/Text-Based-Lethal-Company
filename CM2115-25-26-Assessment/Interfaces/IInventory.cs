using items;
using entitys.players;

namespace Interfaces.IInventory

{
    public interface IInventory
    {
        List<Item> Items { get; }

        void AddItem(Item item);
        void RemoveItem(Item item);

        bool CheckIfInventoryFull();

        void DisplayWeapons();
        void DisplayItems();

        void UpdateCollectedScrap(Player user);

        bool CheckForLockpick();
    }
}