namespace TestForge.DataGenerator.BuiltinGenerators;

public class GuidGenerator : IGenerator<Guid>
{
    GeneratorContext _context;
    public GuidGenerator(GeneratorContext context)
    {
        _context = context;
    }


    public virtual Guid Generate
    {
        get
        {
            byte[] bytes = new byte[16];
            _context.Random.NextBytes(bytes);
            Guid newGuid = new Guid(bytes);

            return newGuid;
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<Guid> GenerateMany(int count)
    {
        List<Guid> result = new List<Guid>();
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





