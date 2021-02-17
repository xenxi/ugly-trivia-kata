using System;

namespace Trivia
{
    public class GameRunnerDelegate
    {
        private static bool _notAWinner;
        private Random rand;

        public GameRunnerDelegate(Random random)
        {
            rand = random;
        }

        public void RunGame()
        {
            var aGame = new Game();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    _notAWinner = aGame.WrongAnswer();
                }
                else
                {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }
}