using interfaces.moonBehaviours;
using rooms;
using items;
using maps;
using behaviours.itembehaviours;
using roomBuilder;
using entitys.Creatures;
using behaviours.attackbehaviours;
using puzzles;
using behaviours.puzzlebehaviours;



public class Assurance : IMoonBehaviour
{
    public void CreateMoon(Map Ship, Map WareHouse)
    {

           //Initialise Value Items
           Item Cog = new Item("cog", 45, new ValueItem(), "A solid, rust-flecked gear used in old machinery. Still sturdy enough to be useful in repairs or crafting.");
           Item LargeAxle = new Item("large axle", 90, new ValueItem(), "A thick metal axle, heavy and worn. Essential for restoring larger mechanical systems.");
           Item EnginePart = new Item("engine part", 85, new ValueItem(), "A dense chunk of engine hardware—wires, plates, and connectors fused together. Looks critical for powering something important.");
           Item MetalSheet = new Item("bent metal sheet", 35, new ValueItem(), "A warped metal panel pried off of a ruined structure. Not pretty, but useful for patching or makeshift construction.");

           //Initialise Tool Items
           Item Lockpicker = new Item("lockpicker", 90, new ToolItem(), "A slim metal toolkit for bypassing old locks. Fragile, but invaluable when a door stands between you and survival.");

           //Initialise Damage Items
           Item SignPost = new Item("stop sign", 90, new DamageItem(new Strike()), "A battered stop sign on a broken pole. Heavy, wide, and surprisingly effective when swung with both hands.");
           Item Pipe = new Item("metal pipe", 55, new DamageItem(new HeavyStrike()), "A section of steel pipe, cold and dense. Delivers brutal, crushing strikes.");
           Item ShotGun = new Item("shot gun", 100, new DamageItem(new Shoot()), "An old, sawed-off shotgun. Loud, powerful, and devastating at close range.");

           //Initialise Enemys
           Creature Thumper = new Creature("thumper", 30, new HeavyStrike(), "A hulking creature with distorted limbs that slam into the ground with bone-cracking force. Slow but terrifyingly strong.");
           Creature Bracken = new Creature("bracken", 20, new InstantKill(), "A tall, silent humanoid shape that stalks in the dark. Moves unnaturally fast and kills without hesitation.");
           Creature BunkerSpider = new Creature("bunker spider", 25, new Strike(), "A large, skittering spider mutated by the environment. Its strikes are quick and venomous.");
           Creature Nutcracker = new Creature("nutcracker", 40, new Shoot(), "A mechanical abomination with a hinged steel jaw mechanism. Raises its weapon with cold precision before firing with deadly accuracy.");

           //Initialise ChoiceBasedPuzzles
           Puzzle ChoicePuzzle = new Puzzle(new ChoiceBased("This room contains a choice based puzzle, to pass through you must answer the following:",
                                                             "In programming, what is the main purpose of using a hash table (or dictionary/map)?",
                                                             ["A. To store data in a sorted list for fast sequential access",
                                                              "B. To store key–value pairs for fast lookups using a unique key",
                                                              "C. To execute multiple tasks at the same time using parallel threads"], "B"));

           Puzzle MemoryBased = new Puzzle(new MemoryBased("This room contains a memory based puzzle, to pass through you must repeat the sequence 8 times back to the terminal"));

           Puzzle SingleAnswer1 = new Puzzle(new SingleAnswer("This room contains a single answer based puzzle, to pass through you must answer the following:", "What C# keyword is used to define a method that must be implemented by any non-abstract derived", "abstract"));
           Puzzle SingleAnswer2 = new Puzzle(new SingleAnswer("This room contains a single answer based puzzle, to pass through you must answer the following:", "What keyword is used in C# to create an instance of a class?", "new"));


            //Initially Create Rooms

            //Ship

            Ship.AddRoom("0,0", new RoomBuilder().AddMainData(
                "Ship Control Compartment",
                new List<Item> {  },
                "The shuttle’s engine hums steadily. Loose wiring and blinking panels line the walls."
            ).Build());

            Ship.AddRoom("0,1", new RoomBuilder().AddMainData(
                "Ship Entrance",
                new List<Item> {  },
                "Metal benches and storage racks sit bolted to the floor. The exit ramp leads into the facility."
            ).Build());


            //WareHouse

            WareHouse.AddRoom("-1,2", new RoomBuilder().AddMainData(
                "Storage Room A",
                new List<Item> { LargeAxle },
                "Stacks of old shipping crates rest under layers of dust. Something has disturbed the cobwebs recently."
            ).AddPuzzle(ChoicePuzzle).Build());

            WareHouse.AddRoom("0,2", new RoomBuilder().AddMainData(
                "Main WareHouse Entrance",
                new List<Item> { Cog, Pipe },
                "Large cargo doors dominate the room. Forklifts sit abandoned, and scattered scrap covers the floor."
            ).Build());

            WareHouse.AddRoom("1,2", new RoomBuilder().AddMainData(
                "Logistics Office",
                new List<Item> { SignPost },
                "Clipboards, terminals, and scattered papers clutter the desks. The smell of mold lingers."
            ).AddEnemy(Thumper).Build());

            WareHouse.AddRoom("-1,3", new RoomBuilder().AddMainData(
                "Observation Control Room",
                new List<Item> { LargeAxle, ShotGun},
                "Dust-covered windows overlook the warehouse floor. A chair lies knocked over beside the monitors."
            ).AddPuzzle(SingleAnswer1).Build());

            WareHouse.AddRoom("0,3", new RoomBuilder().AddMainData(
                "Maintenance Workshop",
                new List<Item> { EnginePart },
                "Broken tools and abandoned machinery fill the benches. Deep scratches line the metal cabinets."
            ).AddEnemy(Bracken).Build());

            WareHouse.AddRoom("1,3", new RoomBuilder().AddMainData(
                "Security Monitoring Room",
                new List<Item> { Lockpicker },
                "Old security screens flicker with static. Lockers stand open, their contents missing."
            ).AddPuzzle(SingleAnswer2).Build());

            WareHouse.AddRoom("-1,4", new RoomBuilder().AddMainData(
                "Lower Cargo Storage",
                new List<Item> { EnginePart, Pipe},
                "Dim emergency lights cast long shadows across stacked crates. The air feels cold and still."
            ).AddEnemy(BunkerSpider).Build());

            WareHouse.AddRoom("0,4", new RoomBuilder().AddMainData(
                "Lower Access Hallway",
                new List<Item> { MetalSheet, Lockpicker},
                "A narrow concrete hallway with peeling paint. Every step echoes louder than it should."
            ).AddPuzzle(MemoryBased).Build());

            WareHouse.AddRoom("1,4", new RoomBuilder().AddMainData(
                "Lower Management Office",
                new List<Item> {  },
                "Old documents lie scattered across the floor. A broken desk lamp flickers intermittently."
            ).AddEnemy(Nutcracker).Build());

            //Add surrounding rooms so they are visible
            Ship.Rooms["0,0"].SurroundingRooms = new Dictionary<string, Room>{
                { "Forward", Ship.Rooms["0,1"] } // Engine Room -> Crew Quarters
            };

            Ship.Rooms["0,1"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", Ship.Rooms["0,0"] },       // Crew Quarters -> Engine Room
                { "Forward", WareHouse.Rooms["0,2"] }  // Crew Quarters -> Loading Dock
            };

            WareHouse.Rooms["-1,2"].SurroundingRooms = new Dictionary<string, Room>{
                { "Right", WareHouse.Rooms["0,2"] },  // Storage A -> Loading Dock
                { "Forward", WareHouse.Rooms["-1,3"] } // Storage A -> Observation Room
            };

            WareHouse.Rooms["0,2"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", Ship.Rooms["0,1"] },        // Loading Dock -> Crew Quarters
                { "Left", WareHouse.Rooms["-1,2"] },  // Loading Dock -> Storage A
                { "Right", WareHouse.Rooms["1,2"] },  // Loading Dock -> Supply Office
                { "Forward", WareHouse.Rooms["0,3"] } // Loading Dock -> Maintenance Bay
            };

            WareHouse.Rooms["1,2"].SurroundingRooms = new Dictionary<string, Room>{
                { "Left", WareHouse.Rooms["0,2"] },    // Supply Office -> Loading Dock
                { "Forward", WareHouse.Rooms["1,3"] }  // Supply Office -> Security Room
            };

            WareHouse.Rooms["-1,3"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["-1,2"] },   // Observation Room -> Storage A
                { "Right", WareHouse.Rooms["0,3"] },   // Observation Room -> Maintenance Bay
                { "Forward", WareHouse.Rooms["-1,4"] } // Observation Room -> Lower Storage
            };

