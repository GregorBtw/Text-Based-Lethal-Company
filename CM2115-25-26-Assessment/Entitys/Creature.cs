using System.Reflection.Metadata.Ecma335;
using CM2115_25_26_Assessment;

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