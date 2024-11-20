using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// generate string values
/// </summary>
public class StringGenerator : IGenerator<string>
{
    int _minLength;
    int _maxLength;
    string _validCharSet;

    public StringGenerator(int minLength = 1, int maxLength = 25, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        _minLength = minLength;
        _maxLength = maxLength;
        _validCharSet = validCharSet;

        if (_minLength <= 0) throw new ArgumentException("minlenth must be larger than zero");
        if (_minLength > maxLength) throw new ArgumentException("maxLength must be larger than minLength");
        if (_validCharSet.Length == 0) throw new ArgumentException("validCharSet cannot be empty");
    }

    /// <summary>
    /// generate a string value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public virtual string Generate(GeneratorContext context)
    {
            int targetLength = context.Random.Next(_minLength, _maxLength);
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0;i < targetLength;i++)
            {
                char nextChar = _validCharSet[context.Random.Next(_validCharSet.Length)];
                stringBuilder.Append(nextChar);
            }

            return stringBuilder.ToString();

        
    }

    /// <summary>
    /// generate a string value
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
        
    }

    /// <summary>
    /// generate manu string values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<string> GenerateMany(GeneratorContext context, int count)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < count; i++)
        {
            result.Add(Generate(context));
        }
        return result;
    }

    /// <summary>
    /// generate many string values
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





