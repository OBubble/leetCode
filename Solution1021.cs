using System;
using System.Collections.Generic;
public class Solution
{
    public string RemoveOuterParentheses(string S)
    {
        string result = "";
        string cur = "";
        int cnt = 0;
        foreach (var item in S)
        {
            cur += item.ToString();
            if (item == '(')
                cnt++;
            else
                cnt--;
            if (cnt == 0)
            {
                cur = cur.Remove(0, 1);
                cur = cur.Remove(cur.Length - 1);
                result += cur;
                cur = "";
            }
        }
        return result;
    }
}