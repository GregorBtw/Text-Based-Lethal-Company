using System;
using rooms;
using items;
using entitys.players;
using inventory;

namespace interfaces.room;

    public interface IRoom
    {
        // Properties
        string Name { get; set; }
        List<Item> Items { get; set; }
        string Information { get; set; }
        Dictionary<String, Room> SurroundingRooms { get; set; }
        bool isLocked { get; set; }

        //Method signature
        void DisplayCurrentRoomInformation();
        void PickUpItem(Inventory inventory);
        void DropItem(Inventory inventory);
        void CheckForPuzzle(Player user);
        void CheckForEnemy(Player user);
        bool CheckForLock(Player user);
    }
