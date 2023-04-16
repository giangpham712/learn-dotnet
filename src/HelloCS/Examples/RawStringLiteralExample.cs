namespace HelloCS.Examples;

public static class RawStringLiteralExample
{
    public static async Task Run()
    {
        var xml = """
                  <person age="50">
                    <first_name>Mark</first_name>
                  </person>  
                  """;
    }
}