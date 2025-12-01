using Xunit;
using rooms;
using roomBuilder;
using entitys.players;
using Game_Data;
using items;
using behaviours.itembehaviours;
using System.Collections.Generic;

public class GameDataTests
{
    [Fact]
    public void InitialiseReturnsInstance()
    {
        var testItem = new Item("TestItem", 1, new ValueItem(), "Utility");
        var room = new RoomBuilder().AddMainData("Room", new List<Item> { testItem }, "Info").Build();
        var player = Player.Initialise(room);

        var data1 = GameData.Initialise(50, player);
        var data2 = GameData.Initialise(50, player);

        Assert.Same(data1, data2);
        Assert.Equal(50, data1.Quota);
        Assert.Equal(player, data1.Player);
    }

    [Fact]
    public void DisplayUIinfo()
    {
        var testItem = new Item("TestItem", 1, new ValueItem(), "Utility");
        var room = new RoomBuilder().AddMainData("Room", new List<Item> { testItem }, "Info").Build();
        var player = Player.Initialise(room);
        var data = GameData.Initialise(50, player);

        var ex = Record.Exception(() => data.displayUIinfo(player.HealthBar, room));
        Assert.Null(ex);
    }

    [Fact]
    public void DisplayGameInfo()
    {
        var ex = Record.Exception(() => GameData.displayGameInfo());
        Assert.Null(ex);
    }

    [Fact]
    public void PromptTerminal()
    {
        var testItem = new Item("TestItem", 1, new ValueItem(), "Utility");
        var room = new RoomBuilder().AddMainData("Room", new List<Item> { testItem }, "Info").Build();
        var player = Player.Initialise(room);
        var data = GameData.Initialise(50, player);

        var ex = Record.Exception(() => data.PromptTerminal());
        Assert.Null(ex);
    }
}
