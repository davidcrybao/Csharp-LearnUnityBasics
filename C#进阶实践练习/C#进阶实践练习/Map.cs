﻿using System;
using System.Collections.Generic;

namespace C_进阶实践练习
{
    internal class Map : IDraw
    {
        public List<DrawObject> walls = new List<DrawObject>();
        public List<DrawObject> dynamicWalls = new List<DrawObject>();
        private int score = 0;
        public Dictionary<int, int> perCubes = new Dictionary<int, int>();
        private int maxNumber = GameManager.width / 2 - 2;
        private GameScene nowGameScene;

        public Map(GameScene gameScene)
        {
            nowGameScene = gameScene;
            for (int i = 0; i < GameManager.height - 2; i++)
            {
                walls.Add(new DrawObject(0, i, E_CubeTypes.Wall));
                walls.Add(new DrawObject(GameManager.width - 2, i, E_CubeTypes.Wall));
            }
            for (int i = 0; i < GameManager.width; i += 2)
            {
                walls.Add(new DrawObject(i, GameManager.height - 3, E_CubeTypes.Wall));
            }
        }

        public void Draw()
        {
            foreach (var wall in walls)
            {
                wall.Draw();
            }

            foreach (var dynamicWall in dynamicWalls)
            {
                dynamicWall.Draw();
            }
        }

        public void ClearDraw()
        {
            foreach (var dynamicWall in dynamicWalls)
            {
                dynamicWall.Clear();
            }
        }

        public void Add(List<DrawObject> drawObject)
        {
            ClearDraw();

            foreach (var obj in drawObject)
            {
                obj.ChangeType(E_CubeTypes.Wall);
                dynamicWalls.Add(obj);

                if (obj.position.y <= 0)
                {
                    GameManager.SwitchScene(Game_State.end);
                    nowGameScene.StopThread();
                    break;
                }
                else if (perCubes.ContainsKey(obj.position.y))
                {
                    perCubes[obj.position.y]++;
                }
                else
                {
                    perCubes[obj.position.y] = 1;
                }
            }

            List<int> linesToRemove = CheckAllLines();
            if (linesToRemove.Count>0)
            {
                foreach (var lineIndex in linesToRemove)
                {
                    ClearDynamicWall(lineIndex);
                }
            }

            Draw();
        }

        public List<int> CheckAllLines()
        {
            List<int> linesToRemove = new List<int>();
            foreach (var valuePair in perCubes)
            {
                if (valuePair.Value == maxNumber)
                {
                    linesToRemove.Add(valuePair.Key);
                }
            }
            return linesToRemove;
        }

        public void ClearDynamicWall(int lineIndex)
        {
            // 使用倒序遍历来避免移除元素导致的问题
            for (int i = dynamicWalls.Count - 1; i >= 0; i--)
            {
                dynamicWalls[i].Clear();
                if (dynamicWalls[i].position.y == lineIndex)
                {
                    dynamicWalls.RemoveAt(i);
                }
                else if (dynamicWalls[i].position.y < lineIndex)
                {
                    dynamicWalls[i].position.y++;
                }
            }

            // 更新 perCubes 字典
            var updatedPerCubes = new Dictionary<int, int>();
            foreach (var kvp in perCubes)
            {
                if (kvp.Key == lineIndex)
                {
                    continue;
                }
                var newKey = kvp.Key < lineIndex ? kvp.Key + 1 : kvp.Key;
                if (updatedPerCubes.ContainsKey(newKey))
                {
                    updatedPerCubes[newKey] += kvp.Value;
                }
                else
                {
                    updatedPerCubes[newKey] = kvp.Value;
                }
            }
            perCubes = updatedPerCubes;


            // 更新分数
            Console.SetCursorPosition(0, GameManager.height - 2);
            score += 5;
            Console.Write("                          ", score);
            Console.SetCursorPosition(0, GameManager.height - 2);
            Console.Write("当前分数为{0}", score);
        }
    }
}
