using System;
using System.Text.RegularExpressions;

namespace RegularExpression {
    class Program {
        static void Main(string[] args) {
            const string regx = "a(b|cd)*e";
            var txt = new [] {"abe", "abbe", "acde", "acdcde", "ab", "acd", "abcde", "FailThis"};
            var nfa = new NFA(regx);

            foreach (var t in txt) {
                Console.WriteLine(nfa.Recognizes(t)
                    ? t + " - matches the patteren"
                    : t + " - dosen't match the patteren");
            }
        }
    }
}