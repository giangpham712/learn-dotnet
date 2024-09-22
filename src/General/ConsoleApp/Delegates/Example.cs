using System.Collections;
using System.Linq.Expressions;

namespace ConsoleApp.Delegates;

public static class Example
{
    public static void Run()
    {
        string GetString() => "";

        void A(Func<string> action) { }

        A(GetString);
        A(() => GetString());
        
        A(B);
        A(() => B());
    }

    private static string B()
    {
        return string.Empty;
    }
}