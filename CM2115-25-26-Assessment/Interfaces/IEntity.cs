using System;
using entitys;
using interfaces.Observer;

namespace interfaces.Entitys;

public interface IEntity 
{
    //Method signature
    void SetHp(int value);

    void AttachObserver(IObserver observer);

    void DetachObserver(IObserver observer);

}
