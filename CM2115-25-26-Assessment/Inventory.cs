using System;
using items;

namespace inventory;

public class Inventory
{

    //Attributes

    public Item[] Items;

    //Constructor

    public Inventory()
    {
        this.Items = new Item[4];
    }

    //Methods

    public void AddItem(Item item)
    {
        //Implementation of adding item to inventory logic
    }
    public void RemoveItem(Item item)
    {
        //Implementation of removing item from inventory logic
    }
}