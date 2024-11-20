namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// Generates a boolean
/// </summary>
public class BoolGenerator : IGenerator<bool>
{

    public BoolGenerator()
    {
    }

    /// <summary>
    /// generate a boolean
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual bool Generate(GeneratorContext context)
    {
            bool nextBool = context.Random.Next(1) == 1;
            return nextBool;
        
    }

    /// <summary>
    /// generate a boolean
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many booleans
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<bool> GenerateMany(GeneratorContext context, int count)
    {
        List<bool> result = new List<bool>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many booleans
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





