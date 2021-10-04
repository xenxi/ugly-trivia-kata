using System.Collections.Generic;
using System.Linq;

namespace Trivia {
    public class Players {
        private readonly List<Player> _players;
        public int _currentPlayer { get; private set; }

        public Players() {
            _players = new List<Player>();
            _currentPlayer = 0;
        }

        public int HowManyPlayers => Players1.Count;

        public List<string> Players1 => _players.Select(x => x.Name).ToList();

        public void AddNewPlayer(string playerName) {
            _players.Add(new Player(playerName));
        }

        public Player GetCurrentPlayer() {
            return _players[_currentPlayer];
        }

        public void NextPlayer() {
            _currentPlayer++;
            if (_currentPlayer == Players1.Count) _currentPlayer = 0;
        }

        public void SetCurrentPlayerIsInPenaltyBox(bool value) => GetCurrentPlayer().InPenaltyBox = value;
        public bool GetCurrentPlayerIsInPenaltyBox() =>  GetCurrentPlayer().InPenaltyBox;
    }
}