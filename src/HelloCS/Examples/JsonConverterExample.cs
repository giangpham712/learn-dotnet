using System.Text.Json;
using System.Text.Json.Serialization;

namespace HelloCS.Examples;

public static class JsonConverterExample
{
    public static async Task Run()
    {
        var json = """
              {  
                "name": "Foo 1",
                "description": "Description for Foo 1"
              }
           """;

        try
        {
            var foo = JsonSerializer.Deserialize<Foo>(json, new JsonSerializerOptions()
            {
                Converters = { new FooConverter() }
            });

            Console.WriteLine(foo);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    class FooConverter : JsonConverter<Foo>
    {
        public override Foo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
        
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Foo value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

    class Foo
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}