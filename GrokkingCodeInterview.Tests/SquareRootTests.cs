using FluentAssertions;

namespace GrokkingCodeInterview.Tests;

public class SquareRootTests
{
    [Theory]
    [InlineData(8, 2)]
    [InlineData(4, 2)]
    [InlineData(21, 4)]
    [InlineData(2, 1)]
    [InlineData(1234567891, 35136)]
    [InlineData(2147395600, 46340)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void Can_Calculate_Floor_Of_Square_Root(int x, int expected)
    {
        SquareRootFloor().Should().Be(expected);

        int SquareRootFloor()
        {
            long start = 1;

            while (start * start <= x)
            {
                start++;
            }

            return (int)start - 1;
        }
    }

    [Theory]
    [InlineData(8, 2)]
    [InlineData(4, 2)]
    [InlineData(21, 4)]
    [InlineData(2, 1)]
    [InlineData(1234567891, 35136)]
    [InlineData(2147395600, 46340)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    public void Can_Calculate_Floor_Of_Square_Root_Using_Binary_Search(int x, int expected)
    {
        SquareRootFloor().Should().Be(expected);

        int SquareRootFloor()
        {
            if (x < 2)
            {
                return x;
            }

            var left = 2;
            var right = x / 2;
            int pivot;
            long num;

            while (left <= right)
            {
                pivot = left + ((right - left) / 2);
                num = (long)pivot * pivot;

                if (num > x)
                {
                    right = pivot - 1;
                }
                else if (num < x)
                {
                    left = pivot + 1;
                }
                else
                {
                    return pivot;
                }
            }

            return right;
        }
    }
}