            WareHouse.Rooms["0,3"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["0,2"] },    // Maintenance Bay -> Loading Dock
                { "Left", WareHouse.Rooms["-1,3"] },   // Maintenance Bay -> Observation Room
                { "Right", WareHouse.Rooms["1,3"] },   // Maintenance Bay -> Security Room
                { "Forward", WareHouse.Rooms["0,4"] }  // Maintenance Bay -> Lower Corridor
            };

            WareHouse.Rooms["1,3"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["1,2"] },    // Security Room -> Supply Office
                { "Left", WareHouse.Rooms["0,3"] },    // Security Room -> Maintenance Bay
                { "Forward", WareHouse.Rooms["1,4"] }  // Security Room -> Lower Office
            };

            WareHouse.Rooms["-1,4"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["-1,3"] },   // Lower Storage -> Observation Room
                { "Right", WareHouse.Rooms["0,4"] }    // Lower Storage -> Lower Corridor
            };

            WareHouse.Rooms["0,4"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["0,3"] },    // Lower Corridor -> Maintenance Bay
                { "Left", WareHouse.Rooms["-1,4"] },   // Lower Corridor -> Lower Storage
                { "Right", WareHouse.Rooms["1,4"] }    // Lower Corridor -> Lower Office
            };

            WareHouse.Rooms["1,4"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", WareHouse.Rooms["1,3"] },    // Lower Office -> Security Room
                { "Left", WareHouse.Rooms["0,4"] }     // Lower Office -> Lower Corridor
            };


    }
}
