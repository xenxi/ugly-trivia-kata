﻿using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool _notAWinner;
        private static readonly GameRunner _instance;
        private readonly IPrinter _printer;
        private readonly Randomizer _randomizer;

        static GameRunner() {
            _instance = new GameRunner(new Printer());
        }

        public GameRunner(IPrinter printer) {
            _printer = printer;
            _randomizer = new Randomizer(new Random());
        }

        public static void Main(string[] args) {
            _instance.PlayGame();
        }

        public void PlayGame() {
            var aGame = new Game(_printer);

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            do {
                var randomRoll = _randomizer.RandomRoll();
                aGame.Roll(randomRoll);

                var randomResponse = _randomizer.RandomResponse();
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