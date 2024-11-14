using System;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class FloatGenerator : IGenerator<float>
{
    float? _minValue;
    float? _maxValue;
    public FloatGenerator(float? minValue = null, float? maxValue = null)
    {
        _minValue = minValue;
        _maxValue = maxValue;
    }


    public virtual float Generate(GeneratorContext context)
    {
            var randomFloat = context.Random.NextSingle();

            var fullRangeFloat = randomFloat * (_maxValue.GetValueOrDefault(1) - _minValue.GetValueOrDefault(0)) + _minValue.GetValueOrDefault(0);

            //  now map this over the range.
            return fullRangeFloat;

        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
        {
            return Generate(context);
        }
    }


    public List<float> GenerateMany(GeneratorContext context, int count)
    {
        List<float> result = new List<float>();
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





