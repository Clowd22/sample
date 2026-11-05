using System;

public class MainApp
{
    static public void Main(string[] args)
    {
        string num = Console.ReadLine();
        Console.WriteLine(FindMAXPalindrome(num));
    }

    public static string FindMAXPalindrome(string num)
    {
        if (string.IsNullOrEmpty(num)) return string.Empty;

        int length = num.Length;
        string maxPalindrome = ""; 

        for (int start = 0; start < length; start++)
        {
            for (int end = length - 1; end >= start; end--)
            {
                if (end - start + 1 <= maxPalindrome.Length)
                {
                    break;
                }

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

                if (isPalindrome)
                {
                    string foundPalindrome = num.Substring(start, end - start + 1);

                    if (foundPalindrome.Length > maxPalindrome.Length)
                    {
                        maxPalindrome = foundPalindrome;
                    }
                    break; 
                }
            }
        }

        return maxPalindrome;
    }
}