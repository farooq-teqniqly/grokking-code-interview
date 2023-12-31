using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class AnagramTests
{
    [Theory]
    [InlineData("listen", "silent", true)]
    [InlineData("hello", "ollhe", true)]
    [InlineData("hello", "world", false)]
    [InlineData("rat", "car", false)]
    [InlineData("paper", "repaap", false)]
    public void Can_Detect_Anagram(string s, string t, bool expected)
    {
        IsAnagram().Should().Be(expected);

        bool IsAnagram()
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            var hashSet = new HashSet<char>(s);

            foreach (var ch in t)
            {
                if (hashSet.Add(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}