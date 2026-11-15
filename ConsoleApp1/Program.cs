using System;

public class MainApp
{
    public static void Main(string[] args)
    {
        string? num = Console.ReadLine();
        if (num is not null)
        {
            Console.WriteLine(FindMAXPalindrome(num));
        }
    }

    public static string FindMAXPalindrome(string num)
    {

        int length = num.Length;
        if (length == 0)
        {
            return string.Empty;
        }

        int bestStart = 0;
        int bestLength = 1;

        var oddRadius = new int[length];
        int left = 0;
        int right = -1;
        for (int i = 0; i < length; i++)
        {
            int radius = i > right
                ? 1
                : Math.Min(oddRadius[left + right - i], right - i + 1);

            while (i - radius >= 0 && i + radius < length && num[i - radius] == num[i + radius])
            {
                radius++;
            }

            oddRadius[i] = radius;
            int start = i - radius + 1;
            int palindromeLength = 2 * radius - 1;
            if (palindromeLength > bestLength ||
                palindromeLength == bestLength && start < bestStart)
            {
                bestStart = start;
                bestLength = palindromeLength;
            }

            if (i + radius - 1 > right)
            {
                left = i - radius + 1;
                right = i + radius - 1;
            }
        }

        var evenRadius = new int[length];
        left = 0;
        right = -1;
        for (int i = 0; i < length; i++)
        {
            int radius = i > right
                ? 0
                : Math.Min(evenRadius[left + right - i + 1], right - i + 1);

            while (i - radius - 1 >= 0 && i + radius < length && num[i - radius - 1] == num[i + radius])
            {
                radius++;
            }

            evenRadius[i] = radius;
            int start = i - radius;
            int palindromeLength = 2 * radius;
            if (palindromeLength > bestLength ||
                palindromeLength == bestLength && start < bestStart)
            {
                bestStart = start;
                bestLength = palindromeLength;
            }

            if (i + radius - 1 > right)
            {
                left = i - radius;
                right = i + radius - 1;
            }
        }

        return num.Substring(bestStart, bestLength);
    }
}