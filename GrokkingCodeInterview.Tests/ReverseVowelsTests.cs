using System.Runtime.InteropServices;
using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class ReverseVowelsTests
{
    static readonly string vowels = "aeiouAEIOU";

    [Theory]
    [InlineData("hello", "holle")]
    [InlineData("AEIOU", "UOIEA")]
    [InlineData("DesignGUrus", "DusUgnGires")]
    [InlineData("string", "string")]
    public void Can_Reverse_Vowels(string original, string expected)
    {
        ReverseVowels().Should().Be(expected);

        return;

        string ReverseVowels()
        {
            var input = original.ToCharArray();
            var firstPos = 0;
            var lastPos = input.Length - 1;

            while (true)
            {
                if (firstPos >= lastPos || lastPos <= firstPos)
                {
                    break;
                }

                if (!vowels.Contains(input[firstPos]))
                {
                    firstPos++;
                }

                if (!vowels.Contains(input[lastPos]))
                {
                    lastPos--;
                }

                if (vowels.Contains(input[firstPos]) && vowels.Contains(input[lastPos]))
                {
                    (input[lastPos], input[firstPos]) = (input[firstPos], input[lastPos]);
                    firstPos++;
                    lastPos--;
                }
            }

            return new string(input);
        }
    }
}