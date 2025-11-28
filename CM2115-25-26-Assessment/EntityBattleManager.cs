
using entitys.Creatures;
using entitys.players;
using Game_Data;
using inventory;
using items;

public class EntityBattleManager
{

    public static void StartBattle(Player User, Creature enemy)
    {
        enemy.AttachObserver(enemy.HealthBar);

        Console.WriteLine($"You have encountered a {enemy.Name}!\n");
        Thread.Sleep(2500);
        Console.Clear();
        Console.WriteLine($"{enemy.Description}\n");
        Thread.Sleep(2500);
        Console.Clear();

        Console.WriteLine("What item would you like to use to attack?: \n");

        User.Inventory.DisplayWeapons();

        String? Str = Console.ReadLine();
        String Input = Str.ToLower();

        Item? Weapon = User.Inventory.GetItem(Input);

        while (User.HP > 0 && enemy.HP > 0)
        {
            GameData.displayBattleHealth(User, enemy);
            Console.WriteLine("\nPress any key to attack: ");
            Console.ReadKey();
            User.AttackEnemy(Weapon);
            Thread.Sleep(2500);
            Console.Clear();
            

            if (enemy.HP <= 0)
            {
                break;                
            }

            GameData.displayBattleHealth(User, enemy);
            enemy.AttackPlayer(User);
            Thread.Sleep(2500);
            Console.Clear();
            
        }

        if (User.HP <= 0)
        {
            Console.Clear();
            Console.WriteLine("Player lost!");
            Thread.Sleep(2500);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Enemy defeated!");
            Thread.Sleep(2500);
        }

        Console.Clear();
        User.Inventory.RemoveItem(Weapon);
        Console.WriteLine($"\nYou used the {Weapon.Name}, it is now broken");
        Thread.Sleep(3000);

    }
}