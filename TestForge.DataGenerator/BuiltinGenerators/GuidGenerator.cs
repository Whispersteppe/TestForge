namespace TestForge.DataGenerator.BuiltinGenerators;

public class GuidGenerator : IGenerator<Guid>
{
    public GuidGenerator()
    {
    }


    public virtual Guid Generate(GeneratorContext context)
    {
            byte[] bytes = new byte[16];
            context.Random.NextBytes(bytes);
            Guid newGuid = new Guid(bytes);

            return newGuid;
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
        
    }


    public List<Guid> GenerateMany(GeneratorContext context, int count)
    {
        List<Guid> result = new List<Guid>();
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





