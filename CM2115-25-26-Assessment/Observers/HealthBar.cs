using interfaces.Observer;

namespace Observers.HealthBar;

public class HealthBar : IObserver
{
    public void Update(int hp)
    {
        decimal roundedPercentage = Math.Ceiling((decimal)hp / 5);

        var healthbar = "";

        for(var i = 0; i < roundedPercentage; i++)
        {
            healthbar+="█";
        }
        if (healthbar.Length < 20)
        {
            for(var i=0;i < (20 - roundedPercentage); i++)
            {
                healthbar+="-";
            }
        }

        Console.WriteLine($"[{healthbar}] {hp}%");
    }
}