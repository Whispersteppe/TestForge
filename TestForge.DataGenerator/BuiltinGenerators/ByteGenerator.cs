namespace TestForge.DataGenerator.BuiltinGenerators;

public class ByteGenerator : IGenerator<byte>
{
    byte? _minValue;
    byte? _maxValue;
    public ByteGenerator( byte? minValue = null, byte? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual byte Generate(GeneratorContext context)
    {
            return (byte)context.Random.Next(_minValue ?? byte.MinValue, _maxValue ?? byte.MaxValue);
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<byte> GenerateMany(GeneratorContext context, int count)
    {
        List<byte> result = new List<byte>();
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





