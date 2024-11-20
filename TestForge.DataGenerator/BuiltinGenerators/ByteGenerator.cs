namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates bytes
/// </summary>
public class ByteGenerator : IGenerator<byte>
{
    byte? _minValue;
    byte? _maxValue;
    public ByteGenerator( byte? minValue = null, byte? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }

    /// <summary>
    /// generate a byte
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual byte Generate(GeneratorContext context)
    {
            return (byte)context.Random.Next(_minValue ?? byte.MinValue, _maxValue ?? byte.MaxValue);
    }

    /// <summary>
    /// generate a byte
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many bytes
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<byte> GenerateMany(GeneratorContext context, int count)
    {
        List<byte> result = new List<byte>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many bytes
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





