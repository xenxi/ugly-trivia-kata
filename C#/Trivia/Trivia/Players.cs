using System.Collections.Generic;

namespace Trivia {
    public class Players {
        public readonly List<string> _players;
        public int _currentPlayer { get; private set; }

        public Players() {
            _players = new List<string>();
            _currentPlayer = 0;
        }

        public int HowManyPlayers => _players.Count;

        public void AddNewPlayer(string playerName) {
            _players.Add(playerName);
        }

        public string GetCurrentPlayer() {
            return _players[_currentPlayer];
        }

        public void NextPlayer() {
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
        }
    }
}