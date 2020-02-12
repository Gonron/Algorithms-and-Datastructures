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
        QuickUnion qu = new QuickUnion(10);
        System.out.println("01: " + qu.toString());

        System.out.println("02: " + qu.toString());
        qu.union(4,3);

        qu.union(3,8);
        System.out.println("03: " + qu.toString());

        qu.union(6,5);
        System.out.println("04: " + qu.toString());

        qu.union(9,4);
        System.out.println("05: " + qu.toString());

        qu.union(2,1);
        System.out.println("06: " + qu.toString());

        qu.union(8,9);
        System.out.println("07: " + qu.toString());

        qu.union(5,0);
        System.out.println("08: " + qu.toString());

        qu.union(7,2);
        System.out.println("09: " + qu.toString());

        qu.union(6,1);
        System.out.println("10: " + qu.toString());

        qu.union(1,0);
        System.out.println("11: " + qu.toString());

        qu.union(6,7);
        System.out.println("12: " + qu.toString());

        System.out.println(qu.count());

    }

}


