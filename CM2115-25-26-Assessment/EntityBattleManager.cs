using entitys.Creatures;
using entitys.players;
using Game_Data;
using inventory;
using items;

public class EntityBattleManager
{
    // Handles a full turn-based battle sequence between the player and a creature.
    public static void StartBattle(Player User, Creature enemy)
    {
        // Attach the enemy's health bar observer so its HP updates display correctly.
        enemy.AttachObserver(enemy.HealthBar);

        // Intro sequence: show enemy encounter and description.
        Console.WriteLine($"You have encountered a {enemy.Name}!\n");
        Thread.Sleep(2500);
        Console.Clear();

        Console.WriteLine($"{enemy.Description}\n");
        Thread.Sleep(2500);
        Console.Clear();

        // Ask the player which weapon they want to use.
        Console.WriteLine("What item would you like to use to attack?: \n");
        User.Inventory.DisplayWeapons();

        // Get weapon input from the player.
        String? Str = Console.ReadLine();
        String Input = Str.Trim().ToLower();
        Item? Weapon = User.Inventory.Items.FirstOrDefault(item => item.Name.ToLower() == Input);

        // Main battle loop — continues until either the player or enemy reaches 0 HP.
        while (User.HP > 0 && enemy.HP > 0)
        {
            // Display both health bars before the player's attack.
            GameData.displayBattleHealth(User, enemy);

            Console.WriteLine("\nPress any key to attack: ");
            Console.ReadKey();

            // Player deals damage using the chosen weapon.
            User.AttackEnemy(Weapon);
            Thread.Sleep(2500);
            Console.Clear();

            // Enemy defeated → exit loop before counterattack.
            if (enemy.HP <= 0)
            {
                break;
            }

            // Show updated health, then enemy attacks the player.
            GameData.displayBattleHealth(User, enemy);
            enemy.AttackPlayer(User);
            Thread.Sleep(2500);
            Console.Clear();
        }

        // Post-battle outcome logic.
        if (User.HP <= 0)
        {
            // Player died → end game.
            Console.Clear();
            Console.WriteLine("Player lost!");
            Thread.Sleep(2500);
            User.isPlaying = false;
        }
        else
        {
            // Enemy died → mark it as dead.
            Console.Clear();
            Console.WriteLine("Enemy defeated!");
            Thread.Sleep(2500);
            enemy.isDead = true;
        }

        // After battle: weapon breaks and is removed from inventory.
        Console.Clear();
        Weapon.Use(User);
        User.Inventory.RemoveItem(Weapon);
    }
}
