using System.Text;
using Xunit.Abstractions;

namespace LR1._5_UserInput_.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void TestSearchFiles_ValidInput()
    {
        // Создаем временную директорию и в ней тестовые файлы
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        File.WriteAllText(Path.Combine(tempDir, "file1.txt"), "");
        File.WriteAllText(Path.Combine(tempDir, "file2.txt"), "");
        File.WriteAllText(Path.Combine(tempDir, "file3.csv"), "");

        // Подменяем входной поток пользовательским вводом
        using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes($"{tempDir}{Environment.NewLine}txt"));
        Console.SetIn(new StreamReader(inputStream));

        // Перехватываем вывод программы
        var outputBuffer = new StringBuilder();
        Console.SetOut(new StringWriter(outputBuffer));

        // Запускаем программу
        Program.Main(Array.Empty<string>());

        // Получаем вывод программы
        string outputText = outputBuffer.ToString();

        // Завершаем программу и восстанавливаем стандартные потоки
        Console.SetIn(Console.In);
        Console.SetOut(Console.Out);

        // Проверяем, что программа выводит результаты поиска
        Assert.Contains(Path.Combine(tempDir, "file1.txt"), outputText);
        Assert.Contains(Path.Combine(tempDir, "file2.txt"), outputText);
        Assert.DoesNotContain(Path.Combine(tempDir, "file3.csv"), outputText);

        // Удаляем временную директорию
        Directory.Delete(tempDir, true);
    }

    [Fact]
    public void TestSearchFiles_InvalidFolder()
    {
        // Подменяем входной поток пользовательским вводом
        using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes($"nonexistent_folder{Environment.NewLine}txt"));
        Console.SetIn(new StreamReader(inputStream));

        // Перехватываем вывод программы
        var outputBuffer = new StringBuilder();
        Console.SetOut(new StringWriter(outputBuffer));

        // Запускаем программу
        Program.Main(Array.Empty<string>());

        // Получаем вывод программы
        string outputText = outputBuffer.ToString();

        // Завершаем программу и восстанавливаем стандартные потоки
        Console.SetIn(Console.In);
        Console.SetOut(Console.Out);

        // Проверяем, что программа выводит сообщение об ошибке
        Assert.Contains("Папка не существует.", outputText);
    }

    [Fact]
    public void TestSearchFiles_InvalidArguments()
    {
        // Подменяем входной поток пользовательским вводом
        using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes($"{Environment.NewLine}{Environment.NewLine}"));
        Console.SetIn(new StreamReader(inputStream));

        // Перехватываем вывод программы
        var outputBuffer = new StringBuilder();
        Console.SetOut(new StringWriter(outputBuffer));

        // Запускаем программу
        Program.Main(Array.Empty<string>());

        // Получаем вывод программы
        string outputText = outputBuffer.ToString();

        // Завершаем программу и восстанавливаем стандартные потоки
        Console.SetIn(Console.In);
        Console.SetOut(Console.Out);

        // Проверяем, что программа выводит сообщение об использовании
        Assert.Contains("Введите путь к папке:", outputText);
        Assert.Contains("Введите расширение файлов (например, 'txt'):", outputText);
    }
}
