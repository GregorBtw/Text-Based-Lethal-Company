using Xunit;
using System.Collections.Generic;
using rooms;
using roomBuilder;
using inventory;
using items;
using entitys.players;
using behaviours.itembehaviours;

public class RoomTests
{
[Fact]
public void RoomPickUpItem_ItemAddedToInventory()
{
    var item = new Item("Key", 5, new ValueItem(), "Key item");

    // Room starts WITH the item
    var room = new RoomBuilder().AddMainData("Room", new List<Item> { item }, "Info").Build();

    var player = Player.Initialise(room);
    player.Inventory = new Inventory();

    // Simulate pickup
    player.Inventory.AddItem(item);
    room.Items.Remove(item);

    Assert.Contains(item, player.Inventory.Items);
    Assert.DoesNotContain(item, room.Items);
}

[Fact]
public void RoomDropItem_ItemReturnedToRoom()
{
    var item = new Item("Key", 5, new ValueItem(), "Key item");

    // Room starts EMPTY
    var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();

    var player = Player.Initialise(room);
    player.Inventory = new Inventory();

    // Simulate picking item up before dropping it
    player.Inventory.AddItem(item);

    // Simulate drop
    player.Inventory.RemoveItem(item);
    room.Items.Add(item);

    Assert.Contains(item, room.Items);
    Assert.DoesNotContain(item, player.Inventory.Items);
}

[Fact]
public void RoomCheckForLock_LockedRoom_ReturnsTrue()
{
    // Room doesn't need items for this test
    var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
    room.isLocked = true;

    var player = Player.Initialise(room);
    player.Inventory = new Inventory();

    bool result = room.CheckForLock(player);

    Assert.True(result);
}

[Fact]
public void RoomDisplayCurrentRoomInformation()
{
    // Room with 1 example item to ensure safe operation
    var item = new Item("Map", 1, new ValueItem(), "Utility");
    var room = new RoomBuilder().AddMainData("Room", new List<Item> { item }, "Info").Build();

    // Should not throw an exception when displaying room information
    room.DisplayCurrentRoomInformation();
}
}

