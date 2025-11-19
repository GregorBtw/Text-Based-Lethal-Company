using interfaces.Observer;

namespace Observers.HealthBar;

public class HealthBar : IObserver
{
    public void Update(int hp)
    {
        Console.WriteLine($"health is now at {hp}");
    }
}