using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._6.Tests;

public class UnitTest1
{
    [Fact]
    public async void TestDownloadFile_Success()
    {
        string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);

        string url = "https://www.example.com/index.html";
        string outputFolder = tempDir;

        await Program.DownloadFileAsync(url, outputFolder);

        string downloadedFilePath = Path.Combine(outputFolder, "index.html");

        Assert.True(File.Exists(downloadedFilePath));

        // Clean up
        Directory.Delete(tempDir, true);
    }

    [Fact]
    public async void TestDownloadFile_InvalidOutputFolder()
    {
        string invalidFolder = "invalid-folder"; // Invalid folder path
        string url = "https://www.example.com/index.html";

        try
        {
            await Program.DownloadFileAsync(url, invalidFolder);
        }
        catch (IOException ex)
        {
            Assert.Contains("Output folder does not exist", ex.Message);
        }
    }

    [Fact]
    public void TestIsValidUrl_ValidUrl()
    {
        string validUrl = "https://www.example.com/index.html";
        bool isValid = Program.IsValidUrl(validUrl);
        Assert.True(isValid);
    }

    [Fact]
    public void TestIsValidUrl_InvalidUrl()
    {
        string invalidUrl = "invalid-url"; // Invalid URL
        bool isValid = Program.IsValidUrl(invalidUrl);
        Assert.False(isValid);
    }
}
