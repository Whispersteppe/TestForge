namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate date values
/// </summary>
public class DateGenerator : IGenerator<DateTime>
{
    DateTime? _minValue;
    DateTime? _maxValue;
    public DateGenerator(DateTime? minValue = null, DateTime? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    /// <summary>
    /// generate a date value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual DateTime Generate(GeneratorContext context)
    {
            return new DateTime(context.Random.NextInt64((_minValue ?? DateTime.MinValue).Ticks, (_maxValue ?? DateTime.MaxValue).Ticks));
    }

    /// <summary>
    /// generate a date value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many date values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<DateTime> GenerateMany(GeneratorContext context, int count)
    {
        List<DateTime> result = new List<DateTime>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many date values
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





