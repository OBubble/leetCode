using System;
using System.Collections.Generic;
public class Solution
{
    public string RemoveDuplicates(string S)
    {
        char[] result = new char[S.Length];
        int Count = 0;
        for (int i = 0; i < S.Length; i++) 
        {
            char item = S[i];
            if (Count == 0) 
            {
                result[Count++]=item;
                continue;
            }
            if (result[Count - 1] == item)
                Count--;
            else
                result[Count++]=item;
        }
        string s = "";
        for (int i = 0; i < Count; i++)
            s += result[i];
        return s;
    }
}