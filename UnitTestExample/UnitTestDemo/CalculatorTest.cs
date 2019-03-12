using System;
using Xunit;
using UnitTestExample;
using System.Collections.Generic;

namespace UnitTestDemo
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(4,3,7)]
        [InlineData(2.5,3.5,6)]
        [InlineData(-1.5,-5,-6.5)]
        [InlineData(double.MaxValue,10,double.MaxValue)]
        [InlineData(double.MaxValue,double.MaxValue,double.PositiveInfinity)]
        public void Add_ShouldCalculate_Return(double x, double y, double expected)
        {
            //Arrange
            //var expected = 5;
            //Act
            var actual = Calculator.Add(x, y);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 2, 4)]
        [InlineData(10, 2.5, 4)]
        [InlineData(-8, -2, 4)]
        public void Divide_ShouldDivide_ReturnEqual(double x, double y, double expected)
        {
            var actual = Calculator.Divide(x, y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_MemoryDataTheory(double x, double y, double expected)
        {
            double actual = Calculator.Add(x, y);
            Assert.Equal(actual, expected);
        }

        public static IEnumerable<object[]> TestData
            => new[]
            {
                new object[] {5,3 ,8},
                new object[] {-1, -3, -4}
            };
    }
}
