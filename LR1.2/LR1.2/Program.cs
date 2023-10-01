using System;
using System.Collections.Generic;
using System.Linq;

namespace LR1._2;
public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        Console.WriteLine("Введите информацию о людях. Для завершения ввода нажмите Enter без ввода данных.");

        while (true)
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName))
                break;

            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите возраст: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
            {
                Console.WriteLine("Некорректный возраст. Возраст должен быть положительным числом.");
                continue;
            }

            people.Add(new Person(firstName, lastName, age));
        }

        if (people.Any())
        {
            Console.WriteLine("\nСписок людей:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.LastName} {person.FirstName} {person.Age}");
            }

            var (minAge, maxAge, averageAge) = CalculateStatistics(people);

            Console.WriteLine($"\nСамый маленький возраст: {minAge}");
            Console.WriteLine($"Самый большой возраст: {maxAge}");
            Console.WriteLine($"Средний возраст: {averageAge:F2}");
        }
        else
        {
            Console.WriteLine("Список людей пуст.");
        }
    }

    public static (int minAge, int maxAge, double averageAge) CalculateStatistics(List<Person> people)
    {
        if (!people.Any())
        {
            return (int.MaxValue, int.MinValue, double.NaN);
        }

        if (people.Any(p => p.Age < 0))
        {
            throw new InvalidOperationException("Отрицательный возраст не допускается.");
        }

        int minAge = people.Min(p => p.Age);
        int maxAge = people.Max(p => p.Age);
        double averageAge = people.Average(p => p.Age);
        return (minAge, maxAge, averageAge);
    }
}

public class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

