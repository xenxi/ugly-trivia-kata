using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Xunit;

namespace Trivia.Tests
{
    [UseReporter(typeof(DiffReporter))]
    public class GameTest
    {
        [Fact]
        public void NewGame()
        {
            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
            Console.SetIn(new StringReader("a\n"));

            new GameRunnerDelegate(new Random(8)).RunGame();

            var output = fakeOutput.ToString();
            Approvals.Verify(output);

        }
    }
}