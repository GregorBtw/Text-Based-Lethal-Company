using behaviours.itembehaviours;
using behaviours.movebehaviours;
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
        this.Ship = new Map(new MoveInShip());

        this.WareHouse = new Map(new MoveInWareHouse());

        this.MoonType = moontype;
    }

    public void Initialise()
    {
        MoonType.CreateMoon(Ship, WareHouse);
    }
}

    //Methods

