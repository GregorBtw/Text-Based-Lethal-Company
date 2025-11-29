using System.Reflection.Metadata.Ecma335;
using entitys;
using rooms;
using interfaces.attackbehaviours;
using entitys.players;

namespace entitys.Creatures;

public class Creature : Entity
{
    // Description of the creature (flavour text).
    public String Description;

    // Death flag; HP still determines real death.
    public bool isDead;

    // Strategy pattern: defines how the creature deals damage.
    public IAttackBehaviour AttackBehaviour;

    // Creates a creature with a name, HP, attack style, and description.
    public Creature(String name, int hp, IAttackBehaviour attackBehaviour, String description)
        : base(name, hp)
    {
        this.AttackBehaviour = attackBehaviour;
        this.Description = description;
    }

    // Makes the creature attack the player using its behaviour object.
    public void AttackPlayer(Player User,int Multiplier)
    {
        Console.WriteLine($"{Name} is now attacking you");
        AttackBehaviour.DealDamage(User, Multiplier);
    }
}
