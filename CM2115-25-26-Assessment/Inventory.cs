using System;
using items;
using behaviours.itembehaviours;
using entitys.players;

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

    public Item? GetItem(String input)
    {
            for(var Item = 0; Item < Items.Count; Item++)
            {
                if(input == Items[Item].Name)
                {
                   return Items[Item];
                }
            }
            Console.WriteLine("Item does not exist in inventory");
            return null; 
    }

    public void DisplayWeapons()
    {
        Console.WriteLine("Weapons in your inventory:");

        if (Items.Count==0)
        {
            Console.WriteLine("No Items!");

        }else if (Items.Count > 0)
        {
            for(var i = 0; i < Items.Count; i++)
            {
                if(Items[i].ItemBehaviour is DamageItem)
                {
                    Console.WriteLine($"• {Items[i].Name}");               
                }

                Console.WriteLine("\n");

            }               
        }
     
    }

    public void DisplayItems()
    {
        Console.WriteLine($"Your Inventory:\n");
        for(var i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"• {Items[i].Name}");
        }
        Console.WriteLine("\n");
    }

    public void updateCollectedScrap(Player User)
    {
        for(var i = 0; i < Items.Count; i++)
        {
            if(Items[i].ItemBehaviour is ValueItem)
            {
                User.ScrapValueCollected+=Items[i].Value;          
            }

            Console.WriteLine("\n");

        }         
    }

    

    
}