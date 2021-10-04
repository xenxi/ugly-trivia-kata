using System.Linq;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        [Fact]
        public void Test1() {
            var game = new GameRunner();

            game.PlayGame();

            Assert.True(false);
        }
    }
}