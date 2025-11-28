using System.Reflection.Metadata.Ecma335;
using rooms;
using interfaces.attackbehaviours;
using interfaces.Observer;
using Observers.HealthBar;

namespace entitys;

public class Entity
{
    // Basic identifying name for any entity (player, creature, etc.).
    public String Name;

    // Each entity has its own health bar observer for UI updates.
    public HealthBar HealthBar = new HealthBar();

    // List of observers subscribed to health changes (Observer pattern).
    public List<IObserver> Observers = new List<IObserver>();

    // Current hit points (health value).
    public int HP;

    // Base constructor for all entities.
    // Sets initial name and health.
    public Entity(String name, int hp)
    {
        this.Name = name;
        this.HP = hp;
    }

    // Adjusts HP and notifies all observers about the change.
    // Allows UI elements or other systems to react to HP updates.
    public void SetHp(int value)
    {
        HP = value;

        // Notify all observers of new HP value.
        foreach (var observer in Observers)
            observer.Update(HP);
    }

    // Adds an observer to the entity (e.g., health bar UI).
    public void AttachObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    // Removes an observer so it no longer receives HP updates.
    public void DetachObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }
}
