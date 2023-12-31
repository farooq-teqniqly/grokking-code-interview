using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class FindNonDuplicateNumbersTests
{
    [Theory]
    [InlineData(new[] { 2, 3, 3, 3, 6, 9, 9 }, 4)]
    [InlineData(new[] { 2, 2, 2, 11 }, 2)]
    public void Can_Find_Non_Dupe_Array_Length(int[] arr, int expected)
    {
        FindNonDupes().Should().Be(expected);

        int FindNonDupes()
        {
            var nextNonDupeIndex = 1;

            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[nextNonDupeIndex - 1] != arr[i])
                {
                    arr[nextNonDupeIndex] = arr[i];
                    nextNonDupeIndex++;
                }
            }

            return nextNonDupeIndex;
        }
    }
}