namespace TestForge.DataGenerator.BuiltinGenerators;

public class IntGenerator : IGenerator<int>
{
    int? _minValue;
    int? _maxValue;
    public IntGenerator(int? minValue = null, int? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;  
    }


    public virtual int Generate(GeneratorContext context)
    {
            return context.Random.Next(_minValue ?? int.MinValue, _maxValue ?? int.MaxValue);
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
        
    }


    public List<int> GenerateMany(GeneratorContext context, int count)
    {
        List<int> result = new List<int>();
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





