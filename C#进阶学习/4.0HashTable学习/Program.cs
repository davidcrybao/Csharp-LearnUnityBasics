using System.Collections;

namespace _4._0HashTable学习
{
    public class Monster
    { }

    public class MonsterManager
    {
        private Hashtable hashtable1 = new Hashtable();
        private int index;

        private static MonsterManager instance = new MonsterManager();

        public static MonsterManager Instance
        {
            get { return instance; }
        }

        private MonsterManager()
        {
        }

        public void AddMonster(Monster monster)
        {
            hashtable1.Add(index, monster);
            index++;
        }

        public void RemoveMonster(int id)
        {
            if (hashtable1.ContainsKey(id))
            {
                hashtable1.Remove(id);
            }
        }

        public void Show()
        {
            foreach (DictionaryEntry item in hashtable1)
            {
                Console.WriteLine(item.Key + "" + item.Value);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
        }
    }
}