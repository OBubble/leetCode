public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = -1;
            bool find = false;
            for (int j = 0; j < nums2.Length; j++) 
            {
                if (nums2[j] == nums1[i])
                    find = true;
                if(nums2[j]>nums1[i]&&find)
                {
                    result[i] = nums2[j];
                    continue;
                }
            }
        }
        return result;
    }
}