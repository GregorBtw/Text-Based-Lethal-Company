using System.Reflection.Metadata.Ecma335;
using rooms;
using interfaces.attackbehaviours;

namespace entitys;

public class Entity
{

    //Attributes

    public String Name;

    public int HP;

    //Constructor
    public Entity(String name, int hp)
    {
        this.Name = name;
        this.HP = hp;
    }

    //Methods

    public void DealDamage(IAttackBehaviour AttackBehaviour)
    {
        //Implementation of dealing damage logic
    }
}