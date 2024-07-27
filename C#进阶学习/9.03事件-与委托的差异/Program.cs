namespace _9._03事件_与委托的差异
{
    public class WaterHeater
    {
        private Heater heater;
        private Alarm alarm;
        private LCDDisplay lCDDisplay;
        private bool opened;

        public event Action<int> temperatureChanged;

        public WaterHeater()
        {
            heater = new Heater();
            alarm = new Alarm();
            lCDDisplay = new LCDDisplay();
            temperatureChanged += lCDDisplay.Display;
            temperatureChanged += alarm.Alarmer;
            opened = false;
        }

        public void OpenOrClose()
        {
            opened = !opened;
        }

        public void Heat()
        {
            if (opened)
            {
                heater.Heat();
                temperatureChanged?.Invoke(heater.CurrentTemperature);
            }
            else
            {
                Console.Write("清闲打开电源          ");
            }
        }
    }

    public class Heater
    {
        private int currentTemperature;

        public int CurrentTemperature
        { get { return currentTemperature; } }

        public Heater()
        {
            currentTemperature = 25;
        }

        public void Heat()
        {
            currentTemperature += 10;
        }
    }

    public class Alarm
    {
        public void Alarmer(int currentTemperture)
        {
            if (currentTemperture >= 90)
            {
                Console.WriteLine("温度要爆了!!,水烧开了");
            }
            else
            {
                Console.WriteLine("正常运转中");
            }
        }
    }

    public class LCDDisplay
    {
        private int temperature;

        public LCDDisplay()
        {
            temperature = 25;
        }

        public void Display(int temperatureChangedAmount)
        {
            temperature = temperatureChangedAmount;
            Console.WriteLine("当前的温度是{0}", temperature);
        }
    }

    internal class Test
    {
        public event Action testEvent;

        public Action action;
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Test test = new Test();
            test.action += Talk;
            test.testEvent += Talk;
            test.action();
            /*          test.testEvent();
                      test.action = null;
                      test.testEvent = null;*/
            WaterHeater waterHeater = new WaterHeater();
            waterHeater.Heat(); waterHeater.Heat(); waterHeater.Heat(); waterHeater.Heat(); waterHeater.Heat(); waterHeater.Heat(); waterHeater.Heat();
        }

        private static void Talk()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}