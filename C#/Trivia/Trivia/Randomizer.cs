using System;

namespace Trivia {
    public class Randomizer {
        public bool RandomResponse() {
            var random = new Random();
            var randomResponse = random.Next(9) == 7;
            return randomResponse;
        }

        public int RandomRoll() {
            var random = new Random();
            var randomRoll = random.Next(5) + 1;
            return randomRoll;
        }
    }
}