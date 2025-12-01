using Xunit;
using System.Collections.Generic;
using rooms;
using roomBuilder;
using items;
using behaviours.itembehaviours;
using behaviours.attackbehaviours;
using entitys.players;
using entitys.Creatures;

public class EntityBattleManagerTests
{
    [Fact]
    public void StartBattlePlayerUsesWeaponEnemyDefeated()
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);
        var weapon = new Item("Sword", 0, new DamageItem(new Strike()), "Weapon");
        player.Inventory.AddItem(weapon);

        var enemy = new Creature("Enemy", 50, new Strike(), "Enemy");
        var ex = Record.Exception(() => EntityBattleManager.StartBattle(player, enemy));

        Assert.Null(ex);
    }

    [Theory]
    [InlineData(30)]
    [InlineData(50)]
    [InlineData(100)]
    public void StartBattleVariousEnemyHP(int hp)
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);
        var weapon = new Item("Sword", 0, new DamageItem(new Strike()), "Weapon");
        player.Inventory.AddItem(weapon);

        var enemy = new Creature("Enemy", hp, new Strike(), "Enemy");
        var ex = Record.Exception(() => EntityBattleManager.StartBattle(player, enemy));

        Assert.Null(ex);
    }

    [Theory]
    [InlineData("Knife")]
    [InlineData("Bat")]
    [InlineData("Axe")]
    public void StartBattleVariousWeapons(string weaponName)
    {
        var room = new RoomBuilder().AddMainData("Room", new List<Item>(), "Info").Build();
        var player = Player.Initialise(room);
        var weapon = new Item(weaponName, 0, new DamageItem(new Strike()), "Weapon");
        player.Inventory.AddItem(weapon);

        var enemy = new Creature("Enemy", 50, new Strike(), "Enemy");
        var ex = Record.Exception(() => EntityBattleManager.StartBattle(player, enemy));

        Assert.Null(ex);
    }
}
