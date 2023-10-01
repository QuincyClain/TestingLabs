using System;
using System.Collections.Generic;
using Xunit;
using LR1._2;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._2.Tests;

public class UnitTest1
{
    [Fact]
    public void TestCalculateStatistics()
    {
        // Arrange
        List<Person> people = new List<Person>
            {
                new Person("Иван", "Иванов", 30),
                new Person("Петр", "Петров", 25),
                new Person("Анна", "Сидорова", 35)
            };

        // Act
        var (minAge, maxAge, averageAge) = Program.CalculateStatistics(people);

        // Assert
        Assert.Equal(25, minAge);
        Assert.Equal(35, maxAge);
        Assert.Equal(30.0, averageAge);
    }

    [Fact]
    public void TestCalculateStatistics_OnePerson()
    {
        // Arrange
        List<Person> people = new List<Person>
    {
        new Person("Иван", "Иванов", 30)
    };

        // Act
        var (minAge, maxAge, averageAge) = Program.CalculateStatistics(people);

        // Assert
        Assert.Equal(30, minAge);
        Assert.Equal(30, maxAge);
        Assert.Equal(30.0, averageAge);
    }


    [Fact]
    public void TestCalculateStatistics_NegativeAge()
    {
        // Arrange
        List<Person> people = new List<Person>
            {
                new Person("Иван", "Иванов", 30),
                new Person("Петр", "Петров", 25),
                new Person("Анна", "Сидорова", -5) // Отрицательный возраст
            };

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => Program.CalculateStatistics(people));
    }

    [Fact]
    public void TestCalculateStatistics_SameNames()
    {
        // Arrange
        List<Person> people = new List<Person>
    {
        new Person("Иван", "Иванов", 30),
        new Person("Петр", "Петров", 25),
        new Person("Иван", "Сидоров", 35) // Человек с одинаковым именем
    };

        // Act
        var (minAge, maxAge, averageAge) = Program.CalculateStatistics(people);

        // Assert
        Assert.Equal(25, minAge); // Минимальный возраст
        Assert.Equal(35, maxAge); // Максимальный возраст
        Assert.Equal(30.0, averageAge); // Средний возраст
    }

    [Fact]
    public void TestCalculateStatistics_SameNameLastNameAndAge()
    {
        // Arrange
        List<Person> people = new List<Person>
    {
        new Person("Иван", "Иванов", 30),
        new Person("Петр", "Петров", 25),
        new Person("Иван", "Иванов", 30), // Человек с одинаковым именем, фамилией и возрастом
        new Person("Анна", "Сидорова", 35)
    };

        // Act
        var (minAge, maxAge, averageAge) = Program.CalculateStatistics(people);

        // Assert
        Assert.Equal(25, minAge); // Минимальный возраст
        Assert.Equal(35, maxAge); // Максимальный возраст
        Assert.Equal(30.0, averageAge); // Средний возраст
    }

}
