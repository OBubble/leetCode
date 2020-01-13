using System;
using System.Collections.Generic;
public class Solution
{
    public int CalPoints(string[] ops)
    {
        Stack<int> stk = new Stack<int>();
        int result = 0;
        foreach (var item in ops)
        {
            int val;
            bool isInt = int.TryParse(item,out val);
            if(isInt)
            {
                stk.Push(val);
                result += val;
                continue;
            }
            else
            {
                switch(item)
                {
                    case "D":
                        int dv = stk.Peek() * 2;
                        stk.Push(dv);
                        result += dv;
                        break;
                    case "+":
                        int peek = stk.Pop();
                        int av = stk.Peek() + peek;
                        stk.Push(peek);
                        stk.Push(av);
                        result += av;
                        break;
                    case "C":
                        result -= stk.Pop();
                        break;
                }
            }
        }
        return result;
    }
}