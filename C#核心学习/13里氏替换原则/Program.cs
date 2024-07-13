namespace _13里氏替换原则
{
    public class Person { }
    public class Student : Person
    {
        public void Talk()
        {
            Console.WriteLine("Asd");
        }
    }

    public class Monster
    { }

    public class Boss : Monster
    {
        public void UseSkill()
        {
            Console.WriteLine("Watch my skill!~");
        }
    }
    public class Goblin : Monster
    {
        public void Attack() { Console.Write("Attacking"); }
    }
    public class Weapon
    {
        public string name;

        public Weapon(string name)
        {
            this.name = name;
        }
        public Weapon()
        { }
    }
    public class SMG : Weapon
    {
        public SMG() : base("SMG")
        {
        }
    }
    public class ShotGun : Weapon
    {
        public ShotGun() : base("Shotgun")
        {
        }
    }
    public class Pistol : Weapon
    {

    }
    public class Knife : Weapon
    {
        public Knife() : base("Knife")
        {
        }
    }

    public class RealPerson
    {
        public Weapon weapon;
        public string name;

        public RealPerson()
        {
            weapon = new Knife();
            name = "Bob";
        }
        public RealPerson(string name)
        {
            weapon = new Knife();
            this.name = name;
        }
        public RealPerson(string name, Weapon weapon) : this(name)
        {
            this.weapon = weapon;

        }
        public void EquipNewWeapon(Weapon weapon)
        {
            this.weapon = weapon;
            Console.WriteLine(" Switch to new {0} ", weapon.name);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = new Monster[] { new Boss(), new Goblin(), new Monster(), new Boss(), new Goblin(), new Boss(), new Goblin(), new Goblin(), new Goblin(), new Boss() };

            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i] is Goblin)
                {
                    (monsters[i] as Goblin).Attack();
                }
                if (monsters[i] is Boss)
                {
                    (monsters[i] as Boss).UseSkill();
                }



            }

            Weapon pistol = new Pistol();
            Weapon smg = new SMG();
            RealPerson realPerson = new RealPerson();
            realPerson.EquipNewWeapon(smg);
            realPerson.EquipNewWeapon(pistol);

        }
    }
}
