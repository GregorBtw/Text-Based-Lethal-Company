using items;
using entitys.players;

namespace Interfaces.Inventory

{
    public interface IInventory
    {
        // Properties
        List<Item> Items { get; }


        //Method signature
        void AddItem(Item item);
        void RemoveItem(Item item);

        bool CheckIfInventoryFull();

        void DisplayWeapons();
        void DisplayItems();

        void UpdateCollectedScrap(Player user);

        bool CheckForLockpick();
    }
}