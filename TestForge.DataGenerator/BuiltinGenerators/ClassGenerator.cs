using System.Reflection;

namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate a specific class instance
/// </summary>
/// <typeparam name="T"></typeparam>
public class ClassGenerator<T> : IGenerator<T> where T : class
{

    internal Func<GeneratorContext, T>? _constructorFunction;
    internal List<PropertyGenerator> _propertyGenerators;

    public ClassGenerator()
    {
        _propertyGenerators = new List<PropertyGenerator>();
    }

    /// <summary>
    /// generate many class instances
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
    /// generate many class instances
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

    /// <summary>
    /// generate a class instance
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
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

    /// <summary>
    /// generate a class instances
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
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
