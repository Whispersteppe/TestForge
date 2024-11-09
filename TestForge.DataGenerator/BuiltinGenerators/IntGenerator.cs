namespace TestForge.DataGenerator.BuiltinGenera;

public class IntGenerator : IGenerator<int>
{
    GeneratorContext _context;
    int? _minValue;
    int? _maxValue;
    public IntGenerator(GeneratorContext context, int? minValue = null, int? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual int Generate
    {
        get
        {
            return _context.Random.Next(_minValue ?? int.MinValue, _maxValue ?? int.MaxValue);
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public int GenerateMany(int count)
    {
        throw new NotImplementedException();
    }

    public T GenerateMany<T>(int count)
    {
        throw new NotImplementedException();
    }
}





