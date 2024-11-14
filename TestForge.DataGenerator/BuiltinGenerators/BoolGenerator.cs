using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class BoolGenerator : IGenerator<bool>
{

    public BoolGenerator()
    {
    }


    public virtual bool Generate(GeneratorContext context)
    {
            bool nextBool = context.Random.Next(1) == 1;
            return nextBool;
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<bool> GenerateMany(GeneratorContext context, int count)
    {
        List<bool> result = new List<bool>();
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





