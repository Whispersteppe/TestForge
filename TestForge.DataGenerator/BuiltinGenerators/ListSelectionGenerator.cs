namespace TestForge.DataGenerator.BuiltinGenerators;

public class ListSelectionGenerator<T> : IGenerator<T>
{
    GeneratorContext _context;
    List<T> _selection;
    public ListSelectionGenerator(GeneratorContext context,params T[] items)
    {
        _context = context;
        _selection = new List<T>(items);
    }


    public virtual T Generate
    {
        get
        {
            return _context.Random.GetItems<T>(_selection.ToArray(), 1)[0];
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<T> GenerateMany(int count)
    {
        return _context.Random.GetItems<T>(_selection.ToArray(), count).ToList();
    }

    List<object> IGenerator.GenerateMany(int count)
    {
        var items = _context.Random.GetItems<T>(_selection.ToArray(), count).ToList();

        List<object> result = new List<object>();

        foreach(var item in items) 
        {
            result.Add(item);
        }

        return result;
    }
}





