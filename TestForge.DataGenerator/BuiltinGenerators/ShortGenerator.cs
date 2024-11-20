namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate short values
/// </summary>
public class ShortGenerator : IGenerator<short>
{
    short? _minValue;
    short? _maxValue;

    public ShortGenerator(short? minValue = null, short? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }

    /// <summary>
    /// generate a short value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual short Generate(GeneratorContext context)
    {
            return (short)context.Random.Next(_minValue ?? short.MinValue, _maxValue ?? short.MaxValue);
        
    }

    /// <summary>
    /// generate a short value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many short values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<short> GenerateMany(GeneratorContext context, int count)
    {
        List<short> result = new List<short>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many short values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    List<object> IGenerator.GenerateMany(GeneratorContext context, int count)
    {
        List<object> result = new List<object>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }
}





