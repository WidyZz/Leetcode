namespace MedianOfTwoSortedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
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
    }
}