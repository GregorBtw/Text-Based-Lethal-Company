using System;
using System.ComponentModel;
using interfaces.itembehaviours;

namespace items;
public class Item
{
    //Attributes
    public String Name;
    public int Value;
    public IItemBehaviour ItemBehaviour;

    public String Description;

    //Constructor

    public Item(String name, int value, IItemBehaviour itemBehaviour, String description)
    {
        this.Name = name;
        this.Value = value;
        this.ItemBehaviour = itemBehaviour;
        this.Description = description;
    }


    //Methods

    public void Use()
    {
        //Implementation of item use logic
        // For example, apply item's effect to the user or target
    }
    public void Equip()
    {
        ItemBehaviour.Equip();
    }
}