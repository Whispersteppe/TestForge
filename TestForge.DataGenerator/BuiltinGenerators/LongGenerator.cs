namespace TestForge.DataGenerator.BuiltinGenerators;

public class LongGenerator : IGenerator<long>
{
    long? _minValue;
    long? _maxValue;
    public LongGenerator(long? minValue = null, long? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual long Generate(GeneratorContext context)
    {
            return context.Random.NextInt64(_minValue ?? long.MinValue, _maxValue ?? long.MaxValue);
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<long> GenerateMany(GeneratorContext context, int count)
    {
        List<long> result = new List<long>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    List<object> IGenerator.GenerateMany(GeneratorContext context, int count)
    {
        List<object> result = new List<object>();
        for (long i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }
}





