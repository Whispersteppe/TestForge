namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates double values
/// </summary>
public class DoubleGenerator : IGenerator<double>
{
    double? _minValue;
    double? _maxValue;
    public DoubleGenerator(double? minValue = null, double? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    /// <summary>
    /// generates a double value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual double Generate(GeneratorContext context)
    {

        var randomDouble = context.Random.NextDouble();

        var fullRangeDouble = randomDouble * (_maxValue.GetValueOrDefault(1.0) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

        //  now map this over the range.
        return fullRangeDouble;
    }

    /// <summary>
    /// generates a double value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
        return Generate(context);
    }

    /// <summary>
    /// generates many double values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<double> GenerateMany(GeneratorContext context, int count)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generates many double values
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





