namespace MaximumProductSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -3, -1, -1 };
            var result = MaxProduct(nums);
            Console.WriteLine(result);
        }

        static int MaxProduct(int[] nums)
        {
            int n = nums.Length, res = nums[0], l = 0, r = 0;
            for (int i = 0; i < n; i++)
            {
                l = (l == 0 ? 1 : l) * nums[i];
                r = (r == 0 ? 1 : l) * nums[n - 1 - i];
                res = Math.Max(res, Math.Max(l, r));
            }
            return res;
        }
    }
}