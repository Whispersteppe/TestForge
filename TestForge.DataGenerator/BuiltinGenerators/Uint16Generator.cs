namespace TestForge.DataGenerator.BuiltinGenerators;

public class UInt16Generator : IGenerator<UInt16>
{
    GeneratorContext _context;
    UInt16? _minValue;
    UInt16? _maxValue;
    public UInt16Generator(GeneratorContext context, UInt16? minValue = null, UInt16? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual UInt16 Generate
    {
        get
        {
            return Convert.ToUInt16( _context.Random.Next(Convert.ToInt32(_minValue ?? UInt16.MinValue), Convert.ToInt32(_maxValue ?? UInt16.MaxValue)));
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<UInt16> GenerateMany(int count)
    {
        List<UInt16> result = new List<UInt16>();
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





