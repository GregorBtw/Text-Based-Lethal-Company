using behaviours.itembehaviours;
using behaviours.movebehaviours;
using items;
using maps;
using rooms;

public class Planet
{
    //Attributes
    public Map Ship { get; set; }

    public Map WareHouse { get; set; }



    //Constructors

    public Planet()
    {
        this.Ship = new Map(new MoveInShip());
        
        this.WareHouse = new Map(new MoveInWareHouse());


    }
    public void CreatePlanet()
    {
        Item Cog = new Item("Cog", 45, new ValueItem());


        // === Create Rooms for Ship ===
        Ship.AddRoom("0,0", Ship.CreateRoom(
            "Engine Room",
            new List<Item> { Cog },
            "The heart of the ship hums quietly. You can smell oil and steam.",
            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
            }
        ));

        Ship.AddRoom("0,1", Ship.CreateRoom(
            "Crew Quarters",
            new List<Item> { Cog },
            "Bunks line the walls. Someone left a half-eaten ration on the table.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,0"]},
               { "North", Ship.Rooms["0,2"]}
            }
        ));


        // === Create Rooms for Warehouse ===
        WareHouse.AddRoom("-1,2", WareHouse.CreateRoom(
            "Storage A",
            new List<Item> { Cog },
            "Crates are stacked high, covered in dust and cobwebs.",

            new Dictionary<string, Room>
            {
               { "South", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]}
            }
        ));

        WareHouse.AddRoom("0,2", WareHouse.CreateRoom(
            "Loading Dock",
            new List<Item> { Cog },
            "A loading crane looms above the platform. The air smells of metal.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]}
            }
        ));

        WareHouse.AddRoom("1,2", WareHouse.CreateRoom(
            "Supply Office",
            new List<Item> { Cog },
            "A cluttered desk with scattered papers and a broken lamp.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},

            }
        ));

        WareHouse.AddRoom("-1,3", WareHouse.CreateRoom(
            "Observation Room",
            new List<Item> { Cog },
            "Large glass panels overlook the docking area below.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
            }
        ));

        WareHouse.AddRoom("0,3", WareHouse.CreateRoom(
            "Maintenance Bay",
            new List<Item> { Cog },
            "A place for fixing equipment. Tools hang neatly on the wall.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]}

            }
        ));


        WareHouse.AddRoom("1,3", WareHouse.CreateRoom(
            "Security Room",
            new List<Item> { Cog },
            "Monitors flicker, showing camera feeds from every corner of the warehouse.",

            new Dictionary<string, Room>
            {
               { "North", Ship.Rooms["0,1"]},
               { "North", Ship.Rooms["0,1"]},
            }
        ));

    }





    

    //Methods

}