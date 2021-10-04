using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia {
    public class Game {
        private readonly List<string> _players = new List<string>();

        private readonly int[] _places = new int[6];
        private readonly int[] _purses = new int[6];

        private readonly bool[] _inPenaltyBox = new bool[6];

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private int _currentPlayer;
        private bool _isGettingOutOfPenaltyBox;
        private readonly IPrinter _printer;

        private bool CurrentPlayerIsInPenaltyBox {
            get => _inPenaltyBox[_currentPlayer];
            set => _inPenaltyBox[_currentPlayer] = value;
        }

        public Game(IPrinter printer) {
            for (var i = 0; i < 50; i++) {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }

            _printer = printer;
        }

        public string CreateRockQuestion(int index) {
            return "Rock Question " + index;
        }

        public bool Add(string playerName) {
            _players.Add(playerName);
            _places[HowManyPlayers()] = 0;
            _purses[HowManyPlayers()] = 0;
            _inPenaltyBox[HowManyPlayers()] = false;

            _printer.Print(playerName + " was added");
            _printer.Print("They are player number " + _players.Count);
            return true;
        }

        public int HowManyPlayers() {
            return _players.Count;
        }

        public void Roll(int roll) {
            _printer.Print(_players[_currentPlayer] + " is the current player");
            _printer.Print("They have rolled a " + roll);

            if (CurrentPlayerIsInPenaltyBox) {
                if (!CanGoOutFromPenaltyBox(roll)) {
                    _printer.Print(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
                else {
                    _isGettingOutOfPenaltyBox = true;

                    _printer.Print(_players[_currentPlayer] + " is getting out of the penalty box");

                    MoveNewPlace(roll);
                    AskQuestion();
                }
            }
            else {
                MoveNewPlace(roll);
                AskQuestion();
            }
        }

        private void MoveNewPlace(int roll) {
            _places[_currentPlayer] = _places[_currentPlayer] + roll;
            if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

            _printer.Print(_players[_currentPlayer]
                           + "'s new location is "
                           + _places[_currentPlayer]);
            _printer.Print("The category is " + CurrentCategory());
        }

        private static bool CanGoOutFromPenaltyBox(int roll) {
            return roll % 2 != 0;
        }

        private void AskQuestion() {
            if (CurrentCategory() == "Pop") {
                _printer.Print(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }

            if (CurrentCategory() == "Science") {
                _printer.Print(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }

            if (CurrentCategory() == "Sports") {
                _printer.Print(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }

            if (CurrentCategory() == "Rock") {
                _printer.Print(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory() {
            if (_places[_currentPlayer] == 0) return "Pop";
            if (_places[_currentPlayer] == 4) return "Pop";
            if (_places[_currentPlayer] == 8) return "Pop";
            if (_places[_currentPlayer] == 1) return "Science";
            if (_places[_currentPlayer] == 5) return "Science";
            if (_places[_currentPlayer] == 9) return "Science";
            if (_places[_currentPlayer] == 2) return "Sports";
            if (_places[_currentPlayer] == 6) return "Sports";
            if (_places[_currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered() {
            if (CurrentPlayerIsInPenaltyBox) {
                if (!_isGettingOutOfPenaltyBox) {
                    _currentPlayer++;
                    if (_currentPlayer == _players.Count) _currentPlayer = 0;
                    return true;
                }

                _printer.Print("Answer was correct!!!!");
                return IncreasePursesAndChangePlayer();
            }

            _printer.Print("Answer was corrent!!!!");
            return IncreasePursesAndChangePlayer();
        }

        private bool IncreasePursesAndChangePlayer() {
            _purses[_currentPlayer]++;
            _printer.Print(_players[_currentPlayer]
                           + " now has "
                           + _purses[_currentPlayer]
                           + " Gold Coins.");

            var winner = DidPlayerWin();
            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;

            return winner;
        }

        public bool WrongAnswer() {
            _printer.Print("Question was incorrectly answered");
            _printer.Print(_players[_currentPlayer] + " was sent to the penalty box");
            CurrentPlayerIsInPenaltyBox = true;

            _currentPlayer++;
            if (_currentPlayer == _players.Count) _currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin() {
            return !(_purses[_currentPlayer] == 6);
        }
    }
}