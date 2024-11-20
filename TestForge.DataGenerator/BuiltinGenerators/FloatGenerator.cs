namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate float values
/// </summary>
public class FloatGenerator : IGenerator<float>
{
    float? _minValue;
    float? _maxValue;
    public FloatGenerator(float? minValue = null, float? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }

    /// <summary>
    /// generate a float value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual float Generate(GeneratorContext context)
    {
        var randomFloat = context.Random.NextSingle();

        var fullRangeFloat = randomFloat * (_maxValue.GetValueOrDefault(1) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

        //  now map this over the range.
        return fullRangeFloat;
    }

    /// <summary>
    /// generate a float value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
        return Generate(context);
    }

    /// <summary>
    /// generate many float values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<float> GenerateMany(GeneratorContext context, int count)
    {
        List<float> result = new List<float>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many float values
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





