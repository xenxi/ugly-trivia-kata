using System;

namespace Trivia {
    public class Printer : IPrinter {
        public void Print(string textLine) {
            Console.WriteLine(textLine);
        }
    }
}