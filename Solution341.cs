
// This is the interface that allows for creating nested lists.
// You should not implement it, or speculate about its implementation
using System.Collections.Generic;

public interface NestedInteger {
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<NestedInteger> GetList();
 }
public class test : NestedInteger
{
    public int val;
    public List<NestedInteger> lst;
    public test(int i)
    {
        val = i;
    }
    public test(List<NestedInteger> l)
    {
        lst = l;
    }
    public int GetInteger()
    {
        return val;
    }

    public IList<NestedInteger> GetList()
    {
        return lst;
    }

    public bool IsInteger()
    {
        return lst != null;
    }
}
public class NestedIterator
{
    Stack<int> indexs;
    Stack<IList<NestedInteger>> nodes;
    List<int> arr;
    int index;
    public NestedIterator(IList<NestedInteger> nestedList)
    {
        index = 0;
        arr = new List<int>();
        foreach (var item in nestedList)
        {
            AddNum(item);
        }
    }
    void AddNum(NestedInteger node)
    {
        if (node.IsInteger())
            arr.Add(node.GetInteger());
        else
            foreach (var item in node.GetList())
                AddNum(item);
    }
    public bool HasNext()
    {
        return index < arr.Count;
    }
    public int Next()
    {
        return arr[index++];
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
