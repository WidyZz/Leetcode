using System.Diagnostics;
using System.Timers;

namespace MedianOfTwoSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            var nums1 = new int[] { 1, 3 };
            var nums2 = new int[] { 2 };
            sw.Start();
            var linqResult = FindMedianSortedArraysLinqVersion(nums1, nums2);
            sw.Stop();
            Console.WriteLine($"Linq: {linqResult} | elapsed: {sw.Elapsed.TotalMilliseconds} ms");
            sw.Restart();
            var whileResult = FindMedianSortedArrays(nums1, nums2);
            sw.Stop();
            Console.WriteLine($"While: {whileResult} | elapsed: {sw.Elapsed.TotalMilliseconds} ms");
        }

        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n = nums1.Length, m = nums2.Length, i = 0, j = 0;
            var mergedNumbers = new List<int>();

            while (i < n && j < m)
            {
                if (nums1[i] < nums2[j])
                {
                    mergedNumbers.Add(nums1[i++]);
                }
                else
                {
                    mergedNumbers.Add(nums2[j++]);
                }
            }

            while (i < nums1.Length) mergedNumbers.Add(nums1[i++]);
            while (j < nums2.Length) mergedNumbers.Add(nums2[j++]);

            int mid = mergedNumbers.Count / 2;
            if (mergedNumbers.Count > 0 && mergedNumbers.Count % 2 == 0)
            {
                return (mergedNumbers[mid] + mergedNumbers[mid - 1]) / 2.0;
            }
            else
            {
                return mergedNumbers[mid];
            }
        }

        static double FindMedianSortedArraysLinqVersion(int[] nums1, int[] nums2)
        {
            var mergedNumbers = nums1.Concat(nums2).OrderBy(x => x).ToList();

            int mid = mergedNumbers.Count / 2;

            if (mergedNumbers.Count > 0 && mergedNumbers.Count % 2 == 0)
            {
                return (mergedNumbers[mid] + mergedNumbers[mid - 1]) / 2.0;
            }
            else
            {
                return mergedNumbers[mid];
            }
        }
    }
}