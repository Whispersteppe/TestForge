namespace TestForge.DataGenerator.BuiltinGenerators;

public class ByteGenerator : IGenerator<byte>
{
    GeneratorContext _context;
    byte? _minValue;
    byte? _maxValue;
    public ByteGenerator(GeneratorContext context, byte? minValue = null, byte? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual byte Generate
    {
        get
        {
            return (byte)_context.Random.Next(_minValue ?? byte.MinValue, _maxValue ?? byte.MaxValue);
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<byte> GenerateMany(int count)
    {
        List<byte> result = new List<byte>();
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





