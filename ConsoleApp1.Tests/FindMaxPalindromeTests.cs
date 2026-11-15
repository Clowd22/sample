using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests;

[TestClass]
public class FindMaxPalindromeTests
{
    [DataTestMethod]
    [DataRow("", "")]
    [DataRow("a", "a")]
    [DataRow("aa", "aa")]
    [DataRow("ab", "a")]
    [DataRow("aba", "aba")]
    [DataRow("abba", "abba")]
    [DataRow("babad", "bab")]
    [DataRow("cbbd", "bb")]
    [DataRow("123454321", "123454321")]
    [DataRow("1221", "1221")]
    [DataRow("111222", "111")]
    [DataRow("abacdfgdcaba", "aba")]
    [DataRow("aaaaaa", "aaaaaa")]
    [DataRow("racecarx", "racecar")]
    [DataRow("xracecar", "racecar")]
    [DataRow("a1234321b", "1234321")]
    [DataRow("1001", "1001")]
    [DataRow("987654321", "9")]
    [DataRow("12 21", "12 21")]
    [DataRow("AaA", "AaA")]
    public void FindMAXPalindrome_ReturnsExpectedPalindrome(string input, string expected)
    {
        string actual = MainApp.FindMAXPalindrome(input);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindMAXPalindrome_ThrowsForNull()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => MainApp.FindMAXPalindrome(null!));
    }

    [TestMethod]
    public void FindMAXPalindrome_HandlesVeryLongInput()
    {
        string input = new('7', 200_000);

        string actual = MainApp.FindMAXPalindrome(input);

        Assert.AreEqual(input, actual);
    }

    [TestMethod]
    public void FindMAXPalindrome_HandlesLargeInputWithPalindromeAtTheEnd()
    {
        string palindrome = new('8', 100_001);
        string input = new string('1', 100_000) + palindrome + new string('2', 100_000);

        string actual = MainApp.FindMAXPalindrome(input);

        Assert.AreEqual(palindrome, actual);
    }
}
