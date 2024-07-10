namespace C_核心实践项目练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Game.SwitchScene(Game_State.end);
            game.Start();
        }
    }
}
