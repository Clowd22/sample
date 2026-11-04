using System;
using System.IO;
using System.Collections.Generic;

public class MainApp
{
    static public void Main(string[] args)
    {
        var lines = GetStdin();
        if (lines.Length == 0) return;

        string s = lines[0].Trim();
        char[] chars = s.ToCharArray();

        // 1. 各桁の文字を昇順にソートする
        Array.Sort(chars);

        // 2. 先頭が '0' の場合、0ではない最初の文字を先頭に持っていく
        if (chars[0] == '0')
        {
            int nonZeroIndex = -1;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != '0')
                {
                    nonZeroIndex = i;
                    break;
                }
            }

            if (nonZeroIndex != -1)
            {
                // 0ではない最小の文字を先頭にし、それまでを後ろにずらす
                char target = chars[nonZeroIndex];
                for (int i = nonZeroIndex; i > 0; i--)
                {
                    chars[i] = chars[i - 1];
                }
                chars[0] = target;
            }
        }

        // 結果を出力
        Console.WriteLine(new string(chars));
    }

    static private string[] GetStdin()
    {
        var list = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            list.Add(line);
        }
        return list.ToArray();
    }
}