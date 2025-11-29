using System;
using entitys;
using interfaces.attackbehaviours;

namespace behaviours.attackbehaviours;
public class Shoot : IAttackBehaviour
{

    //Attributes

    public int DamageAmount = 30;

    //Methods
    public void DealDamage(Entity target, int Multiplier)
    {
        Console.WriteLine("A shot was fired with a gun");
        target.SetHp(target.HP-(DamageAmount*Multiplier));
    }
}