public class Solution
{
    public bool IsNum;
    public bool isNum
    {
        get { return IsNum; }
        set
        {
            IsNum = value;
        }
    }
    public NestedInteger Deserialize(string s)
    {
        if (s == "")
            return null;
        s = s.Replace(",", " ");
        s = s.Replace("[", "[ ");
        s = s.Replace("]", " ]");
        s = s.Replace("[  ]", "[ ]");
        string[] ss = s.Split(' ');
        Stack<NestedInteger> nodes = new Stack<NestedInteger>();
        nodes.Push(new NestedInteger());
        isNum = false;
        for (int i = 0; i < ss.Length; i++)
        {
            switch (ss[i])
            {
                case "[":
                    NestedInteger node1 = new NestedInteger();
                    nodes.Peek().Add(node1);
                    nodes.Push(node1);
                    isNum = false;
                    break;
                case "]":
                    nodes.Pop();
                    isNum = false;
                    break;
                default:
                    nodes.Peek().Add(new NestedInteger(int.Parse(ss[i])));
                    break;
            }
        }
        return nodes.Peek().GetList()[0];
    }
}