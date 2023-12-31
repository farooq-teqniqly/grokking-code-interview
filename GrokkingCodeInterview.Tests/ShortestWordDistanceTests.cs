using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class ShortestWordDistanceTests
{
    [Theory]
    [InlineData(new[] { "a", "c", "d", "b", "a" }, "a", "b", 1)]
    [InlineData(new[] { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" }, "fox", "dog", 5)]
    [InlineData(new[] { "b", "b", "c", "c", "a", "e", "f", "a", "f" }, "f", "c", 3)]
    public void Can_Calculate_Shortest_Word_Distance(string[] words, string word1, string word2, int expected)
    {
        MinDistance().Should().Be(expected);

        int MinDistance()
        {
            var word1Index = -1;
            var word2Index = -1;
            var minDistance = words.Length;

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    word1Index = i;
                }
                else if (words[i] == word2)
                {
                    word2Index = i;
                }

                if (word1Index == -1 || word2Index == -1)
                {
                    continue;
                }

                var distance = Math.Abs(word1Index - word2Index);

                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            return minDistance;
        }
    }
}