using System.Reflection.Metadata.Ecma335;
using rooms;
using interfaces.attackbehaviours;

namespace entitys;

public class Entity
{

    //Attributes

    private String Name;

    private int HP;

    public Room CurrentRoom;

    //Constructor
    public Entity(String name, int hp, Room currentRoom)
    {
        this.Name = name;
        this.HP = hp;
        this.CurrentRoom = currentRoom;
    }

    //Methods

    public void DealDamage(IAttackBehaviour AttackBehaviour)
    {
        //Implementation of dealing damage logic
    }
}