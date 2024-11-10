using System;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class DoubleGenerator : IGenerator<double>
{
    GeneratorContext _context;
    double? _minValue;
    double? _maxValue;
    public DoubleGenerator(GeneratorContext context, double? minValue = null, double? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual double Generate
    {
        get
        {
            var randomDouble = _context.Random.NextDouble();

            var fullRangeDouble = randomDouble * (_maxValue.GetValueOrDefault(1.0) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

            //  now map this over the range.
            return fullRangeDouble;
            
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<double> GenerateMany(int count)
    {
        List<double> result = new List<double>();
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





