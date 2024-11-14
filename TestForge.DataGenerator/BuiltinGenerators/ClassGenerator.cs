using System.Reflection;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class ClassGenerator<T> : IGenerator<T> where T : class
{

    internal Func<GeneratorContext, T>? _constructorFunction;
    internal List<PropertyGenerator> _propertyGenerators;

    public ClassGenerator()
    {
        _propertyGenerators = new List<PropertyGenerator>();
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

    public T Generate(GeneratorContext context)
    {
        GeneratorContext childContext = context.SpawnChildContext();

        T instance;
        if (_constructorFunction != null)
        {
            instance = _constructorFunction.Invoke(childContext);
        }
        else
        {
            instance = Activator.CreateInstance(typeof(T)) as T;
        }

        foreach (var property in _propertyGenerators)
        {
            //  find the property
            PropertyInfo propInfo = typeof(T).GetProperty(property.PropertyName);
            if (propInfo != null)
            {
                propInfo.SetValue(instance, property.GetValue(childContext));
            }
        }

        return instance;
    }

    object IGenerator.Generate(GeneratorContext context)
    {
        return Generate(context);
    }
    /*
     * tree of stuff on the context
     * Context
     *      Builder
     *          Class Builder
     *              Property
     *                  Pre property function
     *                  post property function
     *              post create function
     *              pre create function
     */

}
