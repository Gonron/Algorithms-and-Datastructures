public class WeightedUnion implements UnionFind {
    private int count;
    private int[] pointSets;
    private int[] sizeOfTree;

    public WeightedUnion(int count) {
        this.count = count;
        this.pointSets = new int[count];
        for (int i = 0; i < count ; i++) {
            pointSets[i] = i;
        }
        this.sizeOfTree = new int[count];
        for (int i = 0; i < count; i++) {
            sizeOfTree[i] = 1;
        }
    }


    @Override
    public void union(int p, int q) {
        int pRoot = find(p);
        int qRoot = find(q);
        if (connected(pRoot, qRoot)) {
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

    @Override
    public String toString() {
        String result = "";
        for (int i = 0; i < pointSets.length; i++) {
            result += pointSets[i] + " ";
        }
        return result;
    }

    public static void main(String[] args) {
        WeightedUnion wu = new WeightedUnion(10);
        System.out.println(wu.toString());

        wu.union(4,3);
        wu.union(3,8);
        wu.union(6,5);
        wu.union(9,4);
        wu.union(2,1);
        wu.union(8,9);
        wu.union(5,0);
        wu.union(7,2);
        wu.union(6,1);
        wu.union(1,0);
        wu.union(6,7);

        System.out.println(wu.toString());
        System.out.println(wu.count());

    }
}
