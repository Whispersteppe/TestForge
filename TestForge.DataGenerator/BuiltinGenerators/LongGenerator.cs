namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate long values
/// </summary>
public class LongGenerator : IGenerator<long>
{
    long? _minValue;
    long? _maxValue;
    public LongGenerator(long? minValue = null, long? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    /// <summary>
    /// generate a long value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual long Generate(GeneratorContext context)
    {
            return context.Random.NextInt64(_minValue ?? long.MinValue, _maxValue ?? long.MaxValue);
        
    }

    /// <summary>
    /// generate a long value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many long values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<long> GenerateMany(GeneratorContext context, int count)
    {
        List<long> result = new List<long>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many long values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
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





