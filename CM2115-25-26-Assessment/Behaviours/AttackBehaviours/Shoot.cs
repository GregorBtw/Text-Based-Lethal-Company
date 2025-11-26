using System;
using entitys;
using interfaces.attackbehaviours;

namespace behaviours.attackbehaviours;
public class Shoot : IAttackBehaviour
{

    //Attributes

    public int DamageAmount = 60;

    //Methods
    public void DealDamage(Entity target)
    {
        Console.WriteLine("A shot was fired with a gun");
        target.SetHp(target.HP-DamageAmount);
    }
}