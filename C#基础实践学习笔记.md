

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