using System;
using entitys;
using interfaces.attackbehaviours;

namespace behaviours.attackbehaviours;
public class InstantKill : IAttackBehaviour
{

    //Attributes

    public int DamageAmount = 100;

    //Methods
    public void DealDamage(Entity target)
    {
        Console.WriteLine("You where instantly killed");
        target.SetHp(target.HP-DamageAmount);
    }
}