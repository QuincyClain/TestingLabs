using System;
namespace LR1._3;
public class Program
{
    static void Main(string[] args)
    {
        double length, width;

        while (true)
        {
            Console.Write("Введите длину прямоугольника: ");
            if (double.TryParse(Console.ReadLine(), out length) && length > 0)
                break;
            Console.WriteLine("Некорректное значение. Длина должна быть положительным числом.");
        }

        while (true)
        {
            Console.Write("Введите ширину прямоугольника: ");
            if (double.TryParse(Console.ReadLine(), out width) && width > 0)
                break;
            Console.WriteLine("Некорректное значение. Ширина должна быть положительным числом.");
        }

        double area = CalculateRectangleArea(length, width);
        Console.WriteLine($"Площадь прямоугольника: {area}");
    }

    public static double CalculateRectangleArea(double length, double width)
    {
        if (length < 0 || width < 0)
        {
            throw new ArgumentException("Длина и ширина прямоугольника должны быть положительными числами.");
        }

        return length * width;
    }
}

