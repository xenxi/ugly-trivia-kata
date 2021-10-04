namespace Trivia {
    public class Player
    {
        private bool _inPenaltyBox;

        public Player(string Name)
        {
            this.Name = Name;
            _inPenaltyBox = false;
        }

        public string Name { get; }

        public void EnterInPenaltyBox(bool value) {
            _inPenaltyBox = value;
        }

        public bool IsInPenaltyBox() {
            return _inPenaltyBox;
        }
    }
}