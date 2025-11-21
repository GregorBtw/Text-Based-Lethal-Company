using System;
using items;

namespace inventory;

public class Inventory
{

    //Attributes

    public List<Item> Items;

    //Constructor

    public Inventory()
    {
        this.Items = new List<Item>(4);
    }

    //Methods

    public void AddItem(Item item)
    {
        Items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        Console.WriteLine($"you dropped a {item.Name}");
    }
}