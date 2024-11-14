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
    public Random Random => _random;
    BuiltinGeneratorSet _builtin;
    public NamedGenerators Generators { get; private set; } = new NamedGenerators();
    public ContextData Data { get; private set; } = new ContextData();

    public GeneratorContext() 
        : this(new System.Random().Next())
    { 
    }

    public GeneratorContext(int seed) 
    { 
        _random = new Random(seed);
        _builtin = new BuiltinGeneratorSet(this);
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
