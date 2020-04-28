using System;
using System.Text.RegularExpressions;

namespace RegularExpression {
    class Program {
        static void Main(string[] args) {
            const string regx = "a(b|cd)*e";
            var nfa = new NFA(regx);
            
            Console.WriteLine(nfa.Recognizes("ace"));
        }
    }
}