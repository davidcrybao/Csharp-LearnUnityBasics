using System;

namespace _15_密封类_总练习
{
    public class Vehicle
    {
        public int speed;
        public int maxSpeed;
        public ushort maxPeople;
        public Person[] passengers;
        public Person driver;
        private int currentNumber = 0;

        public Vehicle(int speed, int maxSpeed, ushort maxPeople)
        {
            if (maxPeople < 1)
            {
                throw new ArgumentException("maxPeople must be greater than 0");
            }

            this.speed = speed;
            this.maxSpeed = maxSpeed;
            this.maxPeople = maxPeople;
            driver = new Driver();
            passengers = new Passenger[maxPeople - 1];
        }

        public void GetInCar(Passenger passenger)
        {
            if (currentNumber >= passengers.Length)
            {
                Console.WriteLine("这辆车已经满了!");
                return;
            }

            passengers[currentNumber] = passenger;
            currentNumber++;
            Console.WriteLine("乘客{0}上车了,位置剩余{1},司机是:{2}", passenger.name, maxPeople - currentNumber - 1, driver.name);
        }

        public void GetOffCar(Passenger passenger)
        {
            if (currentNumber <= 0)
            {
                Console.WriteLine("这辆车没人啊,你下什么车?");
                return;
            }
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] == passenger)
                {
                    GetOffCarAtPlace(i);
                    return;
                }
            }
            Console.WriteLine("找不到该乘客");
        }

        public void GetOffCarAtPlace(int place)
        {
            if (place >= currentNumber || currentNumber <= 0)
            {
                Console.WriteLine("当前位置不符合");
                return;
            }
            Console.WriteLine("乘客{0}下车了,位置剩余{1},司机是:{2}", passengers[place].name, maxPeople - currentNumber, driver.name);
            for (int i = place; i < currentNumber - 1; i++)
            {
                passengers[i] = passengers[i + 1];
            }
            passengers[currentNumber - 1] = null;
            currentNumber--;
        }

        public void SpeedUp()
        {
            int addSpeedAmount = maxSpeed / (currentNumber + 1);
            speed += addSpeedAmount;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                Console.WriteLine("目前有{0}位乘客,请不要太快!!,当前速度为{1}", currentNumber + 1, speed);
            }
            else
            {
                Console.WriteLine("目前有{0}位乘客,提速{1},当前速度为{2}", currentNumber + 1, addSpeedAmount, speed);
            }
        }
    }

    public class Person
    {
        public string name;
        public string description;
    }

    public class Driver : Person
    {
        public Driver()
        {
            name = "Tom";
        }
    }

    public class Passenger : Person
    {
        public Passenger(string name)
        {
            this.name = name;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Vehicle vehicle = new Vehicle(5, 150, 8);

            Passenger[] passengers = new Passenger[7]; // Maximum passengers should be 7, as 1 slot is for the driver.
            vehicle.GetOffCar(passengers[1]);
            vehicle.GetOffCarAtPlace(5);
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("编号" + i);
                vehicle.GetInCar(passengers[i]);
                vehicle.SpeedUp();
            }

            vehicle.GetOffCarAtPlace(1);
            vehicle.SpeedUp();
            vehicle.GetOffCarAtPlace(5);
        }
    }
}
