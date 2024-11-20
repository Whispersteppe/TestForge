namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate selections from a list
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListSelectionGenerator<T> : IGenerator<T>
{
    List<T> _selection;
    public ListSelectionGenerator(params T[] items)
    {
        _selection = new List<T>(items);
    }

    /// <summary>
    /// generate a list selection
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual T Generate(GeneratorContext context)
    {
            return context.Random.GetItems<T>(_selection.ToArray(), 1)[0];
    }

    /// <summary>
    /// generate a list selection
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many list selections
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<T> GenerateMany(GeneratorContext context, int count)
    {
        return context.Random.GetItems<T>(_selection.ToArray(), count).ToList();
    }

    /// <summary>
    /// generate many list selections
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    List<object> IGenerator.GenerateMany(GeneratorContext context, int count)
    {
        var items = context.Random.GetItems<T>(_selection.ToArray(), count).ToList();

        List<object> result = new List<object>();

        foreach (var item in items)
        {
            result.Add(item);
        }

        return result;
    }
}





