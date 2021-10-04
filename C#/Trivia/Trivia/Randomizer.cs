using System;

namespace Trivia {
    public class Randomizer {
        public static bool RandomResponse(Random rand, Randomizer randomizer) {
            var randomResponse = rand.Next(9) == 7;
            return randomResponse;
        }

        public static int RandomRoll(Random rand, Randomizer randomizer) {
            var randomRoll = rand.Next(5) + 1;
            return randomRoll;
        }
    }
}