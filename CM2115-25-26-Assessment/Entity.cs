using System.Reflection.Metadata.Ecma335;
using rooms;
using interfaces.attackbehaviours;
using interfaces.Observer;
using Observers.HealthBar;

namespace entitys;

public class Entity
{

    //Attributes

    public String Name;

    public HealthBar HealthBar = new HealthBar();

    public List<IObserver> Observers = new List<IObserver>();

    public int HP;

    //Constructor
    public Entity(String name, int hp)
    {
        this.Name = name;
        this.HP = hp;
    }

    //Methods

    public void SetHp(int value)
    {
        HP = value;
        foreach (var observer in Observers)
            observer.Update(HP);
    }

    public void AttachObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }
}