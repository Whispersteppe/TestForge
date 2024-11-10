﻿namespace TestForge.DataGenerator.BuiltinGenerators;

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


    public List<int> GenerateMany(int count)
    {
        List<int> result = new List<int>();
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





