using TestForge.DataGenerator.Builder;
using TestForge.DataGenerator.BuiltinGenerators;

namespace TestForge.DataGenerator;

public class GeneratorContext
{
    private readonly Random _random;
    public Random Random => _random;
    BuiltinGeneratorSet _builtin;
    Dictionary<string, IGenerator> _namedGenerators = new Dictionary<string, IGenerator>();
    Dictionary<string, object> _contextData = new Dictionary<string, object>();


    public GeneratorContext() 
        : this((new System.Random().Next()))
    { 
    }

    public GeneratorContext(int seed) 
    { 
        _random = new Random(seed);
        _builtin = new BuiltinGeneratorSet(this);
    }

    public ClassGenerator<T> Build<T>() where T: class
    {
        return new ClassGenerator<T>(this);
    }

    public BuiltinGeneratorSet Builtin
    { 
        get
        {
            return _builtin;
        }
    }

    public IGenerator GetNamedGenerator(string name)
    {
        return _namedGenerators[name];
    }

    public void SetNamedGenerator(string name, IGenerator generator)
    {
        _namedGenerators[name] = generator;
    }

    public IGenerator GetNamedGenerator(Type type)
    {
        throw new NotImplementedException();
    }

    public object GetData(string name)
    {
        return _contextData[name];
    }

    public void SetData(string name, object data)
    { 
        _contextData[name] = data;
    }
}
