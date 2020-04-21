namespace SearchingShakespeare {
    public interface IChildNode : INode {
        //To be able to get start on both LinkedNode and KeyNode
        int Start { get; }
    }
}