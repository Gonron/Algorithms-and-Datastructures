public class WeightedUnion implements UnionFind {
    private int count;
    private int[] pointSets;
    private int[] sizeOfTree;

    public WeightedUnion(int count) {
        this.count = count;
        this.pointSets = new int[count];
        this.sizeOfTree = new int[count];
        for (int i = 0; i < count; i++) {
            pointSets[i] = i;
        }
    }


    @Override
    public void union(int p, int q) {
        int pRoot = find(p);
        int qRoot = find(q);
        if (pRoot == qRoot) {
            return;
        }

        if (sizeOfTree[pRoot] < sizeOfTree[qRoot]) {
            pointSets[pRoot] = qRoot;
            sizeOfTree[qRoot] += sizeOfTree[pRoot];
        } else {
            pointSets[qRoot] = pRoot;
            sizeOfTree[pRoot] += sizeOfTree[qRoot];
        }
        count--;
    }

    @Override
    public int find(int p) {
        while (p != pointSets[p]) {
            p = pointSets[p];
        }
        return p;
    }

    @Override
    public boolean connected(int p, int q) {
        return find(p) == find(q);
    }

    @Override
    public int count() {
        return count;
    }
}
