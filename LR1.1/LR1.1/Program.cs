namespace LR1._1;
public class Program
{
    static void Main()
    {
        PrintHelloWorld();
        PrintRandomExclamationMarks();
    }

    public static void PrintHelloWorld()
    {
        Console.WriteLine("Hello, world!");
        Console.WriteLine("Andhiagain!");
    }

    public static void PrintRandomExclamationMarks()
    {
        Random random = new Random();
        int exclamationCount = random.Next(5, 51);

        string exclamationMarks = new string('!', exclamationCount);
        Console.WriteLine(exclamationMarks);
    }
}

