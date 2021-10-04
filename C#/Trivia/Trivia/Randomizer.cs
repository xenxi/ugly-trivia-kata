using System;

namespace Trivia {
    public class Randomizer {
        public bool RandomResponse(Random rand) {
            var randomResponse = rand.Next(9) == 7;
            return randomResponse;
        }

        public int RandomRoll(Random rand) {
            var randomRoll = rand.Next(5) + 1;
            return randomRoll;
        }
    }
}