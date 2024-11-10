using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class BoolGenerator : IGenerator<bool>
{
    GeneratorContext _context;

    public BoolGenerator(GeneratorContext context)
    {
        _context = context;
    }


    public virtual bool Generate
    {
        get
        {
            bool nextBool = _context.Random.Next(1) == 1;
            return nextBool;
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<bool> GenerateMany(int count)
    {
        List<bool> result = new List<bool>();
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





