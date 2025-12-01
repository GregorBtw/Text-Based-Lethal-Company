using Xunit;
using System.Collections.Generic;
using rooms;
using roomBuilder;
using inventory;
using items;
using behaviours.itembehaviours;
using behaviours.attackbehaviours;
using entitys.players;

public class PlayerTests
{
    [Fact]
    public void PlayerInitialiseHasInventoryAndHP()
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);

        Assert.NotNull(player.Inventory);
        Assert.Equal(100, player.HP);
        Assert.Equal(room, player.CurrentRoom);
    }

    [Fact]
    public void PlayerAddItemToInventoryItemExists()
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);

        var sword = new Item("Sword", 10, new DamageItem(new Strike()), "Weapon");
        player.Inventory.AddItem(sword);

        Assert.Contains(sword, player.Inventory.Items);
    }

    [Fact]
    public void PlayerRemoveItemFromInventoryItemRemoved()
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);

        var sword = new Item("Sword", 10, new DamageItem(new Strike()), "Weapon");
        player.Inventory.AddItem(sword);
        player.Inventory.RemoveItem(sword);

        Assert.DoesNotContain(sword, player.Inventory.Items);
    }

    [Fact]
    public void PlayerCurrentRoomAssignedCorrectly()
    {
        var room = new RoomBuilder().AddMainData("TestRoom", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);

        Assert.Equal("TestRoom", player.CurrentRoom.Name);
    }
}
