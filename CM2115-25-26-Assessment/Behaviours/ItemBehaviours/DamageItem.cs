using System.Runtime.CompilerServices;
using interfaces.itembehaviours;
using interfaces.attackbehaviours;
using entitys;

namespace behaviours.itembehaviours;
public class DamageItem : IItemBehaviour
{
    //Attributes
    public IAttackBehaviour AttackBehaviour;

    //Constructor
    public DamageItem(IAttackBehaviour attackBehaviour)
    {
        this.AttackBehaviour = attackBehaviour;
    }

    //Methods
    public void Use(Entity target)
    {
        AttackBehaviour.DealDamage(target);
    }
    public void Equip()
    {
        Console.WriteLine("You picked up a Weapon!\n");
        Console.WriteLine("You are able to attack enemys with this");
    }
}