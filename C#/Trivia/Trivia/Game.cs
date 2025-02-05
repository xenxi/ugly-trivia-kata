﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia {
    public class Game {
        private readonly int[] _places = new int[6];
        private readonly int[] _purses = new int[6];

       

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();


        private bool _isGettingOutOfPenaltyBox;
        private readonly IPrinter _printer;
        private readonly Players _players;

        public Game(IPrinter printer) {
            for (var i = 0; i < 50; i++) {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }

            _printer = printer;
            _players = new Players();
        }

        public string CreateRockQuestion(int index) {
            return "Rock Question " + index;
        }

        public bool Add(string playerName) {
            _players.AddNewPlayer(playerName);
            _places[_players.HowManyPlayers] = 0;
            _purses[_players.HowManyPlayers] = 0;
            

            _printer.Print(playerName + " was added");
            _printer.Print("They are player number " + _players.HowManyPlayers);
            return true;
        }

        public void Roll(int roll) {
            var currentPlayer = _players.GetCurrentPlayer();
            _printer.Print(currentPlayer.Name + " is the current player");
            _printer.Print("They have rolled a " + roll);

            if (currentPlayer.IsInPenaltyBox()) {
                if (!CanGoOutFromPenaltyBox(roll)) {
                    _printer.Print(currentPlayer.Name + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                    return;
                }

                _isGettingOutOfPenaltyBox = true;

                _printer.Print(currentPlayer.Name + " is getting out of the penalty box");
            }

            MoveNewPlace(roll);
            AskQuestion();
        }

        private void MoveNewPlace(int roll) {
            _places[_players._currentPlayer] = _places[_players._currentPlayer] + roll;
            if (_places[_players._currentPlayer] > 11)
                _places[_players._currentPlayer] = _places[_players._currentPlayer] - 12;

            _printer.Print(_players.Players1[_players._currentPlayer]
                           + "'s new location is "
                           + _places[_players._currentPlayer]);
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
            if (_places[_players._currentPlayer] == 0) return "Pop";
            if (_places[_players._currentPlayer] == 4) return "Pop";
            if (_places[_players._currentPlayer] == 8) return "Pop";
            if (_places[_players._currentPlayer] == 1) return "Science";
            if (_places[_players._currentPlayer] == 5) return "Science";
            if (_places[_players._currentPlayer] == 9) return "Science";
            if (_places[_players._currentPlayer] == 2) return "Sports";
            if (_places[_players._currentPlayer] == 6) return "Sports";
            if (_places[_players._currentPlayer] == 10) return "Sports";
            return "Rock";
        }

        public bool WasCorrectlyAnswered() {
            if (_players.GetCurrentPlayer().IsInPenaltyBox()) {
                if (!_isGettingOutOfPenaltyBox) {
                    _players.NextPlayer();
                    return true;
                }

                _printer.Print("Answer was correct!!!!");
            }
            else
                _printer.Print("Answer was corrent!!!!");

            return IncreasePursesAndChangePlayer();
        }

        private bool IncreasePursesAndChangePlayer() {
            _purses[_players._currentPlayer]++;
            _printer.Print(_players.Players1[_players._currentPlayer]
                           + " now has "
                           + _purses[_players._currentPlayer]
                           + " Gold Coins.");

            var winner = DidPlayerWin();
            _players.NextPlayer();

            return winner;
        }

        public bool WrongAnswer() {
            var currentPlayer = _players.GetCurrentPlayer();
            _printer.Print("Question was incorrectly answered");
            _printer.Print(currentPlayer.Name + " was sent to the penalty box");
            currentPlayer.EnterInPenaltyBox(true);

            _players.NextPlayer();
            return true;
        }


        private bool DidPlayerWin() {
            return !(_purses[_players._currentPlayer] == 6);
        }
    }
}