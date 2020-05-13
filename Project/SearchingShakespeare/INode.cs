#nullable enable
using System.Collections.Generic;

namespace SearchingShakespeare {
    public interface INode {
        //Add a suffix to the node and its children
        void Add(string text, int start, int end, int value);

        //Find to parent node that contains all results as children
        IChildNode? Locate(string text, string search);

        //Helper method to find all values from children of a node
        void FindResultValues(ICollection<int> values, int maxResultAmount);
    }
}