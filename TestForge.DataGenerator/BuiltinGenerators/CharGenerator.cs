using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class CharGenerator : IGenerator<char>
{
    string _validCharSet;

    public CharGenerator(string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        _validCharSet = validCharSet;

        if (_validCharSet.Length == 0) throw new ArgumentException("validCharSet cannot be empty");
    }


    public virtual char Generate(GeneratorContext context)
    {
            char nextChar = _validCharSet[context.Random.Next(_validCharSet.Length)];
            return nextChar;
    }

    object IGenerator.Generate(GeneratorContext context)
    {
            return Generate(context);
    }


    public List<char> GenerateMany(GeneratorContext context, int count)
    {
        List<char> result = new List<char>();
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





