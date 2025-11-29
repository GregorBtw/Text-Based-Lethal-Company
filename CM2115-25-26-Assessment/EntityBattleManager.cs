using entitys.Creatures;
using entitys.players;
using Game_Data;
using inventory;
using items;
using behaviours.itembehaviours;

public class EntityBattleManager
{
    // Handles a full turn-based battle sequence between the player and a creature.
    public static void StartBattle(Player User, Creature enemy)
    {
        enemy.AttachObserver(enemy.HealthBar);

        Console.WriteLine($"You have encountered a {enemy.Name}!\n");
        Thread.Sleep(2500);
        Console.Clear();

        Console.WriteLine($"{enemy.Description}\n");
        Thread.Sleep(2500);
        Console.Clear();

        // Check if the player has any weapons
        var weapons = User.Inventory.Items.Where(item => item.ItemBehaviour is DamageItem).ToList();

        if (weapons.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("You have no weapons to attack with!");
            Thread.Sleep(2000);

            // Enemy hits player for double damage once
            enemy.AttackBehaviour.DealDamage(User, 2);
            Console.WriteLine($"The {enemy.Name} attacks you for double the damage!");
            Thread.Sleep(2500);

            Console.WriteLine("You manage to escape/passed through the battle.");
            Thread.Sleep(2000);
            return; // End the battle
        }

        // Ask the player which weapon they want to use
        Console.WriteLine("What item would you like to use to attack?: \n");
        User.Inventory.DisplayWeapons();

        String? Str = Console.ReadLine();
        String Input = (Str ?? "").Trim().ToLower();
        Item? Weapon = User.Inventory.Items.FirstOrDefault(item => item.Name.ToLower() == Input);

        while (User.HP > 0 && enemy.HP > 0)
        {
            GameData.displayBattleHealth(User, enemy);
            Console.WriteLine("\nPress any key to attack: ");
            Console.ReadKey();

            User.AttackEnemy(Weapon!);
            Thread.Sleep(2500);
            Console.Clear();

            if (enemy.HP <= 0) break;

            GameData.displayBattleHealth(User, enemy);
            enemy.AttackPlayer(User, 1);
            Thread.Sleep(2500);
            Console.Clear();
        }

        if (User.HP <= 0)
        {
            Console.Clear();
            Console.WriteLine("Player lost!");
            Thread.Sleep(2500);
            User.isPlaying = false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Enemy defeated!");
            Thread.Sleep(2500);
            enemy.isDead = true;
        }

        Console.Clear();
        Weapon!.Use(User);
        User.Inventory.RemoveItem(Weapon);
    }

}
