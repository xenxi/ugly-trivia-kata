using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest
    {
        [Fact]
        public void Test1() {
            var printerMock = new PrinterMock();
            var game = new GameRunner(printerMock);

            game.PlayGame();

            Assert.True(false);
        }
    }

    public class PrinterMock : IPrinter {
        private readonly List<string> _lines;

        public PrinterMock() {
            _lines = new List<string>();
        }

        public void Print(string textLine) {
            _lines.Add(textLine);
        }

        public string GetOutput()
            => string.Join(Environment.NewLine, _lines);
    }
}