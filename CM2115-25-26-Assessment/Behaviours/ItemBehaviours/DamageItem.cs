using System.Runtime.CompilerServices;
using interfaces.itembehaviours;
using interfaces.attackbehaviours;
using entitys;

namespace behaviours.itembehaviours;

public class DamageItem : IItemBehaviour
{
    // Attribute to store attack behavior for the weapon
    public IAttackBehaviour AttackBehaviour;

    // Constructor initializes the attack behavior for the damage item (e.g., weapon)
    public DamageItem(IAttackBehaviour attackBehaviour)
    {
        this.AttackBehaviour = attackBehaviour;
    }

    // Use method triggers the attack behavior, dealing damage to the target entity
    public void Use(Entity target, int Multiplier)
    {
        AttackBehaviour.DealDamage(target, Multiplier);
    }

    // Equip method gives feedback to the player when they pick up a weapon
    public void Equip()
    {
        Console.WriteLine("You picked up a Weapon!\n");
        Console.WriteLine("You are able to attack enemies with this");
    }
}
