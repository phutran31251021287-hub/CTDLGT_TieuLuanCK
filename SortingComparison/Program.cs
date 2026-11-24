using System;
using System.Linq;
using SortingComparison;
Console.OutputEncoding = System.Text.Encoding.UTF8;
foreach (DataType t in Enum.GetValues(typeof(DataType)))
{
    int[] a = DataGenerator.Generate(t, 20);
    Console.WriteLine(t.ToString().PadRight(15) + ": " + string.Join(", ", a));
}
int[] x = DataGenerator.Generate(DataType.Random, 1000, 1);
int[] y = DataGenerator.Generate(DataType.Random, 1000, 1);
Console.WriteLine("Cùng seed cho cùng dữ liệu: " + x.SequenceEqual(y));
