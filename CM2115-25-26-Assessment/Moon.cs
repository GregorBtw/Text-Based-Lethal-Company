using behaviours.itembehaviours;
using behaviours.movebehaviours;
using entitys.players;
using interfaces.moonBehaviours;
using items;
using maps;
using rooms;

namespace Moons;

public class Moon
{
    //Attributes
    public Map Ship { get; set; }

    public Map WareHouse { get; set; }

    public IMoonBehaviour MoonType;



    //Constructors

    public Moon(IMoonBehaviour moontype)
    {
        this.Ship = new Map(new Ship());

        this.WareHouse = new Map(new WareHouse());

        this.MoonType = moontype;
    }

    public void Initialise()
    {
        MoonType.CreateMoon(Ship, WareHouse);
    }

        //Methods

    public bool CheckIfInShip(Player User)
    {

        foreach(var room in Ship.Rooms)
        {
            if (room.Value.Name == User.CurrentRoom.Name)
            {
                return true;
            }

        }
        
        return false;
   
    }
}



