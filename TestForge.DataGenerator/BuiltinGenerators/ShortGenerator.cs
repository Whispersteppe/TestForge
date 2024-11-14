namespace TestForge.DataGenerator.BuiltinGenerators;

public class ShortGenerator : IGenerator<short>
{
    short? _minValue;
    short? _maxValue;
    public ShortGenerator(short? minValue = null, short? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual short Generate(GeneratorContext context)
    {
            return (short)context.Random.Next(_minValue ?? short.MinValue, _maxValue ?? short.MaxValue);
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<short> GenerateMany(GeneratorContext context, int count)
    {
        List<short> result = new List<short>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

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





