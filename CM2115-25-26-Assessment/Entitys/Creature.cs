using System.Reflection.Metadata.Ecma335;
using entitys;
using rooms;
using interfaces.attackbehaviours;

namespace entitys.Creatures;

public class Creature : Entity
{

    //Attributes

    public IAttackBehaviour AttackBehaviour;

    //Constructor
    public Creature(String name, int hp, Room currentRoom, IAttackBehaviour attackBehaviour) : base(name, hp, currentRoom)
    {
        this.AttackBehaviour = attackBehaviour;
    }
}