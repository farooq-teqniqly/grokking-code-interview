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
            var word1Indexes = new List<int>();
            var word2Indexes = new List<int>();

            for (var i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    word1Indexes.Add(i);
                }
                else if (words[i] == word2)
                {
                    word2Indexes.Add(i);
                }
            }

            var minDistance = int.MaxValue;

            for (var i = 0; i < word1Indexes.Count; i++)
            {
                for (var j = 0; j < word2Indexes.Count; j++)
                {
                    var distance = Math.Abs(word1Indexes[i] - word2Indexes[j]);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
            }

            return minDistance;
        }
    }
}