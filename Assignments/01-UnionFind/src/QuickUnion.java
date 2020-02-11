public class QuickUnion implements UnionFind {
    private int count;
    private int[] pointSets;

    public QuickUnion(int count) {
        this.count = count;
        this.pointSets = new int[count];
        for (int i = 0; i < count; i++) {
            pointSets[i] = i;
        }
    }

    @Override
    public void union(int p, int q) {
        int pRoot = find(p);
        int qRoot = find(q);

        if (pRoot == qRoot) return;
        pointSets[pRoot] = qRoot;
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
        QuickFind qf = new QuickFind(10);
        System.out.println("01: " + qf.toString());

        qf.union(4,3);
        System.out.println("02: " + qf.toString());

        qf.union(3,8);
        System.out.println("03: " + qf.toString());

        qf.union(6,5);
        System.out.println("04: " + qf.toString());

        qf.union(9,4);
        System.out.println("05: " + qf.toString());

        qf.union(2,1);
        System.out.println("06: " + qf.toString());

        qf.union(8,9);
        System.out.println("07: " + qf.toString());

        qf.union(5,0);
        System.out.println("08: " + qf.toString());

        qf.union(7,2);
        System.out.println("09: " + qf.toString());

        qf.union(6,1);
        System.out.println("10: " + qf.toString());

        qf.union(1,0);
        System.out.println("11: " + qf.toString());

        qf.union(6,7);
        System.out.println("12: " + qf.toString());

        System.out.println(qf.count());

    }

}


