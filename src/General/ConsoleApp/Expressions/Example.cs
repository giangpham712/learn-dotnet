using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp.Expressions;

[RPlotExporter]
public class Example
{
    private static readonly Expression<Func<Person, bool>> _expression = person => person.Age == 23;
    private static readonly Func<Person, bool> _compiledExpression = _expression.Compile();
    private static readonly Func<Person, bool> _func = e => e.Age == 23;
    
    private Person[] _people;
    
    [Params(100, 1000)]
    public int Count;

    [GlobalSetup]
    public void Setup()
    {
        _people = new Person[Count];
        for (int i = 0; i < Count; i++)
        {
            _people[i] = new Person { Age = i };
        }
        
    }
    
    [Benchmark]
    public List<Person> Expression() => _people.AsQueryable().Where(_expression).ToList();

    [Benchmark]
    public List<Person> CompiledExpression() => _people.Where(_compiledExpression).ToList();
    
    [Benchmark]
    public List<Person> Func() => _people.Where(_func).ToList();
    
    [Benchmark]
    public List<Person> Func2() => _people.Where(e => e.Age == 23).ToList();
}