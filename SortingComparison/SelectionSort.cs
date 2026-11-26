using System;
using System.Collections.Generic;
using System.Text;

namespace SortingComparison
{
    public static class SelectionSort
    {
        public static long Comparisons;
        public static long Moves;         
        
        public static void Sort(int[] a)
        {
            Comparisons = 0;
            Moves = 0;
            if (a == null || a.Length < 2) return;   // rỗng hoặc 1 phần tử: đã sắp xếp

            // Mỗi lượt i: tìm số nhỏ nhất trong phần chưa sắp [i..n-1], đưa về vị trí i
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;                         // giả sử a[i] là nhỏ nhất
                for (int j = i + 1; j < a.Length; j++)
                {
                    Comparisons++;
                    if (a[j] < a[min])
                        min = j;                     // tìm được số nhỏ hơn: nhớ vị trí
                }

                if (min != i)                        // chỉ đổi chỗ khi thật sự cần
                {
                    int tmp = a[i];
                    a[i] = a[min];
                    a[min] = tmp;
                    Moves += 2;                      // đổi chỗ = ghi 2 giá trị vào mảng
                }
            }
        }
    }
}
