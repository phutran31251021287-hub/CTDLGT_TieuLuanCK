using System;
using System.Collections.Generic;
using System.Text;

namespace SortingComparison
{
    public static class InsertionSortAlgo
    {
        public static long Comparisons;
        public static long Moves;
        
        public static void Sort(int[] a)
        {
            Comparisons = 0;
            Moves = 0;
            if (a == null || a.Length < 2) return;   // rỗng hoặc 1 phần tử: đã sắp xếp

            // Phần [0..i-1] luôn đã sắp xếp. Lấy a[i] chèn vào đúng chỗ của nó.
            for (int i = 1; i < a.Length; i++)
            {
                int x = a[i];                        // số cần chèn (cầm ra ngoài)
                int j = i - 1;                       // bắt đầu so với số liền trước
                
                while (j >= 0)
                {
                    Comparisons++;
                    if (a[j] > x)
                    {
                        a[j + 1] = a[j];             // dịch sang phải
                        Moves++;
                        j--;
                    }
                    else
                    {
                        break;                       // gặp số <= x: đã tìm được chỗ
                    }
                }

                a[j + 1] = x;                        // đặt x vào chỗ trống
                Moves++;
            }
        }
    }
}
