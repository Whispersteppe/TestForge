namespace TestForge.DataGenerator.BuiltinGenerators;

public class ShortGenerator : IGenerator<short>
{
    GeneratorContext _context;
    short? _minValue;
    short? _maxValue;
    public ShortGenerator(GeneratorContext context, short? minValue = null, short? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual short Generate
    {
        get
        {
            return (short)_context.Random.Next(_minValue ?? short.MinValue, _maxValue ?? short.MaxValue);
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<short> GenerateMany(int count)
    {
        List<short> result = new List<short>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate);
        }
        return result;
    }

    List<object> IGenerator.GenerateMany(int count)
    {
        List<object> result = new List<object>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate);
        }
        return result;
    }
}





