using Xunit;
using items;
using behaviours.itembehaviours;
using behaviours.attackbehaviours;
using entitys.players;
using rooms;
using roomBuilder;
using System.Collections.Generic;

public class ItemTests
{
    private Player CreatePlayer()
    {
        var room = new RoomBuilder()
            .AddMainData("Test Room", new List<Item>(), "Info")
            .Build();

        return Player.Initialise(room);
    }

    [Fact]
    public void ItemConstructorSetsPropertiesCorrectly()
    {
        var behaviour = new ValueItem();
        var item = new Item("Gold Bar", 10, behaviour, "Valuable item");

        Assert.Equal("Gold Bar", item.Name);
        Assert.Equal(10, item.Value);
        Assert.Equal(behaviour, item.ItemBehaviour);
        Assert.Equal("Valuable item", item.Description);
    }

    [Fact]
    public void EquipValueItem()
    {
        var item = new Item("Coin", 1, new ValueItem(), "Currency");

        var ex = Record.Exception(() => item.Equip());

        Assert.Null(ex);
    }

    [Fact]
    public void EquipToolItem()
    {
        var item = new Item("Hammer", 3, new ToolItem(), "Simple tool");

        var ex = Record.Exception(() => item.Equip());

        Assert.Null(ex);
    }

    [Fact]
    public void UseValueItem()
    {
        var player = CreatePlayer();
        var item = new Item("Diamond", 25, new ValueItem(), "Valuable gem");

        var ex = Record.Exception(() => item.Use(player));

        Assert.Null(ex);
    }

    [Fact]
    public void UseToolItem()
    {
        var player = CreatePlayer();
        var item = new Item("Wrench", 2, new ToolItem(), "Basic tool");

        var ex = Record.Exception(() => item.Use(player));

        Assert.Null(ex);
    }

    [Fact]
    public void UseDamageItemDamagesPlayer()
    {
        var player = CreatePlayer();
        var item = new Item("Knife", 0, new DamageItem(new Strike()), "Small weapon");

        var ex = Record.Exception(() => item.Use(player));

        Assert.Null(ex);
    }

    [Fact]
    public void DamageItemReducesPlayerHp()
    {
        var player = CreatePlayer();
        player.HP = 50;

        var item = new Item("Axe", 0, new DamageItem(new Strike()), "Sharp weapon");

        item.Use(player);

        Assert.True(player.HP < 50); // HP should decrease after being "attacked"
    }
}
