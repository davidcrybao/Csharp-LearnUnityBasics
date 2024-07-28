# 学习记录,<mark style="background: #BBFABBA6;">代码就是多练</mark>。
# C#入门个人笔记
### 需要重点加强的部分

1. **变量的本质**：理解变量的字节和它代表的位数。
    
2. **运算符**：
    
    - **自增运算符**：`a++`和`++a`的区别：
        - `a++`：先使用，再加1。
        - `++a`：先加1，再使用。
3. **三元操作符（三目操作符）**：需要重点掌握。
    
4. **逻辑运算**：
    
    - **逻辑优先级顺序**：要记住逻辑非（`!`）的优先级最高，其次是逻辑与（`&&`），最后是逻辑或（`||`）。
5. **交错数组**：理解为行和列的二维数组。
    
6. **游戏循环**：
    
    - **while循环**：在制作游戏时，画面刷新和操作通常在一个`while`循环中执行。

### 这次的代码学习记录以及参考
  ![2024728-93321](https://github.com/user-attachments/assets/89d2eaea-2e88-4b31-89c7-62e484ff5f90)
![image](https://github.com/user-attachments/assets/30a140e8-14a2-428a-a314-23b69f657fb4)
#### 1. 简洁性和可读性

**原因**：最初的代码结构复杂，嵌套的`for`循环和多重`if-else`条件使得代码难以阅读和理解。 
**好处**：优化后的代码简洁明了，逻辑清晰，便于维护和调试。

#### 2. 执行效率

**原因**：初始代码中有不必要的循环和条件判断，增加了执行时间。 
**好处**：优化后的代码减少了循环次数和条件判断，提高了执行效率。

#### 3. 逻辑分离

**原因**：初始代码将墙壁的绘制逻辑混在一个大的循环中，不易修改和扩展。 
**好处**：优化后的代码将墙壁的绘制逻辑分离，分别处理水平和垂直的墙壁，便于未来修改和扩展。

#### 4. 使用更好的方法

**原因**：初始代码使用了一个多余的`Console.WriteLine`来控制换行，不够高效。 
**好处**：优化后的代码利用`Console.SetCursorPosition`准确定位，不需要额外的换行操作，更加高效。

[C#实践项目学习文档](https://github.com/davidcrybao/Csharp-LearnUnityBasics/blob/master/C%23%E5%AE%9E%E8%B7%B5%E9%A1%B9%E7%9B%AE%E6%80%9D%E8%80%83.md)

# C#基础学习笔记
### 值类型与引用类型的区别

|特性|值类型|引用类型|
|---|---|---|
|存储数据|直接存储值|存储值的引用（地址）|
|内存分配|栈（Stack）|堆（Heap）|
|复制|创建新的副本|复制引用，指向同一个内存地址|
|速度|访问速度快|访问速度相对较慢|
|空间|栈空间有限|堆空间较大|

#### 详细解释

1. **存储位置**：
    
    - **值类型**：存储在堆栈（Stack）上。
    - **引用类型**：存储在堆（Heap）上，堆栈上存储的是对象的引用。
2. **默认值**：
    
    - **值类型**：具有默认值（例如，`int`的默认值是0）。
    - **引用类型**：默认值为`null`。
3. **复制方式**：
    
    - **值类型**：直接复制值。
    - **引用类型**：复制引用，指向同一个对象。

### 结构体的要点

1. **构造函数**：
    
    - 结构体可以有构造函数，但必须初始化所有字段。
2. **不可变性**：
    
    - 结构体通常用于不可变的数据。可以通过只读属性实现。
3. **使用场景**：
    
    - 适用于小数据对象，避免频繁的堆分配和垃圾回收。
4. **变量初始化**：
    
    - 在结构体中声明的变量不能初始化，只能在外部或者函数中赋值。
5. **函数声明**：
    
    - 在结构体中声明的函数不需要加 `static`。

### `ref`和`out`的区别

1. **`ref`**：
    
    - 传入的变量必须初始化。
    - 传入的变量可以在函数内部修改。
2. **`out`**：
    
    - 传入的变量不需要初始化。
    - 传入的变量必须在函数内部赋值。

#### `ref`和`out`的使用示例

```csharp
// ref 示例
void ExampleRef(ref int x)
{
    x = x + 10;
}

int number = 5;
ExampleRef(ref number); // number 现在是 15

// out 示例
void ExampleOut(out int x)
{
    x = 10; // 必须在函数内部赋值
}

int result;
ExampleOut(out result); // result 现在是 10

```
### 递归函数

#### 示例

```c
static void WriteNumbers(int n)
{
    if (n <= 0)
    {
        Console.Write(n + " ");
        return;
    }
    else
    {
        WriteNumbers(n - 1);
        Console.Write(n + " ");
    }
}

```
#### 执行过程和打印顺序

1. `WriteNumbers(5)` 调用 `WriteNumbers(4)`，然后等待 `WriteNumbers(4)` 的执行结果。
2. `WriteNumbers(4)` 调用 `WriteNumbers(3)`，然后等待 `WriteNumbers(3)` 的执行结果。
3. `WriteNumbers(3)` 调用 `WriteNumbers(2)`，然后等待 `WriteNumbers(2)` 的执行结果。
4. `WriteNumbers(2)` 调用 `WriteNumbers(1)`，然后等待 `WriteNumbers(1)` 的执行结果。
5. `WriteNumbers(1)` 调用 `WriteNumbers(0)`，然后等待 `WriteNumbers(0)` 的执行结果。
6. `WriteNumbers(0)` 满足 `n <= 0` 条件，打印 0，并返回。

#### 递归函数的陷阱与优化

1. **陷阱**：
    
    - 递归深度过深可能导致栈溢出（Stack Overflow）。
    - 基本情况（终止条件）必须明确且容易达到。
2. **优化**：
    
    - 尾递归优化：将递归调用放在函数的最后一个操作中，有些编译器可以优化此类递归。

### 函数中的`return`关键字

- `return`关键字可以结束函数的执行，不管函数是否有返回值。

### 常见错误及调试技巧

1. **常见错误**：
    
    - 未初始化变量。
    - 忘记在`ref`或`out`参数前添加关键字。
    - 递归函数没有明确的终止条件。
2. **调试技巧**：
    
    - 使用断点逐步调试代码，观察变量变化。
    - 打印日志信息，跟踪程序执行过程。

### 学习方法

一边学习理论知识，一边在练习中加强理解和应用。

通过以上的整理与优化，希望能更好地理解这些概念，并在实际编程中加以应用。


# C#基础实践学习笔记



归纳总结:

1. 游戏中引入了位置(Position)结构体来表示位置坐标,替代了之前使用整数 x 和 y 的方式。**这种方式更加结构化和清晰。**
    
2. 使用了枚举(enum)来表示不同的游戏场景和格子类型,如炸弹、暂停等。**相比之前使用整数表示场景和手动判断格子类型的繁琐方式,枚举使代码更加简洁和易于理解。**
    
3. 引入了格子(Grid)结构体,用于存储格子的位置坐标和类型。创建格子时,可以直接指定格子的类型,简化了逻辑。**这避免了使用多个数组分别存储炸弹、暂停等特殊格子坐标的混乱。**
    
4. 玩家移动时,根据移动的方向,更新玩家的位置坐标。**通过位置结构体的坐标相加或相减,可以方便地计算出新的位置。**
    
5. 玩家移动到新格子后,通过判断格子的类型来触发相应的逻辑。**使用 switch 语句对格子类型进行判断,根据不同类型执行相应的操作,使代码更加清晰和易于维护。**
    
6. 格子结构体中包含一个方法,用于根据格子类型绘制不同颜色的格子。**这种方式将格子的绘制逻辑封装在结构体内,使代码更加模块化。**
    

重点:

1. **使用结构体(如位置和格子)来组织数据,提高了代码的可读性和可维护性。**
2. **使用枚举来表示不同的游戏场景和格子类型,使代码更加简洁和易于理解。**
3. **将格子的位置坐标和类型封装在格子结构体中,避免了使用多个数组分别存储特殊格子坐标的混乱。**
4. **根据格子类型触发相应的逻辑,使用 switch 语句进行判断,提高了代码的清晰度。**
![image](https://github.com/user-attachments/assets/5aa5f3e7-35b0-4930-b855-a868847ab388)


```c
public struct Grid
{
    public Position Pos { get; set; }
    public GridType Type { get; set; }

    public Grid(Position pos, GridType type)
    {
        Pos = pos;
        Type = type;
    }

    public void Draw()
    {
        // 根据格子类型绘制不同颜色
        switch (Type)
        {
            case GridType.Normal:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case GridType.Bomb:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case GridType.Pause:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
        Console.SetCursorPosition(Pos.X, Pos.Y);
        Console.Write("■");
    }
}

```

## [最后的代码整理记录](https://github.com/davidcrybao/Csharp-LearnUnityBasics/commit/657aba93f9df78a9b4f468ade458b69239f015ed)
