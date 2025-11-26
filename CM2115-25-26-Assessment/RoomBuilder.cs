using System.Diagnostics.Contracts;
using System.Dynamic;
using items;
using rooms;
using entitys;
using entitys.Creatures;
using puzzles;

namespace roomBuilder;
public class RoomBuilder
{
    public string Name { get; set; }

    public List<Item> Items { get; set; }

    public String Information { get; set; }

    public Dictionary<String, Room> SurroundingRooms { get; set; }

    public Creature Enemy { get; set; }

    public Puzzle Puzzle { get; set; }

    //Constructors

    public RoomBuilder AddMainData(string name, List<Item> items, string information)
    {
        this.Name = name;
        this.Items = items;
        this.Information = information;
        return this;
    }

    public RoomBuilder AddSurroundingRooms(Dictionary<String, Room> surroundingRooms)
    {
        this.SurroundingRooms = surroundingRooms;
        return this;
    }

    public RoomBuilder AddEnemy(Creature enemy)
    {
        this.Enemy = enemy;
        return this;
    }

    public RoomBuilder AddPuzzle(Puzzle puzzle)
    {
        this.Puzzle = puzzle;
        return this;
    }
    
    public Room Build()
    {
        return new Room(this);
    }


}

