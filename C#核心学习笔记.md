
## C#核心学习笔记
我们已经学习了很多内容，可能会有些混乱。现在需要静下心来，重新调整和整理这些知识。

- **面向对象的三大特性**：
    
    - **封装**：用程序语言来描述和实现对象。
    - **继承**：子类继承父类，复用代码，提高代码重用性。
    - **多态**：不同子类可以有不同的行为实现。
- **构造函数的复用**：通过调用另一个构造函数来简化初始化逻辑，例如`Person`和`Circle`类的实现。
    
- **成员属性**：通过私有变量和公共属性来控制类内部状态和行为，例如`Player`类中的属性和方法。
    
- **索引器**：允许像访问数组一样访问对象的实例，例如`Team`类中的索引器实现。
    
- **扩展方法**：在静态类中定义方法，扩展现有类型的功能，例如`StringExtensions`类中的扩展方法。
    
- **运算符重载**：自定义类和结构体的运算符重载，提高操作的直观性和易用性，例如`Vector`和`Complex`类的运算符重载。
    
- **里氏替换原则**：用父类容器来装子类对象，提高代码的灵活性和扩展性。
    
- **继承中的构造函数**：子类构造函数如何调用父类构造函数，确保对象的正确初始化。

#### 面向对象的三大特性

1. **封装**：用程序语言来描述对象。
2. **继承**：复用封装对象的代码，类似于儿子继承父亲。
3. **多态**：父类有一个行为，子类可以有不同的实现。

#### 构造函数的复用

```c
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public Person(string name, int age) : this(name)
    {
        Age = age;
    }
}

public class Circle
{
    public double Radius { get; set; }
    public string Color { get; set; }

    public Circle(double radius, string color = "Red")
    {
        Radius = radius;
        Color = color;
    }
}
```
#### 重点2：成员属性

- 成员属性通常通过私有变量来实现
- 
```c
public class Player
{
    private string name;
    private int level;
    private int hp;

    public int Exp { get; set; }
    public int AttackPower { get { return level * 10; } }

    public Player(string name)
    {
        this.name = name;
        level = 1;
        hp = 100;
        Exp = 0;
    }

    public void Attack(Player target)
    {
        Console.WriteLine($"{name} 攻击了 {target.name}，造成了 {AttackPower} 点伤害！");
        target.hp -= AttackPower;
    }
}

// 使用示例
Player player1 = new Player("勇士");
Player player2 = new Player("魔法师");

player1.Exp = 100;
Console.WriteLine($"{player1.name} 当前等级：{player1.level}，经验值：{player1.Exp}，攻击力：{player1.AttackPower}");

player1.Attack(player2);
Console.WriteLine($"{player2.name} 剩余生命值：{player2.hp}");

```
#### 重点3：索引器

- 允许像访问数组一样访问对象的实例

```
class Team {
    private Player[] players;

    public Team() {
        players = new Player[11]; // 假设是一个足球队
    }

    public Player this[int index] {
        get { return players[index]; }
        set { players[index] = value; }
    }
}

class Player {
    public string Name { get; set; }
    public Player(string name) {
        Name = name;
    }
}

// 使用示例
Team soccerTeam = new Team();
soccerTeam[0] = new Player("Player 1");
Console.WriteLine(soccerTeam[0].Name); // 输出 "Player 1"

```

#### 重点4：扩展方法

- 必须定义在静态类中
- 
```c
public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }
}

public class Program
{
    public static void Main()
    {
        string testString = "hello world";
        bool isEmpty = testString.IsNullOrEmpty();
        string titleCase = testString.ToTitleCase();

        Console.WriteLine($"Is empty: {isEmpty}");
        Console.WriteLine($"Title case: {titleCase}");
    }
}

```

#### 重点5：运算符重载

- 自定义类和结构体的运算符重载
- 
```c
public struct Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y);
    }
}

public class Complex
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }
}

```
- 运算符重载的基本规则
    - 只能重载已有运算符
    - 必须是静态方法
    - 必须成对重载
    - 不能重载所有运算符

#### 重点6：里氏替换原则

- 用父类容器装子类对象
- 
```c
class Player : GameObject {}
GameObject player = new Player();

```
#### 重点7：继承中的构造函数

- 子类构造函数如何调用父类构造函数
- 
```c
public class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor called.");
    }
}

public class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor called.");
    }
}

Dog dog = new Dog();
// 输出:
// Animal constructor called.
// Dog constructor called.


public class Animal
{
    public Animal(string name)
    {
        Console.WriteLine($"Animal constructor called with name: {name}");
    }
}

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
        Console.WriteLine($"Dog constructor called with name: {name}");
    }
}

Dog dog = new Dog("Buddy");
// 输出:
// Animal constructor called with name: Buddy
// Dog constructor called with name: Buddy

public class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor called.");
    }
}

public class Mammal : Animal
{
    public Mammal()
    {
        Console.WriteLine("Mammal constructor called.");
    }
}

public class Dog : Mammal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor called.");
    }
}

Dog dog = new Dog();
// 输出:
// Animal constructor called.
// Mammal constructor called.
// Dog constructor called.

```