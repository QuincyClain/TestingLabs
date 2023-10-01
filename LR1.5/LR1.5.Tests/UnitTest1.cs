using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._5.Tests;

public class UnitTest1
{
    [Fact]
    public void TestSearchFiles_ValidInput()
    {
        // Создаем временную директорию и в ней тестовые файлы
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        File.WriteAllText(Path.Combine(tempDir, "file1.txt"), "");
        File.WriteAllText(Path.Combine(tempDir, "file2.txt"), "");
        File.WriteAllText(Path.Combine(tempDir, "file3.csv"), "");

        // Запускаем программу с временной директорией и расширением "txt"
        string[] args = { tempDir, "txt" };
        Program.Main(args);

        // Завершаем программу и проверяем, что она вывела результаты в консоль
        string output = Console.Out.ToString();
        Assert.Contains(Path.Combine(tempDir, "file1.txt"), output);
        Assert.Contains(Path.Combine(tempDir, "file2.txt"), output);
        Assert.DoesNotContain(Path.Combine(tempDir, "file3.csv"), output);

        // Удаляем временную директорию
        Directory.Delete(tempDir, true);
    }

    [Fact]
    public void TestSearchFiles_InvalidFolder()
    {
        // Запоминаем стандартный поток вывода
        var originalConsoleOut = Console.Out;
        try
        {
            // Создаем StringWriter для перехвата вывода
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                // Запускаем программу с несуществующей директорией
                string[] args = { "nonexistent_folder", "txt" };
                Program.Main(args);

                // Получаем вывод программы
                string output = writer.ToString();

                // Проверяем, что вывод содержит сообщение об ошибке
                Assert.Contains("An error occurred", output);
                Assert.Contains("The folder does not exist", output);
            }
        }
        finally
        {
            // Восстанавливаем стандартный поток вывода
            Console.SetOut(originalConsoleOut);
        }
    }

    [Fact]
    public void TestSearchFiles_InvalidArguments()
    {
        // Запускаем программу без аргументов
        string[] args = { };
        Program.Main(args);

        // Завершаем программу и проверяем, что она вывела сообщение об использовании
        string output = Console.Out.ToString();
        Assert.Contains("Usage: dotnet run <folderPath> <fileExtension>", output);
    }
}
