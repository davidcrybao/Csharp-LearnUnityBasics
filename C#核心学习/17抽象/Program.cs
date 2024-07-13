namespace _17抽象
{
    public abstract class Animal
    {
        public abstract void Talk();

    }
    public class Dog : Animal
    {
        public override void Talk()
        {
            Console.Write("Im a dog");
        }
    }
    public class Cat : Animal
    {
        public override void Talk()
        {
            Console.Write("Im a cat");
        }
    }
    public class People : Animal
    {
        public override void Talk()
        {
            Console.Write("Im a person");
        }
    }

    public abstract class Level
    {
        public abstract void Initialize();
        public abstract void LoadContend();
    }

    public class ForestLevel : Level
    {
        public override void Initialize()
        {
            Console.WriteLine("Forest requires level 15~20, if you are under these level,plese be very careful");
        }

        public override void LoadContend()
        {
            Console.WriteLine("Forest is loading ");
        }
    }

    public class DungeonLevel : Level
    {
        public override void Initialize()
        {
            Console.WriteLine("Dungeon requires level 25~30, if you are under these level,plese be very careful");
        }

        public override void LoadContend()
        {
            Console.WriteLine("Dungeon is loading ");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Level dungeon = new DungeonLevel();
            Level forest = new ForestLevel();
            dungeon.LoadContend();
            dungeon.Initialize();
            forest.LoadContend();
            forest.Initialize();
        }
    }
}
