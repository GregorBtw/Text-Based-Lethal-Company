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
        //Implementation of instant kill damage logic
        // For example, reduce target's HP to 0
    }
}