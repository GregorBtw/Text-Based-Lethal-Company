using interfaces.Observer;

namespace Observers.HealthBar;

public class HealthBar : IHealthBar
{

    //attributes

    public string healthBar = "";


    //Methods

    public void Update(int hp)
    {
        decimal roundedPercentage = Math.Ceiling((decimal)hp / 5);

        healthBar = "";

        for(var i = 0; i < roundedPercentage; i++)
        {
            healthBar+="█";
        }
        if (healthBar.Length < 20)
        {
            for(var i=0;i < (20 - roundedPercentage); i++)
            {
                healthBar+="-";
            }
        }

        healthBar = $"[{healthBar}] {hp}%HP";

    }

    public void DisplayHealthBar()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine(healthBar);
    }
}