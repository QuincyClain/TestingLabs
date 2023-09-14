using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace LR1._1.XUnitTests;

public class UnitTest1
{
    [Fact]
    public void TestPrintHelloWorld()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw); // Перехват вывода в консоль
            Program.PrintHelloWorld();
            string printedOutput = sw.ToString().Trim();
            string expectedOutput = "Hello, world!\nAndhiagain!";

            Assert.Equal(expectedOutput, printedOutput);
        }
    }

    [Fact]
    public void TestPrintRandomExclamationMarks()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw); // Перехват вывода в консоль
            Program.PrintRandomExclamationMarks();
            string printedOutput = sw.ToString().Trim();

            Assert.NotEmpty(printedOutput);
            Assert.Matches("^!{5,50}$", printedOutput); // Проверка количества восклицательных знаков
        }
    }
}
