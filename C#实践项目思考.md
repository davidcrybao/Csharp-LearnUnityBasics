# 目录
- [重点出错的地方](#重点出错的地方)
- [关于砖块生成的思考](#关于砖块生成的思考)
  - [思路一：在使用时生成随机，然后根据随机值取出对应的砖块类](#思路一在使用时生成随机然后根据随机值取出对应的砖块类)
  - [思路二：创建一个字典，存储砖块类型和对应类型的砖块信息类](#思路二创建一个字典存储砖块类型和对应类型的砖块信息类)
- [旋转俄罗斯方块优化](#旋转俄罗斯方块优化)
  - [方法1: 在 GameScene 的 Rotate 方法中处理](#方法1-在-gamescene-的-rotate-方法中处理)
  - [方法2: 先 CanRotate 判断是否可以旋转](#方法2-先-canrotate-判断是否可以旋转)
- [学习3 移动代码的不同修改逻辑](#学习3-移动代码的不同修改逻辑)
  - [1. 以中心方块为基准，移动中心方块后，其他方块根据中心方块的位置进行调整。](#1以中心方块为基准移动中心方块后其他方块根据中心方块的位置进行调整)
  - [2. 将移动抽象成向量操作，所有方块都应用相同的移动向量，实现统一移动。](#2将移动抽象成向量操作所有方块都应用相同的移动向量实现统一移动)


## 重点出错的地方
加强对引用类型和值类型的理解。在实际的代码过程中，引用类型的使用会影响对象的实际行为，例如在临时列表中修改对象会影响原始列表中的对象。
![image](https://github.com/user-attachments/assets/f8986047-2695-4c92-b780-da10877d970b)

```csharp
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

### 方法1: 在 GameScene 的 Rotate 方法中处理

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
### 方法2: 先 CanRotate 判断是否可以旋转

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
