namespace Trivia {
    public class Player
    {
        public Player(string Name)
        {
            this.Name = Name;
            InPenaltyBox = false;
        }

        public string Name { get; }
        public bool InPenaltyBox { get; set; }
    }
}