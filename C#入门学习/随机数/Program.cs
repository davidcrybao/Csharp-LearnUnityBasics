// See https://aka.ms/new-console-template for more information
Random r = new Random();
int attack = r.Next(8, 13);
int monsterDefence = 10;
int monsterHealth = 20;

while (monsterHealth > 0)
{
    int attackSubtractDefence;
    attack = r.Next(8, 13);
    if (attack > monsterDefence)
    {
        attackSubtractDefence = attack - monsterDefence;
        monsterHealth = Math.Max(0, monsterHealth - attackSubtractDefence);

        Console.WriteLine("我现在攻击力是{0},对怪兽造成了{1}的伤害,怪兽血量为{2}", attack, attackSubtractDefence, monsterHealth);

    }
    else
    {


        Console.WriteLine("我现在攻击力是{0},根本打不动这个怪兽,怪兽护甲是{1},怪兽血量为{2}", attack, monsterDefence, monsterHealth);
    }
}
