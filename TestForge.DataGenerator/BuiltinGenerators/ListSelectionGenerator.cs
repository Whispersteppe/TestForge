namespace TestForge.DataGenerator.BuiltinGenerators;

public class ListSelectionGenerator<T> : IGenerator<T>
{
    List<T> _selection;
    public ListSelectionGenerator(params T[] items)
    {
        _selection = new List<T>(items);
    }


    public virtual T Generate(GeneratorContext context)
    {
            return context.Random.GetItems<T>(_selection.ToArray(), 1)[0];
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<T> GenerateMany(GeneratorContext context, int count)
    {
        return context.Random.GetItems<T>(_selection.ToArray(), count).ToList();
    }

    List<object> IGenerator.GenerateMany(GeneratorContext context, int count)
    {
        var items = context.Random.GetItems<T>(_selection.ToArray(), count).ToList();

        List<object> result = new List<object>();

        foreach(var item in items) 
        {
            result.Add(item);
        }

        return result;
    }
}





