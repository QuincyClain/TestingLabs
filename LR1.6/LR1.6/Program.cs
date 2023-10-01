using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LR1._6;
public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to the File Downloader!");
        Console.Write("Enter the URL of the file you want to download: ");
        string url = Console.ReadLine();

        Console.Write("Enter the folder where you want to save the file: ");
        string outputFolder = Console.ReadLine();

        try
        {
            if (IsValidUrl(url))
            {
                await DownloadFileAsync(url, outputFolder);
                Console.WriteLine("File downloaded successfully.");
            }
            else
            {
                Console.WriteLine("Invalid URL.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid input: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO error: {ex.Message}");
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Web error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static async Task DownloadFileAsync(string url, string outputFolder)
    {
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        string fileName = Path.Combine(outputFolder, Path.GetFileName(url));

        using (var client = new WebClient())
        {
            await client.DownloadFileTaskAsync(url, fileName);
        }
    }

    public static bool IsValidUrl(string url)
    {
        // Use a regular expression to validate URL format
        string urlPattern = @"^(https?://)([a-zA-Z0-9.-]+)(\.[a-zA-Z]{2,6})(:[0-9]+)?(/[a-zA-Z0-9.-]*)*$";
        return Regex.IsMatch(url, urlPattern);
    }
}
