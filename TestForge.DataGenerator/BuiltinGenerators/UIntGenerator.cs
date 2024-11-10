namespace TestForge.DataGenerator.BuiltinGenerators;

public class UIntGenerator : IGenerator<uint>
{
    GeneratorContext _context;
    uint? _minValue;
    uint? _maxValue;
    public UIntGenerator(GeneratorContext context, uint? minValue = null, uint? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual uint Generate
    {
        get
        {
            return Convert.ToUInt32( _context.Random.NextInt64(Convert.ToInt64(_minValue ?? uint.MinValue), Convert.ToInt64(_maxValue ?? uint.MaxValue)));
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<uint> GenerateMany(int count)
    {
        List<uint> result = new List<uint>();
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





