using System;
using items;
using behaviours.itembehaviours;
using entitys.players;

namespace inventory;

public class Inventory
{
    // Holds all items the player is carrying (max size is enforced logically).
    public List<Item> Items;

    // Initializes inventory with capacity of 4 items.
    public Inventory()
    {
        this.Items = new List<Item>(4);
    }

    // Adds an item to the inventory and notifies the player.
    public void AddItem(Item item)
    {
        Items.Add(item);
        Console.WriteLine($"You have added {item.Name} to your inventory.");
    }

    // Removes an item from the inventory.
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        Console.WriteLine($"you dropped a {item.Name}");
    }

    // Checks if the inventory is full (limit of 4).
    public bool CheckIfInventoryFull()
    {
        return Items.Count >= 4;
    }

    // Displays only items that are weapons (DamageItem behaviour).
    public void DisplayWeapons()
    {
        Console.WriteLine("Weapons in your inventory:\n");

        if (Items.Count == 0)
        {
            Console.WriteLine("No Items!");
        }
        else
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].ItemBehaviour is DamageItem)
                {
                    Console.WriteLine($"• {Items[i].Name}");
                }
            }
        }
    }

    // Displays the full inventory contents.
    public void DisplayItems()
    {
        Console.WriteLine($"Your Inventory:\n");

        for (var i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"• {Items[i].Name}");
        }

        Console.WriteLine("\n");
    }

    // Updates player's total scrap value based on all ValueItems they carry.
    public void updateCollectedScrap(Player User)
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].ItemBehaviour is ValueItem)
            {
                User.ScrapValueCollected += Items[i].Value;
            }
        }

        Console.WriteLine("\n");
    }

    public bool CheckForLockpick()
    {

            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "lockpicker")
                {
                    return true;
                }

            }
          
            return false;
            
    }

}
