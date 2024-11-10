namespace TestForge.DataGenerator.BuiltinGenerators;

public class EnumGenerator<T> : IGenerator<T> where T: Enum
{
    GeneratorContext _context;
    List<T> _selection;
    public EnumGenerator(GeneratorContext context)
    {
        _context = context;
        _selection = new List<T>();

        foreach (T item in Enum.GetValues(typeof(T)))
        {
            _selection.Add(item);
        }
    }


    public virtual T Generate
    {
        get
        {
            T selectedItem = _selection[_context.Random.Next(_selection.Count)];
            return selectedItem;
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
        List<T> result = new List<T>();
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





