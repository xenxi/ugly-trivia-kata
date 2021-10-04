﻿using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;
        private static readonly GameRunner _instance;
        private readonly IPrinter _printer;

        static GameRunner() {
            _instance = new GameRunner(new Printer());
        }

        public GameRunner(IPrinter printer) {
            _printer = printer;
        }

        public static void Main(string[] args) {
            _instance.PlayGame();
        }

        public void PlayGame() {
            var aGame = new Game(_printer);

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            var rand = new Random();

            do {
                var randomRoll = Randomizer.RandomRoll(rand, new Randomizer());
                aGame.Roll(randomRoll);

                var randomResponse = Randomizer.RandomResponse(rand, new Randomizer());
                if (randomResponse) {
                    _notAWinner = aGame.WrongAnswer();
                }
                else {
                    _notAWinner = aGame.WasCorrectlyAnswered();
                }
            } while (_notAWinner);
        }
    }
}