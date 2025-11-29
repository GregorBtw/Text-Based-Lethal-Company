using System;
using entitys;
using interfaces.attackbehaviours;

namespace behaviours.attackbehaviours;
public class Strike : IAttackBehaviour
{

    //Attributes

    public int DamageAmount = 10;

    //Methods
    public void DealDamage(Entity target, int Multiplier)
    {
        Console.WriteLine("A strike was landed");
        target.SetHp(target.HP-(DamageAmount*Multiplier));
    }
}