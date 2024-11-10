namespace TestForge.DataGenerator.BuiltinGenerators;

public class LongGenerator : IGenerator<long>
{
    GeneratorContext _context;
    long? _minValue;
    long? _maxValue;
    public LongGenerator(GeneratorContext context, long? minValue = null, long? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual long Generate
    {
        get
        {
            return _context.Random.NextInt64(_minValue ?? long.MinValue, _maxValue ?? long.MaxValue);
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<long> GenerateMany(int count)
    {
        List<long> result = new List<long>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate);
        }
        return result;
    }

    List<object> IGenerator.GenerateMany(int count)
    {
        List<object> result = new List<object>();
        for (long i = 0; i < count; i++)
        {
            result.Add(Generate);
        }
        return result;
    }
}





