using System;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class DoubleGenerator : IGenerator<double>
{
    double? _minValue;
    double? _maxValue;
    public DoubleGenerator(double? minValue = null, double? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual double Generate(GeneratorContext context)
    {
        {
            var randomDouble = context.Random.NextDouble();

            var fullRangeDouble = randomDouble * (_maxValue.GetValueOrDefault(1.0) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

            //  now map this over the range.
            return fullRangeDouble;
            
        }
    }

    object IGenerator.Generate(GeneratorContext context)
    {
        {
            return Generate(context);
        }
    }


    public List<double> GenerateMany(GeneratorContext context, int count)
    {
        List<double> result = new List<double>();
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





