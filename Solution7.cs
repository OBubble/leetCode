using System;
using System.Collections.Generic;
public class Solution
{
    public int Reverse(int x)
    {
        int result = 0;
        while (x != 0)
        {
            try
            {
                checked
                {
                    result *= 10;
                    result += x % 10;
                }
            }
            catch
            {
                return 0;
            }
            x /= 10;
        }
        return result;
    }
}