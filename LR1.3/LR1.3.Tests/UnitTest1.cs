using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._3.Tests;

public class UnitTest1
{
    [Fact]
    public void TestCalculateRectangleArea_ValidInput()
    {
        // Arrange
        double length = 5;
        double width = 3;

        // Act
        double area = Program.CalculateRectangleArea(length, width);

        // Assert
        Assert.Equal(15, area);
    }

    [Fact]
    public void TestCalculateRectangleArea_NegativeInput()
    {
        // Arrange
        double length = -5;
        double width = 3;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Program.CalculateRectangleArea(length, width));
    }

    [Fact]
    public void TestCalculateRectangleArea_ZeroInput()
    {
        // Arrange
        double length = 0;
        double width = 3;

        // Act
        double area = Program.CalculateRectangleArea(length, width);

        // Assert
        Assert.Equal(0, area);
    }
}
