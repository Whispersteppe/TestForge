using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generates char values
/// </summary>
public class CharGenerator : IGenerator<char>
{
    string _validCharSet;

    public CharGenerator(string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        _validCharSet = validCharSet;

        if (_validCharSet.Length == 0) throw new ArgumentException("validCharSet cannot be empty");
    }

    /// <summary>
    /// generate a char
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual char Generate(GeneratorContext context)
    {
            char nextChar = _validCharSet[context.Random.Next(_validCharSet.Length)];
            return nextChar;
    }

    /// <summary>
    /// generate a char
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }

    /// <summary>
    /// generate many char values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<char> GenerateMany(GeneratorContext context, int count)
    {
        List<char> result = new List<char>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many char values
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





