namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates guid values
/// </summary>
public class GuidGenerator : IGenerator<Guid>
{
    public GuidGenerator()
    {
    }

    /// <summary>
    /// generate a guid value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual Guid Generate(GeneratorContext context)
    {
        byte[] bytes = new byte[16];
        context.Random.NextBytes(bytes);
        Guid newGuid = new Guid(bytes);

        return newGuid;

    }

    /// <summary>
    /// generate a guid value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
        return Generate(context);
    }

    /// <summary>
    /// generate many guid values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<Guid> GenerateMany(GeneratorContext context, int count)
    {
        List<Guid> result = new List<Guid>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many guid values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
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





