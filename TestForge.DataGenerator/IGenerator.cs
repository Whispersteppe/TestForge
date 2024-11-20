namespace TestForge.DataGenerator;

/// <summary>
/// inteface for all generators
/// </summary>
public interface IGenerator
{
    /// <summary>
    /// generate many items as objects
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<object> GenerateMany(GeneratorContext context, int count);

    /// <summary>
    /// generate a single object
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public object Generate(GeneratorContext context);
}

/// <summary>
/// generate items of type T
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenerator<T> : IGenerator
{
    /// <summary>
    /// generate many items of type T
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<T> GenerateMany(GeneratorContext context, int count);

    /// <summary>
    /// generate a single item of type T
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    new public T Generate(GeneratorContext context);
}
