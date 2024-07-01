using System.Runtime.InteropServices;

namespace Enum2
{
    internal class Program
    {
        enum E_Type
        {
            Monster,
            Player,
            Loser,
        }
        enum E_QQState
        {
            online,
            busy,
            offline,
            callme,
        }
        enum E_Strarbucks
        {
            SuperBig,
            Big,
            Middle,
            Small,

        }
        enum E_Gender
        {
            male,
            female,
        }
        enum E_Profession
        {
            warrior,
            hunter,
            mage,
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            E_Type playerType = E_Type.Player;
            E_QQState e_QQState;
            playerType = (E_Type)Enum.Parse(typeof(E_Type), "Loser");

            Console.WriteLine("请选择QQ的状态,0-在线,1-忙绿,2-不在线,3-联系我");
            int inputState2 = int.Parse(Console.ReadLine());
            e_QQState = (E_QQState)inputState2;
            Console.Write("目前是{0}", e_QQState);


            /*           #region 题目2

                       *//*while (true)
                       {
                           Console.WriteLine("请输入您想要的杯型(0-SuperBig, 1-Big, 2-Middle, 3-Small):");
                           bool hasChoose = false;
                           string inputState = Console.ReadLine();
                           if (int.TryParse(inputState, out int index))
                           {
                               if (Enum.IsDefined(typeof(E_Strarbucks), index))
                               {
                                   E_Strarbucks size = (E_Strarbucks)Enum.ToObject(typeof(E_Strarbucks), index);
                                   switch (size)
                                   {
                                       case E_Strarbucks.SuperBig:
                                           Console.WriteLine("您选择了超大杯,花费了43元");
                                           break;
                                       case E_Strarbucks.Big:
                                           Console.WriteLine("您选择了大杯,花费了40元");
                                           break;
                                       case E_Strarbucks.Middle:
                                           Console.WriteLine("您选择了中杯,花费了35元");
                                           break;
                                       case E_Strarbucks.Small:
                                           Console.WriteLine("您选择了小杯,这是免费送的,地上回收的");
                                           break;
                                   }
                                   hasChoose = true;
                               }
                               else
                               {
                                   Console.WriteLine("输入的不对,请重新输入");
                               }
                           }


                           if (hasChoose)
                           {
                               break;
                           }

                       }*//*

                       Console.WriteLine("请输入数字 (0: SuperBig, 1: Big, 2: Middle, 3: Small):");
                       string input = Console.ReadLine();

                       if (int.TryParse(input, out int index))
                       {
                           if (Enum.IsDefined(typeof(E_Strarbucks), index))
                           {
                               E_Strarbucks size = (E_Strarbucks)index;
                               Console.WriteLine($"你选择的尺寸是: {size}");
                           }
                           else
                           {
                               Console.WriteLine("输入的数字不在有效范围内，请输入0到3之间的数字。");
                           }
                       }
                       else
                       {
                           Console.WriteLine("输入无效，请输入一个数字。");
                       }
                       #endregion
           */

            #region 题目3

            int defence = 0;
            int attack = 0;
            E_Gender e_Gender;
            E_Profession e_Profession;
            Console.Write("当前攻击的{0},防御为{1}", attack, defence);
            Console.WriteLine("请选择你的性别,0-男,1女");
            string inputState = Console.ReadLine();
            if (int.TryParse(inputState, out int secondIndex))
            {
                if (secondIndex == 0)
                {
                    e_Gender = E_Gender.male;
                    attack += 50;
                    defence += 100;
                    Console.WriteLine("你选择了男性,现在攻击力为{0},防御力为{1}", attack, defence);
                }
                else if (secondIndex == 1)
                {
                    e_Gender = E_Gender.female;
                    attack += 150;
                    defence += 20;
                    Console.WriteLine("你选择了女性,现在攻击力为{0},防御力为{1}", attack, defence);
                }

            }
            Dictionary<E_Profession, string> professionSkill = new Dictionary<E_Profession, string>
            {
                { E_Profession.warrior,"冲刺" },
                 { E_Profession.hunter,"假死" },
                  { E_Profession.mage,"奥术冲击" },
            };
            Console.WriteLine("请选择你的职业,0-战士,1-猎人,2-法师");
            inputState = Console.ReadLine();
            if (int.TryParse(inputState, out int Index))
            {
                switch (Index)
                {
                    case 0:
                        e_Profession = E_Profession.warrior;
                        attack += 20;
                        defence += 100;
                        Console.WriteLine("你选择了{0},当前的攻击力为{1},防御力为{2},你现在有技能{3}", e_Profession, attack, defence, professionSkill[e_Profession]);
                        break;
                    case 1:
                        e_Profession = E_Profession.hunter;
                        attack += 120;
                        defence += 30;
                        Console.WriteLine("你选择了{0},当前的攻击力为{1},防御力为{2},你现在有技能{3}", e_Profession, attack, defence, professionSkill[e_Profession]);
                        break;
                    case 2:
                        e_Profession = E_Profession.mage;
                        attack += 200;
                        defence += 10;
                        Console.WriteLine("你选择了{0},当前的攻击力为{1},防御力为{2},你现在有技能{3}", e_Profession, attack, defence, professionSkill[e_Profession]);
                        break;
                }

            }
            #endregion
        }
    }
}
