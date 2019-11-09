using System.Collections.Generic;

public class Solution
{
    public string DecodeString(string s)
    {
        if (s == "") return s;
        Stack<string> sStk = new Stack<string>();
        Stack<string> sIndex = new Stack<string>();
        bool isNum = false;
        sStk.Push("");
        for (int i = 0; i < s.Length; i++)
        {
            int num;
            switch(s[i])
            {
                case '[':
                    sStk.Push("");
                    isNum = false;
                    break;
                case ']':
                    int repeat = int.Parse(sIndex.Pop());
                    string s1 = "";
                    string s2 = sStk.Pop();
                    for (int j = 0; j < repeat; j++)
                        s1 += s2;
                    sStk.Push(sStk.Pop() + s1);
                    isNum = false;
                    break;
                default:
                    if (s[i]>='0'&&s[i]<='9')
                    {
                        if(isNum)
                        {
                            sIndex.Push(sIndex.Pop() + s[i]);
                        }
                        else
                        {
                            sIndex.Push(s[i].ToString());
                        }
                        isNum = true;
                    }
                    else
                    {
                        if (isNum)
                            sStk.Push(s[i].ToString());
                        else
                            sStk.Push(sStk.Pop() + s[i]);
                        isNum = false;
                    }
                    break;
            }
        }
        return sStk.Peek();
    }
}