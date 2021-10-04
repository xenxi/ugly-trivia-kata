using System.Collections.Generic;

namespace Trivia {
    public class Players {
        public readonly List<string> _players;
        public int _currentPlayer { get; private set; }
        private readonly bool[] _inPenaltyBox = new bool[6];
        public Players() {
            _players = new List<string>();
            _currentPlayer = 0;
        }

        public int HowManyPlayers => _players.Count;

        public void AddNewPlayer(string playerName) {
            _players.Add(playerName);
            _inPenaltyBox[_players.Count] = false;
        }

        public string GetCurrentPlayer() {
            return _players[_currentPlayer];
        }

        public void NextPlayer() {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }

        public void SetCurrentPlayerIsInPenaltyBox(bool value) => _inPenaltyBox[_currentPlayer] = value;
        public bool GetCurrentPlayerIsInPenaltyBox() => _inPenaltyBox[_currentPlayer];
    }
}