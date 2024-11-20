using TestForge.DataGenerator.Builder;
using TestForge.DataGenerator.BuiltinGenerators;

namespace TestForge.DataGenerator;

/// <summary>
/// a list of named generators
/// </summary>
public class NamedGenerators : Dictionary<string, IGenerator>
{
}

/// <summary>
/// a list of context data
/// </summary>
public class ContextData : Dictionary<string, object>
{
}

/// <summary>
/// the context of the generator
/// </summary>
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

    /// <summary>
    /// create a child context based on this context
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// creates a class builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ClassGeneratorBuilder<T> Build<T>() where T: class
    {
        return new ClassGeneratorBuilder<T>(this);
    }

    /// <summary>
    /// access the builtin generators
    /// </summary>
    public BuiltinGeneratorSet Builtin
    { 
        get
        {
            return _builtin;
        }
    }
}
