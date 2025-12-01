using Xunit;
using System.Collections.Generic;
using inventory;
using items;
using behaviours.itembehaviours;
using behaviours.attackbehaviours;

public class InventoryTests
{
    [Fact]
    public void InventoryAddItem_ItemExists()
    {
        var inventory = new Inventory();
        var sword = new Item("Sword", 0, new DamageItem(new Strike()), "Weapon");

        inventory.AddItem(sword);
        Assert.Contains(sword, inventory.Items);
    }

    [Fact]
    public void InventoryRemoveItem()
    {
        var inventory = new Inventory();
        var sword = new Item("Sword", 0, new DamageItem(new Strike()), "Weapon");

        inventory.AddItem(sword);
        inventory.RemoveItem(sword);

        Assert.DoesNotContain(sword, inventory.Items);
    }

    [Fact]
    public void InventoryCheckIfFull()
    {
        var inventory = new Inventory();
        for (int i = 0; i < 4; i++)
        {
            inventory.AddItem(new Item($"Item{i}", 0, new DamageItem(new Strike()), "Weapon"));
        }

        Assert.True(inventory.CheckIfInventoryFull());
    }

    [Fact]
    public void InventoryDisplayWeapons()
    {
        var inventory = new Inventory();
        var sword = new Item("Sword", 0, new DamageItem(new Strike()), "Weapon");
        inventory.AddItem(sword);

        var ex = Record.Exception(() => inventory.DisplayWeapons());
        Assert.Null(ex);
    }
}
