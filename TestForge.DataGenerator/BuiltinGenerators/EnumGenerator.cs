namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates enums
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnumGenerator<T> : IGenerator<T> where T: Enum
{
    List<T> _selection;

    public EnumGenerator()
    {
        _selection = new List<T>();

        foreach (T item in Enum.GetValues(typeof(T)))
        {
            _selection.Add(item);
        }
    }

    /// <summary>
    /// generates an enum value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual T Generate(GeneratorContext context)
    {
        
            T selectedItem = _selection[context.Random.Next(_selection.Count)];
            return selectedItem;
        
    }

    /// <summary>
    /// generates an enum value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
        
            return Generate(context);
        
    }

    /// <summary>
    /// generates many enum values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<T> GenerateMany(GeneratorContext context, int count)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generates many enum values
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





