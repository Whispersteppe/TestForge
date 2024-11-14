namespace TestForge.DataGenerator.BuiltinGenerators;

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


    public virtual T Generate(GeneratorContext context)
    {
        
            T selectedItem = _selection[context.Random.Next(_selection.Count)];
            return selectedItem;
        
    }

    object IGenerator.Generate(GeneratorContext context)
    {
        
            return Generate(context);
        
    }


    public List<T> GenerateMany(GeneratorContext context, int count)
    {
        List<T> result = new List<T>();
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





