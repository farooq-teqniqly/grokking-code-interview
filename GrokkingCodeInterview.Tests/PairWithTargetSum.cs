using System.Runtime.CompilerServices;
using FluentAssertions;
using Microsoft.VisualBasic;

namespace GrokkingCodeInterview.Tests;

public class PairWithTargetSum()
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 6 }, 6, new[] { 1, 3 })]
    [InlineData(new[] { 2, 5, 9, 11 }, 11, new[] { 0, 2 })]
    [InlineData(new[] { 0, 1, 2, 3, 4 }, 0, new[] { -1, -1 })]
    public void Can_Get_Pairs(int[] arr, int targetSum, int[] expected)
    {
        GetPairs().Should().Equal(expected);

        int[] GetPairs()
        {
            for (int firstIndex = 0, lastIndex = arr.Length - 1; ;)
            {
                if (firstIndex == lastIndex)
                {
                    return [-1, -1];
                }

                var sum = arr[firstIndex] + arr[lastIndex];

                if (sum > targetSum)
                {
                    lastIndex--;
                }
                else if (sum < targetSum)
                {
                    firstIndex++;
                }
                else
                {
                    return [firstIndex, lastIndex];
                }
            }
        }

    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 6 }, 6, new[] { 1, 3 })]
    [InlineData(new[] { 2, 5, 9, 11 }, 11, new[] { 0, 2 })]
    [InlineData(new[] { 0, 1, 2, 3, 4 }, 0, new[] { -1, -1 })]
    public void Can_Get_Pairs_Using_Dict(int[] arr, int targetSum, int[] expected)
    {
        GetPairs().Should().Equal(expected);

        int[] GetPairs()
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < arr.Length; i++)
            {
                var num = arr[i];

                var complement = targetSum - num;

                if (dict.TryGetValue(complement, out int value))
                {
                    return [value, i];
                }

                dict.TryAdd(num, i);
            }

            return [-1, -1];
        }

    }
}