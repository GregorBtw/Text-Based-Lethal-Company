using behaviours.itembehaviours;
using behaviours.mapBehaviours;
using entitys.players;
using interfaces.moonBehaviours;
using items;
using maps;
using rooms;

namespace Moons;

public class Moon
{
    // The player's ship area (a small map within the moon).
    public Map Ship { get; set; }

    // The warehouse area where the player collects scrap (another map).
    public Map WareHouse { get; set; }

    // Behaviour that defines how this moon is generated and structured.
    // Uses Strategy Pattern for different moon types.
    public IMoonBehaviour MoonType;

    // Initializes the Moon with Ship and Warehouse maps, using a moon behaviour.
    public Moon(IMoonBehaviour moontype)
    {
        this.Ship = new Map(new Ship());
        this.WareHouse = new Map(new WareHouse());
        this.MoonType = moontype;
    }

    // Delegates creation of the Moon's maps to the moon behaviour.
    public void Initialise()
    {
        MoonType.CreateMoon(Ship, WareHouse);
    }

    // Checks if the player is currently in the ship area.
    public bool CheckIfInShip(Player User)
    {
        foreach (var room in Ship.Rooms)
        {
            if (room.Value.Name == User.CurrentRoom.Name)
            {
                return true;
            }
        }
        
        return false;
    }
}