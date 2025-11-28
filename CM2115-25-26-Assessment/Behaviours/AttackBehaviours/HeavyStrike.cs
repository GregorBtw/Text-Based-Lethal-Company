using System;
using entitys;
using interfaces.attackbehaviours;

namespace behaviours.attackbehaviours;
public class HeavyStrike : IAttackBehaviour
{

    //Attributes
    public int DamageAmount = 20;

    //Methods
    public void DealDamage(Entity target)
    {
        Console.WriteLine("A heavy strike has been landed");
        target.SetHp(target.HP-DamageAmount);
    }
}