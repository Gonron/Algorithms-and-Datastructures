using System;
using Shakespeare.Sorting;

namespace Shakespeare {
    class Program {
        static void Main(string[] args) {
            var tp = new TextProcessor();
            var path =
                @"C:\Users\User\Desktop\CPHBusiness\soft\Algorithms-and-Datastructures\csharp\Project\Shakespeare\data\tobe.txt";
            var regex = @"[a-zA-ZæøåÆØÅ]+'?[a-zA-ZæøåÆØÅ]*";
            tp.ProcessTextFile(path, regex);

            Insertion.Sort(tp.ProcessedStrings);
            
        }
    }
}