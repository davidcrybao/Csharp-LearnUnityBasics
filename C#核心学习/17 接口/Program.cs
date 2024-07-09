using System.Reflection.Metadata.Ecma335;

namespace _17_接口
{
    public interface IRegister
    {
        public void Register();
    }
    public class People : IRegister
    {
        public void Register()
        {
            Console.WriteLine(" 将在派出所登记");
        }
    }

    public class Car : IRegister
    {
        public void Register()
        {
            Console.WriteLine(" CAR将在派出所登记");
        }
    }

    public interface IFlyable
    { }
    public interface ISwimmable
    { }

    public interface IWalkable
    {

    }
    public class Helicopter : IFlyable
    { }
    public class Parrot : IFlyable, IWalkable
    { }
    public class Penguin : IWalkable, ISwimmable
    { }
    public class Camelus : IWalkable
    { }
    public class Swan : ISwimmable, IWalkable
    { }

    public interface IPlayable
    {
        void Play();
    }
    public interface IStorage { }
    public interface ITransfer
    {
        public int GetDataSize { get; set; }
        void StartTransfer();
    }

    public class USBStorage : IStorage, ITransfer
    {
        private int data;

        public USBStorage(int data)
        {
            this.data = data;
        }

        public int GetDataSize
        {
            get { return data; }
            set { }
        }

        public void StartTransfer()
        {
            if (data <= 0)
            {
                Console.WriteLine("没有任何数据可以i传输", data);
                return;

            }
            Console.WriteLine("开始传输数据,{0}的数据即将转移到电脑上", data);
            data = 0;
        }
    }
    public class MP3 : ITransfer, IPlayable
    {
        private int data;

        public MP3(int data)
        {
            this.data = data;
        }

        public int GetDataSize
        {
            get { return data; }
            set { }
        }

        public void StartTransfer()
        {
            if (data <= 0)
            {
                Console.WriteLine("没有任何数据可以i传输", data);
                return;

            }
            Console.WriteLine("开始传输数据,{0}的数据即将转移到电脑上", data);
            data = 0;
        }
        public void Play()
        {
            if (data <= 0)
            {
                Console.WriteLine("硬盘是空的啊,你播放什么?");
                return;
            }
            Console.WriteLine("Playing music now ");
        }


    }
    public class MobileDisk : IStorage, ITransfer
    {
        public int GetDataSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void StartTransfer()
        {
            throw new NotImplementedException();
        }
    }

    public class Computer
    {
        public int data;
        public void PlayMusic(IPlayable playableDevices)
        {
            playableDevices.Play();
        }
        public void TransferData(ITransfer transferDevices)
        {
            data = transferDevices.GetDataSize;
            transferDevices.StartTransfer();

        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            MP3 mP3 = new MP3(5);
            computer.PlayMusic(mP3);
            computer.TransferData(mP3);
            computer.PlayMusic(mP3);
            Console.WriteLine("目前电脑的数据文件{0}", computer.data);
        }
    }
}
