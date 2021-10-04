using System;

namespace Trivia.Tests {
    public class RandomizerMock : IRandomizer {
        public bool RandomResponse() {
            throw new NotImplementedException();
        }

        public int RandomRoll() {
            throw new NotImplementedException();
        }
    }
}