using System;
using System.Text;

public class MainApp
{
    public static void Main(string[] args)
    {
        string num = Console.ReadLine();
        if (num is not null)
        {
            Console.WriteLine(FindMAXPalindrome(num));
        }
    }

    /// <summary>
    /// Manacherのアルゴリズムを使用して文字列内の最長回文を探索する
    /// </summary>
    public static string FindMAXPalindrome(string num)
    {
        // 1. 各文字の間に '#' を挟み、両端にも '#' を置いた拡張文字列を作成
        var sb = new StringBuilder(num.Length * 2 + 1);
        sb.Append('#');
        foreach (char c in num)
        {
            sb.Append(c);
            sb.Append('#');
        }
        string t = sb.ToString();
        int n = t.Length;

        // 2. Manacherのメイン計算
        int[] p = new int[n];
        int center = 0, right = 0;

        for (int i = 0; i < n; i++)
        {
            int mirror = 2 * center - i;

            if (right > i)
            {
                p[i] = Math.Min(right - i, p[mirror]);
            }
            else
            {
                p[i] = 0;
            }

            // 中心 i から左右に拡張して回文を探索
            while (i - 1 - p[i] >= 0 && i + 1 + p[i] < n && t[i - 1 - p[i]] == t[i + 1 + p[i]])
            {
                p[i]++;
            }

            // 右端の境界を超えた場合は中心と右端を更新
            if (i + p[i] > right)
            {
                center = i;
                right = i + p[i];
            }
        }

        // 3. 最大の回文長と中心インデックスを特定
        int maxLen = 0;
        int centerIndex = 0;

        for (int i = 0; i < n; i++)
        {
            if (p[i] > maxLen)
            {
                maxLen = p[i];
                centerIndex = i;
            }
        }

        // 4. 変換前の元の文字列における開始位置を計算して切り出し
        int start = (centerIndex - maxLen) / 2;
        return num.Substring(start, maxLen);
    }
}