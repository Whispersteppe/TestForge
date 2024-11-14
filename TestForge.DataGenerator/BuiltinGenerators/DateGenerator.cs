namespace TestForge.DataGenerator.BuiltinGenerators;

public class DateGenerator : IGenerator<DateTime>
{
    DateTime? _minValue;
    DateTime? _maxValue;
    public DateGenerator(DateTime? minValue = null, DateTime? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual DateTime Generate(GeneratorContext context)
    {
            return new DateTime(context.Random.NextInt64((_minValue ?? DateTime.MinValue).Ticks, (_maxValue ?? DateTime.MaxValue).Ticks));
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<DateTime> GenerateMany(GeneratorContext context, int count)
    {
        List<DateTime> result = new List<DateTime>();
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





