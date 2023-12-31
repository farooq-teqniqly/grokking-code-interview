using System.Runtime.ExceptionServices;
using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class GoodPairsTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 1, 1, 3 }, 4)]
    [InlineData(new[] { 1, 1, 1, 1 }, 6)]
    [InlineData(new[] { 1, 2, 3 }, 0)]
    public void Can_Calculate_Number_Of_Good_Pairs(int[] nums, int expected)
    {
        GoodPairs().Should().Be(expected);

        int GoodPairs()
        {
            var pairs = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var firstNum = nums[i];

                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == firstNum)
                    {
                        pairs++;
                    }
                }
            }

            return pairs;
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 1, 1, 3 }, 4)]
    [InlineData(new[] { 1, 1, 1, 1 }, 6)]
    [InlineData(new[] { 1, 2, 3 }, 0)]
    public void Can_Calculate_Number_Of_Good_Pairs_Using_Dict(int[] nums, int expected)
    {
        GoodPairs().Should().Be(expected);

        int GoodPairs()
        {
            var pairs = 0;
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.TryAdd(num, 1))
                {
                    dict[num] += 1;
                }

                pairs += dict[num] - 1;
            }

            return pairs;
        }
    }
}