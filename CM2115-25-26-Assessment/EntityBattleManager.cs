
using entitys.Creatures;
using entitys.players;
using Game_Data;

public class EntityBattleManager
{

    public static void StartBattle(Player User, Creature enemy)
    {
        enemy.AttachObserver(enemy.HealthBar);

        while (User.HP > 0 && enemy.HP > 0)
        {
            GameData.displayBattleHealth(User, enemy);
            User.AttackEnemy();
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
    }
}