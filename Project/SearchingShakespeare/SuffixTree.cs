﻿using System;
using System.Collections.Generic;

namespace SearchingShakespeare {
    public class SuffixTree {
        //Original Text is used when getting the searchresults
        public readonly string Text;

        //TextLower is used when building suffixtree to make alphabet less chars
        //and to ignore case when searching.  
        public readonly string TextLower;

        //_root node contains the whole suffixtree
        private readonly Node _root;

        public SuffixTree(string text) {
            Text = text;
            _root = new Node();
            TextLower = text.ToLower();

            //SuffixTree is made:
            var textLength = Text.Length;
            for (var i = 0; i < textLength; i++) {
                _root.Add(TextLower, i, textLength, i);
            }
        }

        //Searches for a given searchstring and returns a list of strings of matches
        public IEnumerable<string> Search(string search, int maxResultAmount = 50) {
            var res = new List<string>(); //Searchresults in strings
            var resValues = new List<int>(); //Searchresults in startindex
            search = search.ToLower();
            const int extraCharAmount = 130; //Extra chars to add to each searchresult

            //Find the parent node which holds all search-results in it's children
            var resNode = _root.Locate(TextLower, search);

            //No search matches
            if (resNode == null) return res;

            //Find all values of the searchmatch
            resNode.FindResultValues(resValues, maxResultAmount);
            resValues.Sort();

            //Convert the match values to substrings
            foreach (var value in resValues) {
                //Sets length of current substring and makes sure no IndexOutOfRangeException is thrown
                var printLength = Math.Min(search.Length + extraCharAmount, Text.Length - value);

                //Adds substring to the result list with given index
                res.Add($"Index: {value}, {Text.Substring(value, printLength)}");
            }

            return res;
        }
    }
}