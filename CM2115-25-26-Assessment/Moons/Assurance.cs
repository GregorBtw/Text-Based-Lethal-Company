using interfaces.moonBehaviours;
using rooms;
using items;
using maps;
using behaviours.itembehaviours;



public class Assurance : IMoonBehaviour
{
    public void CreateMoon(Map Ship, Map WareHouse)
    {
            //Initialise Items
            Item Cog = new Item("Cog", 45, new ValueItem());

            //Initially Create Rooms
            Ship.AddRoom("0,0", Ship.CreateRoom("Engine Room", new List<Item> { Cog }, "The heart of the ship hums quietly. You can smell oil and steam.", null));
            Ship.AddRoom("0,1", Ship.CreateRoom("Crew Quarters", new List<Item> { Cog }, "Bunks line the walls. Someone left a half-eaten ration on the table.", null));

            WareHouse.AddRoom("-1,2", WareHouse.CreateRoom("Storage A", new List<Item> { Cog }, "Crates are stacked high, covered in dust and cobwebs.", null));
            WareHouse.AddRoom("0,2", WareHouse.CreateRoom("Loading Dock", new List<Item> { Cog }, "A loading crane looms above the platform. The air smells of metal.", null));
            WareHouse.AddRoom("1,2", WareHouse.CreateRoom("Supply Office", new List<Item> { Cog }, "A cluttered desk with scattered papers and a broken lamp.", null));
            WareHouse.AddRoom("-1,3", WareHouse.CreateRoom("Observation Room", new List<Item> { Cog }, "Large glass panels overlook the docking area below.", null));
            WareHouse.AddRoom("0,3", WareHouse.CreateRoom("Maintenance Bay", new List<Item> { Cog }, "A place for fixing equipment. Tools hang neatly on the wall.", null));
            WareHouse.AddRoom("1,3", WareHouse.CreateRoom("Security Room", new List<Item> { Cog }, "Monitors flicker, showing camera feeds from every corner of the warehouse.", null));
            WareHouse.AddRoom("-1,4", WareHouse.CreateRoom("Lower Storage", new List<Item> { Cog }, "The dimly lit lower section of the warehouse. Smells faintly of oil.", null));
            WareHouse.AddRoom("0,4", WareHouse.CreateRoom("Lower Corridor", new List<Item> { Cog }, "A narrow corridor with flickering lights overhead.", null));
            WareHouse.AddRoom("1,4", WareHouse.CreateRoom("Lower Office", new List<Item> { Cog }, "Dusty desks and scattered blueprints cover the room.", null));

            //Add surrounding rooms so they are visible
            Ship.Rooms["0,0"].SurroundingRooms = new Dictionary<string, Room>{
                { "Forward", Ship.Rooms["0,1"] } // Engine Room -> Crew Quarters
            };

            Ship.Rooms["0,1"].SurroundingRooms = new Dictionary<string, Room>{
                { "Back", Ship.Rooms["0,0"] },       // Crew Quarters -> Engine Room
                { "Right", WareHouse.Rooms["0,2"] }  // Crew Quarters -> Loading Dock
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
