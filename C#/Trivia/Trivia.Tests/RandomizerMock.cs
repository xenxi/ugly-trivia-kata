using System;

namespace Trivia.Tests {
    public class RandomizerMock : IRandomizer {
        private int _responseCount;
        private int _rollCount;

        public RandomizerMock() {
            _responseCount = 0;
            _rollCount = 0;
        }

        public bool IsValidResponse() {
            _responseCount++;
            if (_responseCount != 8) return false;
            _responseCount = 0;
            return true;
        }

        public int Roll() {
            _rollCount++;
            var roll = _rollCount;

            if (_rollCount == 6)
                _rollCount = 0;

            return roll;
        }
    }
}