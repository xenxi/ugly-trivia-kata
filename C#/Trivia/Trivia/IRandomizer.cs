namespace Trivia {
    public interface IRandomizer {
        bool IsValidResponse();
        int Roll();
    }
}