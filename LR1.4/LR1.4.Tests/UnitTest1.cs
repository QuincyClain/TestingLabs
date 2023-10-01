using System.Text;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._4.Tests;

public class UnitTest1
{
    [Fact]
    public void TestGenerateHTMLTable_FileExists()
    {
        // Arrange & Act
        Program.Main(null);

        // Assert
        Assert.True(File.Exists("table.html"));
    }

    [Fact]
    public void TestGenerateHTMLTable_CorrectTableStructure()
    {
        // Arrange & Act
        Program.Main(null);

        // Assert
        string htmlContent = File.ReadAllText("table.html");
        Assert.Contains("<table>", htmlContent);
        Assert.Contains("</table>", htmlContent);
        // Добавьте дополнительные проверки, если необходимо
    }

    [Fact]
    public void TestGenerateHTMLTable_BackgroundColorChange()
    {
        // Запустите вашу программу, которая создает HTML-файл
        Program.Main(null);

        // Проверьте, что файл существует
        Assert.True(File.Exists("table.html"));

        // Прочитайте содержимое файла и убедитесь, что оно содержит ожидаемые строки
        string htmlContent = File.ReadAllText("table.html", Encoding.UTF8);

        // Проверяем, что фон меняется от светлого к темному
        Assert.Contains("background-color:rgb(5,5,5);", htmlContent);
        Assert.Contains("background-color:rgb(30,30,30);", htmlContent);
        Assert.Contains("background-color:rgb(55,55,55);", htmlContent);
        Assert.Contains("background-color:rgb(80,80,80);", htmlContent);
        Assert.Contains("background-color:rgb(105,105,105);", htmlContent);
        Assert.Contains("background-color:rgb(130,130,130);", htmlContent);
        Assert.Contains("background-color:rgb(155,155,155);", htmlContent);
        Assert.Contains("background-color:rgb(180,180,180);", htmlContent);
        Assert.Contains("background-color:rgb(205,205,205);", htmlContent);
        Assert.Contains("background-color:rgb(230,230,230);", htmlContent);
    }
}
