using TestForge.DataGenerator.Builder;
using TestForge.DataGenerator.BuiltinGenerators;

namespace TestForge.DataGenerator;

public class NamedGenerators : Dictionary<string, IGenerator>
{
}

public class ContextData : Dictionary<string, object>
{
}

public class GeneratorContext
{
    private readonly Random _random;
    public NamedGenerators Generators { get; private set; } = new NamedGenerators();
    public ContextData Data { get; private set; } = new ContextData();
    public int StartingSeed { get; private set; }
    public Random Random => _random;

    BuiltinGeneratorSet _builtin;

    public GeneratorContext() 
        : this(new System.Random().Next())
    { 
    }

    public GeneratorContext(int seed) 
    { 
        StartingSeed = seed;
        _random = new Random(seed);
        _builtin = new BuiltinGeneratorSet(this);
    }

    public GeneratorContext SpawnChildContext()
    {
        GeneratorContext childContext = new GeneratorContext(Random.Next());

        foreach(var key in Generators.Keys)
        {
            childContext.Generators[key] = Generators[key];
        }

        foreach(var key in Data.Keys)
        {
            childContext.Data[key] = Data[key];
        }

        return childContext;
    }

    public ClassGeneratorBuilder<T> Build<T>() where T: class
    {
        return new ClassGeneratorBuilder<T>(this);
    }

    public BuiltinGeneratorSet Builtin
    { 
        get
        {
            return _builtin;
        }
    }
}
