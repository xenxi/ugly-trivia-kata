using System;

namespace Trivia
{
    public class GameRunner
    {
        public static void Main(string[] args)
        {
            new GameRunnerDelegate(new Random()).RunGame();
        }
    }
}