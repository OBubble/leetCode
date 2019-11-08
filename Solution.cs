public class Solution
{
    private int maxS;
    public int MaximalRectangle(char[][] matrix)
    {
        maxS = 0;
        Longlong[] mat = new Longlong[matrix.Length];
        for (int i = 0; i < matrix.Length; i++)
        {
            Longlong a = new Longlong(matrix[i].Length);
            for (int j = 0; j < matrix[i].Length; j++)
            {
                a <<= 1;
                if (matrix[i][j] == '1')
                    a++;
            }
            mat[i] = a;
        }

        for (int i = 0; i < mat.Length; i++)
        {
            Longlong curW = mat[i]&mat[i];
            for (int j = i; j < mat.Length; j++)
            {
                curW &= mat[j];
                if (curW.IsZero())
                    break;
                int l = 0;
                Longlong curW2 = curW&curW;
                while (!curW2.IsZero())
                {
                    curW2 = curW2&(curW2 << 1);
                    l++;
                }
                int s = l * (j - i + 1);
                maxS = s > maxS ? s : maxS;
            }
        }
        return maxS;
    }
}
public class Longlong
{
    byte[] data;
    public Longlong(int Len)
    {
        int bytes = Len / 8 + 1;
        data = new byte[bytes];
        for (int i = 0; i < data.Length; i++)
            data[i] = 0;
    }
    public bool IsZero()
    {
        foreach (var item in data)
        {
            if (item != 0)
                return false;
        }
        return true;
    }
    public static Longlong operator ++(Longlong l)
    {
        l.data[l.data.Length - 1]++;
        return l;
    }
    public static Longlong operator <<(Longlong l, int i)
    {
        l = l & l;
        int index;
        byte b = 0;
        for (index = l.data.Length - 1; index >= 0; index--)
        {
            l.data[index] += b;
            b = (byte)(l.data[index] >> 7);
            l.data[index] <<= 1;
        }
        return l;
    }
    public static Longlong operator &(Longlong l1, Longlong l2)
    {
        Longlong result = new Longlong((l1.data.Length - 1) * 8);
        for (int i = 0; i < result.data.Length; i++)
            result.data[i] = (byte)(l1.data[i] & l2.data[i]);
        return result;
    }
}