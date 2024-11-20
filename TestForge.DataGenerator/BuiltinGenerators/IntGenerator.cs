namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate int values
/// </summary>
public class IntGenerator : IGenerator<int>
{
    int? _minValue;
    int? _maxValue;
    public IntGenerator(int? minValue = null, int? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }

    /// <summary>
    /// generate an int value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual int Generate(GeneratorContext context)
    {
            return context.Random.Next(_minValue ?? int.MinValue, _maxValue ?? int.MaxValue);
        
    }

    /// <summary>
    /// generate an int value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
        
    }

    /// <summary>
    /// generate many int values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<int> GenerateMany(GeneratorContext context, int count)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many int values
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





