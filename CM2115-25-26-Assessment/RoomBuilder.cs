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
    // --- Attributes for building a Room ---
    public string? Name { get; set; }                        // Room name
    public List<Item>? Items { get; set; }                   // Items in the room
    public String? Information { get; set; }                 // Room description
    public Dictionary<String, Room>? SurroundingRooms { get; set; } // Neighboring rooms
    public Creature? Enemy { get; set; }                     // Enemy in the room
    public Puzzle? Puzzle { get; set; }                      // Puzzle in the room
    public bool isLocked { get; set; }                       // Is room locked

    // --- Builder Methods ---
    
    // Sets the basic room data: name, items, description
    public RoomBuilder AddMainData(string name, List<Item> items, string information)
    {
        this.Name = name;
        this.Items = items;
        this.Information = information;
        return this;  // Allows method chaining
    }

    // Adds surrounding rooms
    public RoomBuilder AddSurroundingRooms(Dictionary<String, Room> surroundingRooms)
    {
        this.SurroundingRooms = surroundingRooms;
        return this;  // Allows method chaining
    }

    // Adds an enemy to the room
    public RoomBuilder AddEnemy(Creature enemy)
    {
        this.Enemy = enemy;
        return this;
    }

    // Adds a puzzle to the room
    public RoomBuilder AddPuzzle(Puzzle puzzle)
    {
        this.Puzzle = puzzle;
        return this;
    }

    public RoomBuilder addLock()
    {
        this.isLocked = true;
        return this;
    }
    
    // Constructs the Room object using the accumulated data
    public Room Build()
    {
        return new Room(this);
    }
}
