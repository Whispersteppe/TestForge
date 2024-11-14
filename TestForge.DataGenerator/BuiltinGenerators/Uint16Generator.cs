namespace TestForge.DataGenerator.BuiltinGenerators;

public class UInt16Generator : IGenerator<UInt16>
{
    UInt16? _minValue;
    UInt16? _maxValue;
    public UInt16Generator(UInt16? minValue = null, UInt16? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual UInt16 Generate(GeneratorContext context)
    {
            return Convert.ToUInt16( context.Random.Next(Convert.ToInt32(_minValue ?? UInt16.MinValue), Convert.ToInt32(_maxValue ?? UInt16.MaxValue)));
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<UInt16> GenerateMany(GeneratorContext context, int count)
    {
        List<UInt16> result = new List<UInt16>();
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





