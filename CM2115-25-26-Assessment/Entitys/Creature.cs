using System.Reflection.Metadata.Ecma335;
using entitys;
using rooms;
using interfaces.attackbehaviours;

namespace entitys.Creatures;

public class Creature : Entity
{

    //Attributes

    public String Description;

    public IAttackBehaviour AttackBehaviour;

    //Constructor
    public Creature(String name, int hp, IAttackBehaviour attackBehaviour, String description) : base(name, hp)
    {
        this.AttackBehaviour = attackBehaviour;
        this.Description = description;
    }
}