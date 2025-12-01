using System;
using entitys;

namespace interfaces.itembehaviours;

public interface IItemBehaviour
{
    //Method signature

    void Use(Entity target, int Multiplier);
    void Equip();
}
