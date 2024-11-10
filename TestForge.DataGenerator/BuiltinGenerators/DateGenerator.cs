﻿namespace TestForge.DataGenerator.BuiltinGenerators;

public class DateGenerator : IGenerator<DateTime>
{
    GeneratorContext _context;
    DateTime? _minValue;
    DateTime? _maxValue;
    public DateGenerator(GeneratorContext context, DateTime? minValue = null, DateTime? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual DateTime Generate
    {
        get
        {
            return new DateTime(_context.Random.NextInt64((_minValue ?? DateTime.MinValue).Ticks, (_maxValue ?? DateTime.MaxValue).Ticks));
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<DateTime> GenerateMany(int count)
    {
        List<DateTime> result = new List<DateTime>();
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





