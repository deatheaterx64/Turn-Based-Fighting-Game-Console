using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        float d =Difficulty();
        Player p = new Player(100, 20, d);
        Enemy e1 = new Enemy(50, 20, "ogre");
        Enemy e2 = new Enemy(30, 15, "ghast");
        Enemy e3 = new Enemy(20, 10, "goblin");
        while(true)
        {
            if (!(p.health > 0))
            {
                Console.WriteLine("you lost");
                break;
            }
            if (e1.health<=0&&e2.health<=0&&e3.health<=0)
            {
                Console.WriteLine("you won");
                break;
            }
            Standby(p, e1, e2, e3);
            YourTurn(p, e1, e2, e3);
            EnemyTurn(p ,e1 ,e2 ,e3);
        }
    }
	//=====================================================================================
    static float Difficulty()
    {
        float d;
        Console.WriteLine("choose the difficulty :");
        Console.WriteLine("1. easy");
        Console.WriteLine("2. normal");
        Console.WriteLine("3. hard");
        int dif=Convert.ToInt32(Console.ReadLine());
        switch (dif)
        {
            case 1:
                d =1.5f;
                break;
            case 2:
                d = 1.0f;
                break;
            case 3:
                d = 0.5f;
                break;
            default:
                d = 1.0f;
                break;
        }
        return d;
    }
	//=====================================================================================
    static void Standby(Player player,Enemy enemy1,Enemy enemy2,Enemy enemy3)
    {
        Console.WriteLine("\n--------------");
        Console.WriteLine("your health : " + player.health);
        Console.WriteLine("ogre health : " + (enemy1.health > 0 ? enemy1.health:0));
        Console.WriteLine("ghast health : " + (enemy2.health > 0 ? enemy2.health : 0));
        Console.WriteLine("goblin health : " + (enemy3.health > 0 ? enemy3.health : 0));
        Console.WriteLine("--------------\n");
    }
	//=====================================================================================
    static void YourTurn(Player player, Enemy enemy1, Enemy enemy2, Enemy enemy3)
    {
        Console.WriteLine("what do you want to do?");
        Console.WriteLine("1. attack ogre");
        Console.WriteLine("2. attack ghast");
        Console.WriteLine("3. attack goblin");
        Console.WriteLine("4. heal 25 hp");
        int action = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("---------------");
        switch (action)
        {
            case 1:
                if (enemy1.health > 0) { enemy1.health -= player.attackDamage;Console.WriteLine("you damaged the ogre by "+player.attackDamage+"\n"); }
                else Console.WriteLine("enemy already dead\n");
                break;
            case 2:
                if (enemy2.health > 0) {enemy2.health -= player.attackDamage; Console.WriteLine("you damaged the ghast by " + player.attackDamage+"\n"); }
                else Console.WriteLine("enemy already dead\n");
                break;
            case 3:
                if (enemy3.health > 0){ enemy3.health -= player.attackDamage; Console.WriteLine("you damaged the goblin by " + player.attackDamage+"\n");
        }
                else Console.WriteLine("enemy already dead\n");
                break;
            default:
                player.health += 25;
                break;
        }
    }
	//=====================================================================================
    static void EnemyTurn(Player player, Enemy enemy1, Enemy enemy2, Enemy enemy3)
    {
        if (enemy1.health > 0)
        {
            player.health -= enemy1.attackDamage;
            Console.WriteLine("ogre damaged you by " + enemy1.attackDamage);
        }
        if (enemy2.health > 0)
        {
            player.health -= enemy2.attackDamage;
            Console.WriteLine("ghast damaged you by " + enemy2.attackDamage);
        }
        if (enemy3.health > 0)
        {
            player.health -= enemy3.attackDamage;
            Console.WriteLine("goblin damaged you by " + enemy3.attackDamage);
        }
        Console.WriteLine("--------------");
    }
}
//####################################################################################
class Player
{
    public int health;
    public int attackDamage;
    public Player(int h,int d,float dif)
    {
        health =(int) (dif * h);
        attackDamage =(int) (dif * d);
    }
}
//####################################################################################
class Enemy
{
    public int health;
    public string name;
    public int attackDamage;
    public Enemy(int h,int d,string n)
    {
        name = n;
        health = h;
        attackDamage = d;
    }
}
