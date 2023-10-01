namespace LR1._5_UserInput_;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите путь к папке: ");
        string folderPath = Console.ReadLine();

        Console.Write("Введите расширение файлов (например, 'txt'): ");
        string fileExtension = Console.ReadLine();

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Папка не существует.");
            return;
        }

        SearchFiles(folderPath, fileExtension);
    }

    public static void SearchFiles(string folderPath, string fileExtension)
    {
        try
        {
            foreach (string filePath in Directory.GetFiles(folderPath, $"*.{fileExtension}", SearchOption.AllDirectories))
            {
                Console.WriteLine(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}

