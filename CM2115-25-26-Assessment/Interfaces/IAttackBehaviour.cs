using System;
using entitys;

namespace interfaces.attackbehaviours;

public interface IAttackBehaviour
{
    //Method signature
    void DealDamage(Entity target, int Multiplier);

}
