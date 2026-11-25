using System;
using System.Linq;
using SortingComparison;
// Data generate
Console.OutputEncoding = System.Text.Encoding.UTF8;
/*foreach (DataType t in Enum.GetValues(typeof(DataType)))
{
    int[] a = DataGenerator.Generate(t, 20);
    Console.WriteLine(t.ToString().PadRight(15) + ": " + string.Join(", ", a));
}
int[] x = DataGenerator.Generate(DataType.Random, 1000, 1);
int[] y = DataGenerator.Generate(DataType.Random, 1000, 1);
Console.WriteLine("Cùng seed cho cùng dữ liệu: " + x.SequenceEqual(y));*/

// Merge Sort
// Test 1: ví dụ chạy tay trong giảng giải
int[] demo = { 6, 5, 3, 1, 8, 7, 2, 4 };
MergeSortAlgo.Sort(demo);
Console.WriteLine("Demo: " + string.Join(", ", demo));
Console.WriteLine();
// Test 2: kết quả phải giống Array.Sort trên cả 5 dạng dữ liệu
foreach (DataType t in Enum.GetValues(typeof(DataType)))
{
    int[] a = DataGenerator.Generate(t, 1000);
    int[] expected = (int[])a.Clone();
    Array.Sort(expected);                         // đáp án chuẩn
    MergeSortAlgo.Sort(a);
    bool ok = a.SequenceEqual(expected);
    Console.WriteLine(t.ToString().PadRight(15) + ": " + (ok ? "ĐÚNG" : "SAI")
        + " | so sánh = " + MergeSortAlgo.Comparisons
        + " | ghi = " + MergeSortAlgo.Moves);
}
Console.WriteLine();
// Test 3: trường hợp biên
int[] empty = new int[0];
MergeSortAlgo.Sort(empty);
Console.WriteLine("Mảng rỗng: không lỗi");
int[] one = { 42 };
MergeSortAlgo.Sort(one);
Console.WriteLine("1 phần tử: " + one[0]);
int[] allSame = { 5, 5, 5, 5, 5 };
MergeSortAlgo.Sort(allSame);
Console.WriteLine("Toàn bằng nhau: " + string.Join(", ", allSame));