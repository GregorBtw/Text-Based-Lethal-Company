using interfaces.moonBehaviours;
using rooms;
using items;
using maps;
using behaviours.itembehaviours;
using roomBuilder;
using entitys.Creatures;
using behaviours.attackbehaviours;



public class Assurance : IMoonBehaviour
{
    public void CreateMoon(Map Ship, Map WareHouse)
    {

           //Initialise Value Items
           Item Cog = new Item("Cog", 45, new ValueItem());
           Item LargeAxle = new Item("Large Axle", 90, new ValueItem());
           Item EnginePart = new Item("Engine Part", 85, new ValueItem());
           Item MetalSheet = new Item("Bent Metal Sheet", 35, new ValueItem());

           //Initialise Tool Items
           Item Lockpicker = new Item("Lockpicker", 90, new ToolItem());

           //Initialise Damage Items
           Item SignPost = new Item("Stop Sign", 90, new DamageItem(new Strike()));
           Item Pipe = new Item("Metal Pipe", 55, new DamageItem(new HeavyStrike()));
           Item ShotGun = new Item("Shot Gun", 100, new DamageItem(new Shoot()));


            //Initialise Enemys
            Creature Thumper = new Creature("Thumper", 60, new HeavyStrike());
            Creature Bracken = new Creature("Bracken", 120, new InstantKill());
            Creature BunkerSpider = new Creature("Bunker Spider", 80, new Strike());
            Creature Nutcracker = new Creature("Nutcracker", 100, new Shoot());


            //Initially Create Rooms

            //Ship

            Ship.AddRoom("0,0", new RoomBuilder().AddMainData(
                "Ship Engine Compartment",
                new List<Item> {  },
                "The shuttle’s engine hums steadily. Loose wiring and blinking panels line the walls."
            ).Build());

            Ship.AddRoom("0,1", new RoomBuilder().AddMainData(
                "Shuttle Entry Bay",
                new List<Item> {  },
                "Metal benches and storage racks sit bolted to the floor. The exit ramp leads into the facility."
            ).Build());


            //WareHouse

            WareHouse.AddRoom("-1,2", new RoomBuilder().AddMainData(
                "Storage Room A",
                new List<Item> { Cog, Pipe },
                "Stacks of old shipping crates rest under layers of dust. Something has disturbed the cobwebs recently."
            ).Build());

            WareHouse.AddRoom("0,2", new RoomBuilder().AddMainData(
                "Main Loading Dock",
                new List<Item> { LargeAxle },
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
            ).Build());

            WareHouse.AddRoom("0,3", new RoomBuilder().AddMainData(
                "Maintenance Workshop",
                new List<Item> { EnginePart },
                "Broken tools and abandoned machinery fill the benches. Deep scratches line the metal cabinets."
            ).AddEnemy(Bracken).Build());

            WareHouse.AddRoom("1,3", new RoomBuilder().AddMainData(
                "Security Monitoring Room",
                new List<Item> { Lockpicker },
                "Old security screens flicker with static. Lockers stand open, their contents missing."
            ).Build());

            WareHouse.AddRoom("-1,4", new RoomBuilder().AddMainData(
                "Lower Cargo Storage",
                new List<Item> { EnginePart, Pipe},
                "Dim emergency lights cast long shadows across stacked crates. The air feels cold and still."
            ).AddEnemy(BunkerSpider).Build());

            WareHouse.AddRoom("0,4", new RoomBuilder().AddMainData(
                "Lower Access Hallway",
                new List<Item> { MetalSheet, Lockpicker},
                "A narrow concrete hallway with peeling paint. Every step echoes louder than it should."
            ).Build());

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
