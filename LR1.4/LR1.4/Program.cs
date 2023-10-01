using System;
using System.Diagnostics;
using System.IO;
namespace LR1._4;
public class Program
{
    public static void Main(string[] args)
    {
        // Создаем HTML-файл и записываем в него заголовок и начало таблицы
        using (StreamWriter writer = new StreamWriter("table.html"))
        {
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset=\"UTF-8\">"); // Кодировка UTF-8
            writer.WriteLine("<style>");
            writer.WriteLine("table { border-collapse: collapse; width: 100%; }");
            writer.WriteLine("td { border: 1px solid black; padding: 8px; }");
            writer.WriteLine("</style>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            writer.WriteLine("<table>");

            // Генерируем 10 строк таблицы с изменяющимся фоном
            for (int i = 1; i <= 10; i++)
            {
                string backgroundColor = GetBackgroundColor(i);
                writer.WriteLine($"<tr style='background-color:{backgroundColor};'>");

                // Здесь можно добавить содержимое ячеек таблицы
                writer.WriteLine("<td>Ячейка 1</td>");
                writer.WriteLine("<td>Ячейка 2</td>");

                writer.WriteLine("</tr>");
            }

            // Завершаем таблицу и HTML-файл
            writer.WriteLine("</table>");
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        Console.WriteLine("HTML-файл с таблицей создан.");

        // Открываем HTML-файл в браузере
        Process.Start("open", "table.html");
    }

    // Метод для генерации цвета фона строки таблицы (светлые сверху, темные снизу)
    static string GetBackgroundColor(int rowIndex)
    {
        // Минимальная яркость (черный)
        int minBrightness = 0;

        // Максимальная яркость (белый)
        int maxBrightness = 255;

        // Вычисляем яркость для текущей строки (светлые сверху к темным)
        int brightness = maxBrightness - rowIndex * 25;

        // Формируем цвет фона в формате RGB
        string color = $"rgb({brightness},{brightness},{brightness})";

        return color;
    }
}

