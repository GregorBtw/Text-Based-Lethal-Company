using System;
using System.ComponentModel;
using entitys.players;
using interfaces.itembehaviours;
using inventory;

namespace items;

public class Item
{
    // Item name shown to the player.
    public String Name;

    // Scrap value or item worth (used for quota calculation).
    public int Value;

    // Behaviour interface allowing different item types (weapons, scrap, etc.).
    // Implements the Strategy Pattern to give items custom functionality.
    public IItemBehaviour ItemBehaviour;

    // Description displayed when examining the item.
    public String Description;

    // Creates an item with a name, value, behaviour, and description.
    public Item(String name, int value, IItemBehaviour itemBehaviour, String description)
    {
        this.Name = name;
        this.Value = value;
        this.ItemBehaviour = itemBehaviour;
        this.Description = description;
    }

    // Placeholder for using an item directly (not used in your current design).
    public void Use(Player User)
    {
        ItemBehaviour.Use(User);
        Console.WriteLine($"\n{Name}, it is now broken");
        Thread.Sleep(3000);
    }

    // Equips the item by delegating to its behaviour (e.g., weapon equip logic).
    public void Equip()
    {
        ItemBehaviour.Equip();
    }
}
