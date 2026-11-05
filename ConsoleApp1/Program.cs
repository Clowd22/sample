using System;

public class MainApp
{
    static public void Main(string[] args)
    {
        string num = Console.ReadLine();
        Console.WriteLine(FindMAXPalindrome(num));
    }

    /// <summary>
    /// 端から比較するロジックで回文を探し、より大きいものが見つかるたびに更新するメソッド
    /// </summary>
    /// <param name="num">対象の文字列</param>
    /// <returns>一番大きい回文</returns>
    public static string FindMAXPalindrome(string num)
    {
        if (string.IsNullOrEmpty(num)) return string.Empty;

        int length = num.Length;
        string maxPalindrome = ""; // 見つかった回文を保持しておく変数

        // 1. 検証する文字列の開始位置をずらす
        for (int start = 0; start < length; start++)
        {
            // 2. 終了位置を後ろから手前に向かってスキャン（長い組み合わせから順に確認）
            for (int end = length - 1; end >= start; end--)
            {
                // すでに保持している最大の長さ以下の範囲しかなければ、探す必要がないのでスキップ
                if (end - start + 1 <= maxPalindrome.Length)
                {
                    break;
                }

                // 3. 最初と最後の文字から始めて、内側へ向かって一致するか検証する
                int l = start;
                int r = end;
                bool isPalindrome = true;

                while (l < r)
                {
                    if (num[l] != num[r])
                    {
                        isPalindrome = false;
                        break;
                    }
                    l++;
                    r--;
                }

                // 4. 回文であることが確認できたら、保持しているものと比較して更新する
                if (isPalindrome)
                {
                    string foundPalindrome = num.Substring(start, end - start + 1);

                    // 次に見つかった回文が、いま保持しているものより大きければ更新
                    if (foundPalindrome.Length > maxPalindrome.Length)
                    {
                        maxPalindrome = foundPalindrome;
                    }
                    break; // この開始位置での最長が見つかったので、次のスタート位置へ進む
                }
            }
        }

        return maxPalindrome;
    }
}