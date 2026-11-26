using System;
using System.Collections.Generic;
using System.Text;

namespace SortingComparison
{
    public static class MergeSortAlgo
    {
        // Bộ đếm để phân tích thực nghiệm
        public static long Comparisons;   // số lần so sánh hai phần tử
        public static long Moves;         // số lần ghi một giá trị vào mảng
        // Hàm công khai: chỉ cần gọi MergeSortAlgo.Sort(mảng)
        public static void Sort(int[] a)
        {
            Comparisons = 0;
            Moves = 0;
            if (a == null || a.Length < 2) return;   // rỗng hoặc 1 phần tử: đã sắp xếp
            int[] temp = new int[a.Length];          // mảng phụ, tạo MỘT LẦN duy nhất
            MergeSortRec(a, temp, 0, a.Length - 1);
        }
        // Chia đôi đoạn [left..right], sắp xếp từng nửa, rồi trộn
        private static void MergeSortRec(int[] a, int[] temp, int left, int right)
        {
            if (left >= right) return;               // điểm dừng: đoạn có 1 phần tử
            int mid = left + (right - left) / 2;
            MergeSortRec(a, temp, left, mid);        // nửa trái
            MergeSortRec(a, temp, mid + 1, right);   // nửa phải
            Merge(a, temp, left, mid, right);        // trộn hai nửa
        }
        // Trộn hai đoạn đã sắp xếp: [left..mid] và [mid+1..right]
        private static void Merge(int[] a, int[] temp, int left, int mid, int right)
        {
            int i = left;        // ngón tay ở nửa trái
            int j = mid + 1;     // ngón tay ở nửa phải
            int k = left;        // vị trí ghi vào mảng phụ
            // Cả hai nửa còn phần tử: lấy số nhỏ hơn
            while (i <= mid && j <= right)
            {
                Comparisons++;
                if (a[i] <= a[j])            // dấu <= giữ TÍNH ỔN ĐỊNH (bằng nhau thì lấy bên trái)
                    temp[k++] = a[i++];
                else
                    temp[k++] = a[j++];
                Moves++;
            }
            // Nửa trái còn dư: chép nốt
            while (i <= mid)
            {
                temp[k++] = a[i++];
                Moves++;
            }
            // Nửa phải còn dư: chép nốt
            while (j <= right)
            {
                temp[k++] = a[j++];
                Moves++;
            }
            // Chép kết quả từ mảng phụ về mảng chính
            for (int t = left; t <= right; t++)
            {
                a[t] = temp[t];
                Moves++;
            }
        }
    }
}
