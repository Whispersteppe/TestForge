using TestForge.DataGenerator.Builder;
using TestForge.DataGenerator.BuiltinGenerators;

namespace TestForge.DataGenerator;

/// <summary>
/// a list of named generators
/// </summary>
public class NamedGenerators : Dictionary<string, IGenerator>, ICloneable
{
    public object Clone()
    {
        var cloned = new NamedGenerators();

        foreach (var key in Keys)
        {
            cloned[key] = this[key];
        }

        return cloned;
    }
}

/// <summary>
/// a list of context data
/// </summary>
public class ContextData : Dictionary<string, object>, ICloneable
{
    public object Clone()
    {
        var cloned = new ContextData();

        foreach(var key in Keys)
        {
            cloned[key] = this[key];
        }

        return cloned;
    }
}

/// <summary>
/// the context of the generator
/// </summary>
public class GeneratorContext : ICloneable
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

    /// <summary>
    /// clone the current context
    /// </summary>
    /// <returns></returns>
    public object Clone()
    {
        GeneratorContext childContext = (GeneratorContext)MemberwiseClone();

        childContext.Generators = (NamedGenerators)Generators.Clone();
        childContext.Data = (ContextData)Data.Clone();

        return childContext;
    }
}
