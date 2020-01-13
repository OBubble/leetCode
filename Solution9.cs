using System;
using System.Collections.Generic;
public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        int[] res = new int[10];
        int index = 0;
        while (x != 0)
        {
            res[index++] = x % 10;
            x /= 10;
        }
        for (int i = 0; i < index/2; i++)
        {
            if (res[index - i - 1] != res[i])
                return false;
        }
        return true;
    }
}