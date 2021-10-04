using System;

namespace Trivia {
    public class Randomizer {
        private readonly Random _random;

        public Randomizer() {
            _random = new Random();
        }

        public bool RandomResponse() {
            var randomResponse = _random.Next(9) == 7;
            return randomResponse;
        }

        public int RandomRoll() {
            var randomRoll = _random.Next(5) + 1;
            return randomRoll;
        }
    }
}