namespace LR1._5;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: dotnet run <folderPath> <fileExtension>");
                return;
            }

            string folderPath = args[0];
            string fileExtension = args[1];

            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException("Folder does not exist.");
            }

            SearchFiles(folderPath, fileExtension);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void SearchFiles(string folderPath, string fileExtension)
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
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

