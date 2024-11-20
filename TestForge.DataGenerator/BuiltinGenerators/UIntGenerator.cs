namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates uint values
/// </summary>
public class UIntGenerator : IGenerator<uint>
{
    uint? _minValue;
    uint? _maxValue;
    public UIntGenerator(uint? minValue = null, uint? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }

    /// <summary>
    /// generate a uint value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual uint Generate(GeneratorContext context)
    {
            return Convert.ToUInt32( context.Random.NextInt64(Convert.ToInt64(_minValue ?? uint.MinValue), Convert.ToInt64(_maxValue ?? uint.MaxValue)));
    }

    /// <summary>
    /// generate a uint value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many uint values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<uint> GenerateMany(GeneratorContext context, int count)
    {
        List<uint> result = new List<uint>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many uint values
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





