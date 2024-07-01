namespace 成员方法
{
    public class Person
    {
        public string name;
        public int age;
        public float height;
        public string homeAddress;
        private Food[] foods = new Food[0];
        private int energy = 2;

        public Person(string name, int age, float height, string homeAddress)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.homeAddress = homeAddress;
        }

        public Person()
        { }
        public void Speak()
        {
            if (energy - 1 >= 0)
            {
                Console.WriteLine("你好,我是{0},我今年{1}岁了,{2}米高,家庭地址是{3}", name, age, height, homeAddress);
                energy--;
            }
            else
            {
                Console.WriteLine("你没有能量执行这个操作了");
            }

        }
        public void Walk()
        {
            if (energy - 2 >= 0)
            {
                Console.WriteLine("{0} start walking ", name);
                energy -= 2;
            }
            else
            {
                Console.WriteLine("你没有能量执行这个操作了");
            }

        }

        public void AddFood(params Food[] foodsAdd)
        {
            Food[] tempFoods = new Food[foods.Length + foodsAdd.Length];
            int n = foods.Length;
            for (int i = 0; i < n; i++)
            {
                tempFoods[i] = foods[i];
            }

            for (int i = n; i < n + foodsAdd.Length; i++)
            {
                tempFoods[i] = foodsAdd[i];
            }
            foods = tempFoods;

        }
        public void Eat()
        {
            if (foods.Length == 0)
            {
                Console.WriteLine("{0}你没有任何食物可以吃啊! ", name);
                return;

            }
            else
            {
                Food[] tempFoods = new Food[foods.Length - 1];
                for (int i = 0; i < foods.Length - 1; i++)
                {
                    tempFoods[i] = foods[i + 1];
                }
                energy += foods[0].energyProvide;
                Console.WriteLine("{0}吃了一个{1},恢复了{2}点能量,现在能量为{3} ", name, foods[0].name, foods[0].energyProvide, energy);
                foods = tempFoods;
            }

        }

    }

    public class Student
    {
        public string name;
        public int number;
        public int age;
        public Student[] friends;

        public Student(string name, int number, int age)
        {
            this.name = name;
            this.number = number;
            this.age = age;
            this.friends = new Student[0];

        }

        public void Study()
        {
            Console.WriteLine("{0}开始学习了", name);
        }
        public void AddFriend(Student student)
        {
            Student[] newFriends = new Student[friends.Length + 1];
            if (friends != null)
            {
                for (int i = 0; i < friends.Length; i++)
                {
                    newFriends[i] = friends[i];
                }
            }
            newFriends[newFriends.Length - 1] = student;
            friends = newFriends;
        }

    }

    public class Food
    {
        public string name;
        public int energyProvide;
        public int cost;

        public Food(string name, int energyProvide, int cost)
        {
            this.name = name;
            this.energyProvide = energyProvide;
            this.cost = cost;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Food grape = new Food("Grape", 2, 20);
            Person bob = new Person("Bob", 25, 1.85f, "Tom street,no128");
            bob.Speak();
            bob.Walk();
            bob.Eat();
            bob.AddFood(grape);
            bob.Eat();
            bob.Walk();
            bob.Speak();
            bob.AddFood(grape, grape);
            bob.Eat();
            bob.Eat();
        }
    }
}
