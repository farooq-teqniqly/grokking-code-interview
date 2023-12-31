using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class ValidPalindromeTests
{
    [Theory]
    [InlineData("A man, a plan, a canal, Panama!", true)]
    [InlineData("Was it a car or a cat I saw?", true)]
    [InlineData("race a car", false)]
    [InlineData(",,,,", false)]
    [InlineData("12321", true)]
    public void Can_Detect_Valid_Palindrome(string s, bool expected)
    {
        DetectValidPalindrome().Should().Be(expected);

        bool DetectValidPalindrome()
        {
            var firstPos = 0;
            var lastPos = s.Length - 1;

            while (true)
            {
                if (firstPos >= lastPos || lastPos <= firstPos)
                {
                    return true;
                }

                while (!char.IsLetterOrDigit(s[firstPos]))
                {
                    firstPos++;

                    if (firstPos == s.Length)
                    {
                        return false;
                    }
                }

                while (!char.IsLetterOrDigit(s[lastPos]))
                {
                    lastPos--;

                    if (lastPos == -1)
                    {
                        return false;
                    }
                }

                if (char.ToLower(s[firstPos]) != char.ToLower(s[lastPos]))
                {
                    return false;
                }

                firstPos++;
                lastPos--;
            }
        }
    }
}