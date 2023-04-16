using static System.Console;

namespace HelloCS.Examples;

public static class PatternMatchingExample
{
    public static async Task Run()
    {
        WriteLine("Running PatternMatchingExample");
        
        object o = 3;
        int j = 4;

        if (o is int i)
        {
            WriteLine($"{i} x {j} = {i * j}");
        }
        else
        {
            WriteLine("o is not an int so it cannot multiply!");
        }
    }
}