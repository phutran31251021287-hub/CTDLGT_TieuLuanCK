using System;
namespace SortingComparison
{
    // Liệt kê 5 dạng dữ liệu nhóm sẽ thử nghiệm
    public enum DataType
    {
        Random,          // ngẫu nhiên
        Ascending,       // đã sắp xếp tăng
        Descending,      // sắp xếp giảm dần
        NearlySorted,    // gần như đã sắp xếp
        ManyDuplicates   // nhiều giá trị trùng
    }

    public static class DataGenerator
    {
        // Hàm chính: truyền vào dạng dữ liệu, số phần tử n và seed
        // seed mặc định 12345 để kết quả luôn lặp lại được
        public static int[] Generate(DataType type, int n, int seed = 12345)
        {
            switch (type)
            {
                case DataType.Random: return RandomData(n, seed);
                case DataType.Ascending: return AscendingData(n);
                case DataType.Descending: return DescendingData(n);
                case DataType.NearlySorted: return NearlySortedData(n, seed);
                case DataType.ManyDuplicates: return ManyDuplicatesData(n, seed);
                default: throw new ArgumentException("Dạng dữ liệu không hợp lệ");
            }
        }
        // 1. Ngẫu nhiên: mỗi phần tử là số ngẫu nhiên trong [0, 1.000.000)
        public static int[] RandomData(int n, int seed)
        {
            Random rnd = new Random(seed);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(0, 1000000);
            return a;
        }
        // 2. Tăng dần: 0, 1, 2, ..., n-1
        public static int[] AscendingData(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = i;
            return a;
        }
        // 3. Giảm dần: n-1, n-2, ..., 0
        public static int[] DescendingData(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = n - 1 - i;
            return a;
        }
        // 4. Gần như đã sắp xếp: lấy mảng tăng dần rồi đổi chỗ ngẫu nhiên ~1% số phần tử
        public static int[] NearlySortedData(int n, int seed, double swapRatio = 0.01)
        {
            int[] a = AscendingData(n);
            if (n < 2) return a;   // mảng rỗng hoặc 1 phần tử thì không có gì để đổi
            Random rnd = new Random(seed);
            int swaps = Math.Max(1, (int)(n * swapRatio));
            for (int k = 0; k < swaps; k++)
            {
                int i = rnd.Next(n);
                int j = rnd.Next(n);
                while (j == i)               // nếu trùng thì bốc lại cho đến khi khác nhau
                    j = rnd.Next(n);
                int tmp = a[i];
                a[i] = a[j];
                a[j] = tmp;
            }
            return a;
        }
        // 5. Nhiều trùng: chỉ có "distinct" giá trị khác nhau (mặc định 10 giá trị: 0..9)
        public static int[] ManyDuplicatesData(int n, int seed, int distinct = 10)
        {
            Random rnd = new Random(seed);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(0, distinct);
            return a;
        }
    }
}

