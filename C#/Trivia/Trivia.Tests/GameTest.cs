using System.Linq;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        [Fact]
        public void Test1() {
            GameRunner.Main(Enumerable.Empty<string>().ToArray());

            Assert.True(false);
        }
    }
}