using System.Collections.Generic;

namespace Trivia {
    public class Players {
        public readonly List<string> _players;
        public Players() {
            _players = new List<string>();
        }

        public int HowManyPlayers => _players.Count;

        public void AddNewPlayer(string playerName) {
            _players.Add(playerName);
        }
    }
}