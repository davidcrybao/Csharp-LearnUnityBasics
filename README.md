# 学习记录,<mark style="background: #BBFABBA6;">代码就是多练</mark>。

- [C#入门个人笔记](#c%E5%85%A5%E9%97%A8%E4%B8%AA%E4%BA%BA%E7%AC%94%E8%AE%B0)
	- [需要重点加强的部分](#%E9%9C%80%E8%A6%81%E9%87%8D%E7%82%B9%E5%8A%A0%E5%BC%BA%E7%9A%84%E9%83%A8%E5%88%86)
	- [这次的代码学习记录以及参考](#%E8%BF%99%E6%AC%A1%E7%9A%84%E4%BB%A3%E7%A0%81%E5%AD%A6%E4%B9%A0%E8%AE%B0%E5%BD%95%E4%BB%A5%E5%8F%8A%E5%8F%82%E8%80%83)
		- [1. 简洁性和可读性](#1-%E7%AE%80%E6%B4%81%E6%80%A7%E5%92%8C%E5%8F%AF%E8%AF%BB%E6%80%A7)
		- [2. 执行效率](#2-%E6%89%A7%E8%A1%8C%E6%95%88%E7%8E%87)
		- [3. 逻辑分离](#3-%E9%80%BB%E8%BE%91%E5%88%86%E7%A6%BB)
		- [4. 使用更好的方法](#4-%E4%BD%BF%E7%94%A8%E6%9B%B4%E5%A5%BD%E7%9A%84%E6%96%B9%E6%B3%95)
- [C#基础学习笔记](#c%E5%9F%BA%E7%A1%80%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0)
	- [值类型与引用类型的区别](#%E5%80%BC%E7%B1%BB%E5%9E%8B%E4%B8%8E%E5%BC%95%E7%94%A8%E7%B1%BB%E5%9E%8B%E7%9A%84%E5%8C%BA%E5%88%AB)
		- [详细解释](#%E8%AF%A6%E7%BB%86%E8%A7%A3%E9%87%8A)
	- [结构体的要点](#%E7%BB%93%E6%9E%84%E4%BD%93%E7%9A%84%E8%A6%81%E7%82%B9)
	- [`ref`和`out`的区别](#ref%E5%92%8Cout%E7%9A%84%E5%8C%BA%E5%88%AB)
		- [`ref`和`out`的使用示例](#ref%E5%92%8Cout%E7%9A%84%E4%BD%BF%E7%94%A8%E7%A4%BA%E4%BE%8B)
	- [递归函数](#%E9%80%92%E5%BD%92%E5%87%BD%E6%95%B0)
		- [示例](#%E7%A4%BA%E4%BE%8B)
		- [执行过程和打印顺序](#%E6%89%A7%E8%A1%8C%E8%BF%87%E7%A8%8B%E5%92%8C%E6%89%93%E5%8D%B0%E9%A1%BA%E5%BA%8F)
		- [递归函数的陷阱与优化](#%E9%80%92%E5%BD%92%E5%87%BD%E6%95%B0%E7%9A%84%E9%99%B7%E9%98%B1%E4%B8%8E%E4%BC%98%E5%8C%96)
	- [函数中的`return`关键字](#%E5%87%BD%E6%95%B0%E4%B8%AD%E7%9A%84return%E5%85%B3%E9%94%AE%E5%AD%97)
	- [常见错误及调试技巧](#%E5%B8%B8%E8%A7%81%E9%94%99%E8%AF%AF%E5%8F%8A%E8%B0%83%E8%AF%95%E6%8A%80%E5%B7%A7)
	- [学习方法](#%E5%AD%A6%E4%B9%A0%E6%96%B9%E6%B3%95)
- [C#基础实践学习笔记](#c%E5%9F%BA%E7%A1%80%E5%AE%9E%E8%B7%B5%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0)
	- [[代码整理优化对比](https://github.com/davidcrybao/Csharp-LearnUnityBasics/commit/657aba93f9df78a9b4f468ade458b69239f015ed)](#%E4%BB%A3%E7%A0%81%E6%95%B4%E7%90%86%E4%BC%98%E5%8C%96%E5%AF%B9%E6%AF%94httpsgithubcomdavidcrybaocsharp-learnunitybasicscommit657aba93f9df78a9b4f468ade458b69239f015ed)
- [C#核心学习笔记](#c%E6%A0%B8%E5%BF%83%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0)
		- [面向对象的三大特性](#%E9%9D%A2%E5%90%91%E5%AF%B9%E8%B1%A1%E7%9A%84%E4%B8%89%E5%A4%A7%E7%89%B9%E6%80%A7)
		- [构造函数的复用](#%E6%9E%84%E9%80%A0%E5%87%BD%E6%95%B0%E7%9A%84%E5%A4%8D%E7%94%A8)
		- [重点2：成员属性](#%E9%87%8D%E7%82%B92%E6%88%90%E5%91%98%E5%B1%9E%E6%80%A7)
		- [重点3：索引器](#%E9%87%8D%E7%82%B93%E7%B4%A2%E5%BC%95%E5%99%A8)
		- [重点4：扩展方法](#%E9%87%8D%E7%82%B94%E6%89%A9%E5%B1%95%E6%96%B9%E6%B3%95)
		- [重点5：运算符重载](#%E9%87%8D%E7%82%B95%E8%BF%90%E7%AE%97%E7%AC%A6%E9%87%8D%E8%BD%BD)
		- [重点6：里氏替换原则](#%E9%87%8D%E7%82%B96%E9%87%8C%E6%B0%8F%E6%9B%BF%E6%8D%A2%E5%8E%9F%E5%88%99)
		- [重点7：继承中的构造函数](#%E9%87%8D%E7%82%B97%E7%BB%A7%E6%89%BF%E4%B8%AD%E7%9A%84%E6%9E%84%E9%80%A0%E5%87%BD%E6%95%B0)
- [C#核心实践学习笔记](#c%E6%A0%B8%E5%BF%83%E5%AE%9E%E8%B7%B5%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0)
		- [贪吃蛇的移动逻辑:](#%E8%B4%AA%E5%90%83%E8%9B%87%E7%9A%84%E7%A7%BB%E5%8A%A8%E9%80%BB%E8%BE%91)
		- [食物管理问题:](#%E9%A3%9F%E7%89%A9%E7%AE%A1%E7%90%86%E9%97%AE%E9%A2%98)
		- [问题分析与解决方案:](#%E9%97%AE%E9%A2%98%E5%88%86%E6%9E%90%E4%B8%8E%E8%A7%A3%E5%86%B3%E6%96%B9%E6%A1%88)
		- [代码优化建议:](#%E4%BB%A3%E7%A0%81%E4%BC%98%E5%8C%96%E5%BB%BA%E8%AE%AE)
	- [重组后的内容](#%E9%87%8D%E7%BB%84%E5%90%8E%E7%9A%84%E5%86%85%E5%AE%B9)
	- [[代码前后对比参考](https://github.com/davidcrybao/Csharp-LearnUnityBasics/commit/a18c838197e88a70db4f519598632ffb2fac81f1)](#%E4%BB%A3%E7%A0%81%E5%89%8D%E5%90%8E%E5%AF%B9%E6%AF%94%E5%8F%82%E8%80%83httpsgithubcomdavidcrybaocsharp-learnunitybasicscommita18c838197e88a70db4f519598632ffb2fac81f1)
- [C#进阶学习记录](#c%E8%BF%9B%E9%98%B6%E5%AD%A6%E4%B9%A0%E8%AE%B0%E5%BD%95)
	- [学习的主要内容](#%E5%AD%A6%E4%B9%A0%E7%9A%84%E4%B8%BB%E8%A6%81%E5%86%85%E5%AE%B9)
	- [具体内容整理](#%E5%85%B7%E4%BD%93%E5%86%85%E5%AE%B9%E6%95%B4%E7%90%86)
	- [学习建议](#%E5%AD%A6%E4%B9%A0%E5%BB%BA%E8%AE%AE)
- [C#进阶实践思考记录](#c%E8%BF%9B%E9%98%B6%E5%AE%9E%E8%B7%B5%E6%80%9D%E8%80%83%E8%AE%B0%E5%BD%95)
- [重点出错的地方](#%E9%87%8D%E7%82%B9%E5%87%BA%E9%94%99%E7%9A%84%E5%9C%B0%E6%96%B9)
- [关于砖块生成的思考](#%E5%85%B3%E4%BA%8E%E7%A0%96%E5%9D%97%E7%94%9F%E6%88%90%E7%9A%84%E6%80%9D%E8%80%83)
	- [思路一：在使用时生成随机，然后根据随机值取出对应的砖块类](#%E6%80%9D%E8%B7%AF%E4%B8%80%E5%9C%A8%E4%BD%BF%E7%94%A8%E6%97%B6%E7%94%9F%E6%88%90%E9%9A%8F%E6%9C%BA%E7%84%B6%E5%90%8E%E6%A0%B9%E6%8D%AE%E9%9A%8F%E6%9C%BA%E5%80%BC%E5%8F%96%E5%87%BA%E5%AF%B9%E5%BA%94%E7%9A%84%E7%A0%96%E5%9D%97%E7%B1%BB)
	- [思路二：创建一个字典，存储砖块类型和对应类型的砖块信息类](#%E6%80%9D%E8%B7%AF%E4%BA%8C%E5%88%9B%E5%BB%BA%E4%B8%80%E4%B8%AA%E5%AD%97%E5%85%B8%E5%AD%98%E5%82%A8%E7%A0%96%E5%9D%97%E7%B1%BB%E5%9E%8B%E5%92%8C%E5%AF%B9%E5%BA%94%E7%B1%BB%E5%9E%8B%E7%9A%84%E7%A0%96%E5%9D%97%E4%BF%A1%E6%81%AF%E7%B1%BB)
- [旋转俄罗斯方块优化](#%E6%97%8B%E8%BD%AC%E4%BF%84%E7%BD%97%E6%96%AF%E6%96%B9%E5%9D%97%E4%BC%98%E5%8C%96)
	- [方法1: 在 `GameScene` 的 `Rotate` 方法中处理](#%E6%96%B9%E6%B3%951-%E5%9C%A8-gamescene-%E7%9A%84-rotate-%E6%96%B9%E6%B3%95%E4%B8%AD%E5%A4%84%E7%90%86)
	- [方法2: 先 `CanRotate` 判断是否可以旋转](#%E6%96%B9%E6%B3%952-%E5%85%88%C2%A0canrotate%C2%A0%E5%88%A4%E6%96%AD%E6%98%AF%E5%90%A6%E5%8F%AF%E4%BB%A5%E6%97%8B%E8%BD%AC)
- [学习3 移动代码的不同修改逻辑](#%E5%AD%A6%E4%B9%A03-%E7%A7%BB%E5%8A%A8%E4%BB%A3%E7%A0%81%E7%9A%84%E4%B8%8D%E5%90%8C%E4%BF%AE%E6%94%B9%E9%80%BB%E8%BE%91)
	- [1:**以中心方块为基准**，移动中心方块后，其他方块根据中心方块的位置进行调整。](#1%E4%BB%A5%E4%B8%AD%E5%BF%83%E6%96%B9%E5%9D%97%E4%B8%BA%E5%9F%BA%E5%87%86%E7%A7%BB%E5%8A%A8%E4%B8%AD%E5%BF%83%E6%96%B9%E5%9D%97%E5%90%8E%E5%85%B6%E4%BB%96%E6%96%B9%E5%9D%97%E6%A0%B9%E6%8D%AE%E4%B8%AD%E5%BF%83%E6%96%B9%E5%9D%97%E7%9A%84%E4%BD%8D%E7%BD%AE%E8%BF%9B%E8%A1%8C%E8%B0%83%E6%95%B4)
	- [2:**将移动抽象成向量操作**，所有方块都应用相同的移动向量，实现统一移动。](#2%E5%B0%86%E7%A7%BB%E5%8A%A8%E6%8A%BD%E8%B1%A1%E6%88%90%E5%90%91%E9%87%8F%E6%93%8D%E4%BD%9C%E6%89%80%E6%9C%89%E6%96%B9%E5%9D%97%E9%83%BD%E5%BA%94%E7%94%A8%E7%9B%B8%E5%90%8C%E7%9A%84%E7%A7%BB%E5%8A%A8%E5%90%91%E9%87%8F%E5%AE%9E%E7%8E%B0%E7%BB%9F%E4%B8%80%E7%A7%BB%E5%8A%A8)

## C#入门个人笔记
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




## C#基础学习笔记
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




## C#基础实践学习笔记

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

### [代码整理优化对比](https://github.com/davidcrybao/Csharp-LearnUnityBasics/commit/657aba93f9df78a9b4f468ade458b69239f015ed)




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

## C#核心实践学习笔记

**跟之前一样的一个错误**
就是我们需要改变数组的位置
然后也需要改变它的int index这个的值
不能单改变一个
所以说这我们后面在C#进阶学到许多别的知识就可以改善我们这个代码.

#### 贪吃蛇的移动逻辑:

- 蛇的移动可以理解为蛇头首先改变坐标，随后蛇身的每个部分都移动到前一个部分之前的位置。
- 例如，如果蛇由头部和尾部组成，当头部向前移动后，尾部将移动到头部之前的位置。
![image](https://github.com/user-attachments/assets/a8a7a8a8-0271-4260-88dc-ce2c4d93d7e0)
#### 食物管理问题:

- 当前的食物管理系统存在问题，导致生成的食物可能会被错误地处理。具体表现为生成一个真实的和一个假的食物，只有真实的食物被吃掉时蛇才会增长。
- 食物管理的代码中，只比较了蛇头的位置和一个固定食物的位置，而没有遍历所有食物进行比较。

```c
if (snakeBodies[0].position == foodManager.foods[foodManager.currentFoodCount].position)

{

Eat();

}

//判断头的位置和食物的位置是否重合,应该是需要遍历判断食物跟蛇的位置
```
#### 问题分析与解决方案:

1. **数组管理问题**：当食物被吃掉后，应从 `foods` 数组中移除该食物，并确保数组中没有空洞。
2. **`currentFoodCount`更新问题**：吃掉食物后，需要正确减少 `currentFoodCount`，以防止新生成的食物覆盖未被吃掉的食物。

#### 代码优化建议:

- **改进食物碰撞检测逻辑**：应遍历所有食物，检查蛇头与每个食物的位置是否重合，而不是只检查一个。
- **优化食物数组管理**：在食物被吃掉时，应从数组中删除对应食物，并调整数组以填补空位。

### 重组后的内容

在贪吃蛇游戏中，蛇的运动逻辑是：蛇头首先改变其位置，随后每个蛇身部分都移至前一部分之前的位置。例如，如果蛇由头部和尾部组成，头部移动后，尾部将占据头部原来的位置。

当前的食物管理系统存在缺陷，生成的食物有真实和假的之分，只有真实的食物被吃掉才能触发蛇的增长。问题在于食物的碰撞检测代码只比较了蛇头的位置和一个固定的食物位置，而没有遍历所有食物。

为了解决这些问题，我们需要优化食物管理策略。当食物被吃掉后，应从 `foods` 数组中移除该食物，并正确更新 `currentFoodCount`，以确保新生成的食物不会覆盖还未被吃掉的食物。同时，食物碰撞检测的逻辑应改为遍历所有食物，确保蛇头与任何一个食物重合都能被检测到。这样的改进将使游戏逻辑更加健壮且易于维护。

### [代码前后对比参考](https://github.com/davidcrybao/Csharp-LearnUnityBasics/commit/a18c838197e88a70db4f519598632ffb2fac81f1)



## C#进阶学习记录

<mark style="background: #FF5582A6;"> `这里面的知识都是重点,需要反复练习加强学习!`</mark>

### 学习的主要内容

| 类别          | 子类别       | 关键概念及语法说明                                                    |
| ----------- | --------- | ------------------------------------------------------------ |
| **高级数据结构**  | 队列        | 使用Queue类实现，支持先进先出操作。                                         |
|             | 栈         | 使用Stack类实现，支持后进先出操作。                                         |
|             | 链表        | 可使用LinkedList类实现，支持节点式数据管理。                                  |
| **泛型**      | 泛型数据结构    | 例如List<T>、Dictionary<TKey,TValue>，支持类型安全的数据集合操作。             |
|             | 泛型方法      | 允许在方法定义中指定类型参数，如 `public void Print<T>(T toPrint)`。          |
| **集合**      | 集合和数组     | 使用数组（如int[]）或List<T>存储系列数据。                                  |
|             | 字典        | 使用Dictionary<TKey,TValue>存储键值对。                              |
|             | Lambda表达式 | 允许定义简短的匿名函数，如 `(x, y) => x + y`。                             |
|             | 委托        | 定义可调用的方法签名，如 `delegate void MyDelegate(string msg);`。        |
| **反射和特性**   | 反射        | 使用Reflection命名空间访问对象的属性和方法。                                  |
|             | 特性        | 使用Attribute定义方法或类的额外信息，如 `[Obsolete]`。                       |
| **动态特性和异步** | 动态类型      | 使用dynamic关键字允许运行时决定对象操作。                                     |
|             | 异步编程      | 使用async和await关键字实现异步方法，如 `async Task<int> GetNumberAsync()`。 |

### 具体内容整理

|知识点类别|重点内容|详细说明|
|---|---|---|
|简单集合类|List, Dictionary, LinkedList|**List**: 顺序存储和链式存储<br>**Dictionary**: 键值对存储<br>**LinkedList**: 泛型栈和队列|
|泛型|泛型数据结构类, 泛型集合类|**泛型数据结构类**: List<T>, Dictionary<TKey, TValue><br>**泛型集合类**: 泛型的优点与使用|
|多线程|线程的创建与管理, 协变和逆变|**线程创建与管理**: 多线程的基本概念<br>**协变和逆变**: 类型兼容与转换|
|委托和事件|委托的定义与使用, 事件的定义与使用, 匿名函数, Lambda表达式|**委托**: 定义与使用<br>**事件**: 定义与使用<br>**匿名函数**: 使用场景<br>**Lambda表达式**: 语法与应用|
|反射和特性|反射的基本概念, 特性的应用|**反射**: 获取类型信息, 动态调用方法<br>**特性**: 自定义特性与系统特性|
|迭代器|迭代器的定义与使用|**迭代器**: 定义与使用, yield关键字|
|预处理器指令|预处理器指令的作用与使用|**预处理器指令**: #define, #if, #else, #endif等|
|值类型和引用类型|值类型与引用类型的区别, 常用值类型和引用类型|**值类型**: 基本数据类型, 结构体<br>**引用类型**: 类, 接口, 数组, 委托|
|排序进阶|List排序, 自定义排序规则|**List排序**: 使用Sort方法, 自定义比较器|

### 学习建议

1. **实践操作**：通过编写小程序来实践每一个知识点，加深理解。
2. **复习总结**：定期复习已学知识，并总结成笔记。
3. **多做练习题**：通过练习题巩固知识点，尤其是多线程和泛型部分。
4. **结合项目**：尝试将所学知识应用到实际项目中，理解其实际应用场景和效果。

## C#进阶实践思考记录

## 重点出错的地方
加强对引用类型和值类型的理解。在实际的代码过程中，引用类型的使用会影响对象的实际行为，例如在临时列表中修改对象会影响原始列表中的对象。

```
        public bool CanMove(E_MoveDirection moveDirection, Map map)
        {
            List<DrawObject> tempDraws = currentDraws;
            }
```
主要问题可能在于 `DrawObject` 引用类型的处理上。当您把 `currentDraws[i]` 添加到 `tempDraws` 列表中时，您实际上只是复制了对 `DrawObject` 的引用而不是对象本身。因此，当您修改 `tempDraws` 中的 `DrawObject` 对象时，同样的修改也会反映在 `currentDraws` 中，因为它们都指向同一个对象。

## 关于砖块生成的思考

### 思路一：在使用时生成随机，然后根据随机值取出对应的砖块类


这种方法的优点在于简单直接，通过随机值可以快速获取所需的砖块类。但是，如果砖块类型较多，可能会导致代码维护困难。

```csharp
		public Wall[] walls;
        public int currentWallIndex = 0;
        public Wall[] dynamicWalls;
        public int dynWallNumber = 0;
```

### 思路二：创建一个字典，存储砖块类型和对应类型的砖块信息类


这种方法更为灵活，可以通过字典快速查找对应的砖块信息类，便于维护和扩展。以下是代码示例：

```csharp
Dictionary<int, BrickInfo> brickDict = new Dictionary<int, BrickInfo>();
// 初始化字典
brickDict.Add(0, new BrickInfo(...));
brickDict.Add(1, new BrickInfo(...));
```
List.Add(新的砖块);
## 旋转俄罗斯方块优化

### 方法1: 在 `GameScene` 的 `Rotate` 方法中处理

在 `GameScene` 中使用 `Rotate` 方法处理旋转：

- 获取旋转后的坐标。
- 调用 `CanRotate` 检查是否可以旋转。
- 如果可以旋转，更新视觉效果，否则恢复原来的坐标。

```csharp
 public void Rotate(E_RotateDirection direction, Map map)
 {
     int temp = randomPosition;
     switch (direction)
     {
         case E_RotateDirection.ClockWise:
             randomPosition = randomPosition++ < position.Length ? randomPosition++ : 0;
             break;

         case E_RotateDirection.CounterClockWise:
             randomPosition = randomPosition-- > 0 ? randomPosition-- : position.Length - 1;
             break;
     }
     position = currentTetrisInfo[randomPosition];

     if (CanRotate(map))
     {
         SyncPosition();
     }
     else
     {
         randomPosition = temp;
         position = currentTetrisInfo[temp];
     }
 }
```
### 方法2: 先 `CanRotate` 判断是否可以旋转

先判断是否可以旋转：

- 在 `CanRotate` 方法中传递地图和旋转方向。
- 检查旋转后的坐标是否与地图墙壁碰撞。

```csharp
        public bool CanRotate(E_RotateDirection direction, Map map)
        {
            int temp = randomPosition;
            switch (direction)
            {
                case E_RotateDirection.ClockWise:
                    randomPosition = randomPosition++ < position.Length ? randomPosition++ : 0;
                    break;
                case E_RotateDirection.CounterClockWise:
                    randomPosition = randomPosition-- > 0 ? randomPosition-- : position.Length - 1;
                    break;
            }
            position = currentTetrisInfo[randomPosition];


            Position offsetPosition;
            //墙壁是固定的,是不是只要判断X和Y就可以了,X与Y有没有超出我们的边界, 
            for (int i = 0; i < currentDraws.Count; i++)
            {
                offsetPosition = originObject.position + currentDraws[i].position;
                if (offsetPosition.x <= 0 || offsetPosition.x >= 
                GameManager.width||offsetPosition.y >= GameManager.height - 3 - 2)
                {
                    return false;
                }
            }

            //如果是和动态的墙壁重合,贼添加进这里面,判断是否要消除这一行,然后生成新的砖块
            //然后在判断是否和动态的墙壁位置重合
            for (int i = 0; i < map.dynamicWalls.Count; i++)
            {
                for (int j = 0; j < currentDraws.Count; j++)
                {
                    if (map.dynamicWalls[i].position==currentDraws[j].position)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
```


## 学习3 移动代码的不同修改逻辑

### 1:**以中心方块为基准**，移动中心方块后，其他方块根据中心方块的位置进行调整。


```csharp
    public void Move(E_MoveDirection moveDirection)
    {
        Clear();
        switch (moveDirection)
        {
            case E_MoveDirection.Right:
                currentDraws[0].position.x += 2;
                break;

            case E_MoveDirection.Left:
                currentDraws[0].position.x -= 2;
                break;

            case E_MoveDirection.Down:
                currentDraws[0].position.y++;
                break;
        }
        for (int i = 0; i < position.Length; i++)
        {
            currentDraws[i + 1].position = currentDraws[0].position + position[i];
        }
        Draw();
    }
```
### 2:**将移动抽象成向量操作**，所有方块都应用相同的移动向量，实现统一移动。

```csharp
     public void Move(E_MoveDirection moveDirection)
     {
         Clear();
         Position movePosition = new Position(); ;
         switch (moveDirection)
         {
             case E_MoveDirection.Right:
                 movePosition = new Position(2, 0);
                 break;

             case E_MoveDirection.Left:
                 movePosition = new Position(-2, 0);
                 break;

             case E_MoveDirection.Down:
                 movePosition = new Position(0, 1);
                 break;
         }
         for (int i = 0; i < currentDraws.Count; i++)
         {
             currentDraws[i].position += movePosition;
         }
         Draw();
     }
```
