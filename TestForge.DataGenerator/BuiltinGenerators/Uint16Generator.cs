namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate uint16 values
/// </summary>
public class UInt16Generator : IGenerator<UInt16>
{
    UInt16? _minValue;
    UInt16? _maxValue;
    public UInt16Generator(UInt16? minValue = null, UInt16? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }

    /// <summary>
    /// generate a uint16 value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual UInt16 Generate(GeneratorContext context)
    {
            return Convert.ToUInt16( context.Random.Next(Convert.ToInt32(_minValue ?? UInt16.MinValue), Convert.ToInt32(_maxValue ?? UInt16.MaxValue)));
    }

    /// <summary>
    /// generate a uint16 value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many uint16 values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<UInt16> GenerateMany(GeneratorContext context, int count)
    {
        List<UInt16> result = new List<UInt16>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many uint16 values
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





