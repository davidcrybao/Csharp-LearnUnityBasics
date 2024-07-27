namespace C_进阶实践练习
{
    internal class test
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int length = m + n;
            for (int i = 0; i < n; i++)
            {
                nums1[i + m] = nums2[i];
            }

            for (int i = 0; i < length -1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < length - 1; j++)
                {
                    if (nums1[minIndex] > nums1[j])
                    {
                        minIndex = j;
                    }
                }
                int temp = nums1[minIndex];
                nums1[minIndex] = nums1[i];
                nums1[i] = temp;
            }
        }
    }
}