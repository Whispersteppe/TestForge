using System;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class FloatGenerator : IGenerator<float>
{
    GeneratorContext _context;
    float? _minValue;
    float? _maxValue;
    public FloatGenerator(GeneratorContext context, float? minValue = null, float? maxValue = null)
    {
        _context = context;
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual float Generate
    {
        get
        {
            var randomFloat = _context.Random.NextSingle();

            var fullRangeFloat = randomFloat * (_maxValue.GetValueOrDefault(1) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

            //  now map this over the range.
            return fullRangeFloat;

        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<float> GenerateMany(int count)
    {
        List<float> result = new List<float>();
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





