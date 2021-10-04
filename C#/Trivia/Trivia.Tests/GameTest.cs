using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Trivia.Tests
{
    public class GameTest {
        
        [Fact]
        public void Test1() {
            var printerMock = new PrinterMock();
            var game = new GameRunner(printerMock);
            game.PlayGame();

            var output = printerMock.GetOutput();

            Assert.Equal(expectedOutput, output);
        }

        private const string expectedOutput =
            @"Chet was added\r\nThey are player number 1\r\nPat was added\r\nThey are player number 2\r\nSue was added\r\nThey are player number 3\r\nChet is the current player\r\nThey have rolled a 4\r\nChet's new location is 4\r\nThe category is Pop\r\nPop Question 0\r\nAnswer was corrent!!!!\r\nChet now has 1 Gold Coins.\r\nPat is the current player\r\nThey have rolled a 1\r\nPat's new location is 1\r\nThe category is Science\r\nScience Question 0\r\nAnswer was corrent!!!!\r\nPat now has 1 Gold Coins.\r\nSue is the current player\r\nThey have rolled a 3\r\nSue's new location is 3\r\nThe category is Rock\r\nRock Question 0\r\nAnswer was corrent!!!!\r\nSue now has 1 Gold Coins.\r\nChet is the current player\r\nThey have rolled a 2\r\nChet's new location is 6\r\nThe category is Sports\r\nSports Question 0\r\nAnswer was corrent!!!!\r\nChet now has 2 Gold Coins.\r\nPat is the current player\r\nThey have rolled a 4\r\nPat's new location is 5\r\nThe category is Science\r\nScience Question 1\r\nQuestion was incorrectly answered\r\nPat was sent to the penalty box\r\nSue is the current player\r\nThey have rolled a 3\r\nSue's new location is 6\r\nThe category is Sports\r\nSports Question 1\r\nAnswer was corrent!!!!\r\nSue now has 2 Gold Coins.\r\nChet is the current player\r\nThey have rolled a 5\r\nChet's new location is 11\r\nThe category is Rock\r\nRock Question 1\r\nAnswer was corrent!!!!\r\nChet now has 3 Gold Coins.\r\nPat is the current player\r\nThey have rolled a 3\r\nPat is getting out of the penalty box\r\nPat's new location is 8\r\nThe category is Pop\r\nPop Question 1\r\nAnswer was correct!!!!\r\nPat now has 2 Gold Coins.\r\nSue is the current player\r\nThey have rolled a 3\r\nSue's new location is 9\r\nThe category is Science\r\nScience Question 2\r\nAnswer was corrent!!!!\r\nSue now has 3 Gold Coins.\r\nChet is the current player\r\nThey have rolled a 4\r\nChet's new location is 3\r\nThe category is Rock\r\nRock Question 2\r\nAnswer was corrent!!!!\r\nChet now has 4 Gold Coins.\r\nPat is the current player\r\nThey have rolled a 1\r\nPat is getting out of the penalty box\r\nPat's new location is 9\r\nThe category is Science\r\nScience Question 3\r\nAnswer was correct!!!!\r\nPat now has 3 Gold Coins.\r\nSue is the current player\r\nThey have rolled a 2\r\nSue's new location is 11\r\nThe category is Rock\r\nRock Question 3\r\nAnswer was corrent!!!!\r\nSue now has 4 Gold Coins.\r\nChet is the current player\r\nThey have rolled a 1\r\nChet's new location is 4\r\nThe category is Pop\r\nPop Question 2\r\nAnswer was corrent!!!!\r\nChet now has 5 Gold Coins.\r\nPat is the current player\r\nThey have rolled a 5\r\nPat is getting out of the penalty box\r\nPat's new location is 2\r\nThe category is Sports\r\nSports Question 2\r\nAnswer was correct!!!!\r\nPat now has 4 Gold Coins.\r\nSue is the current player\r\nThey have rolled a 3\r\nSue's new location is 2\r\nThe category is Sports\r\nSports Question 3\r\nQuestion was incorrectly answered\r\nSue was sent to the penalty box\r\nChet is the current player\r\nThey have rolled a 2\r\nChet's new location is 6\r\nThe category is Sports\r\nSports Question 4\r\nAnswer was corrent!!!!\r\nChet now has 6 Gold Coins.";
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