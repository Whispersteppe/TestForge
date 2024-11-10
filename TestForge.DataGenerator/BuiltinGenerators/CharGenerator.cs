using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class CharGenerator : IGenerator<char>
{
    GeneratorContext _context;
    string _validCharSet;

    public CharGenerator(GeneratorContext context, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        _context = context;
        _validCharSet = validCharSet;

        if (_validCharSet.Length == 0) throw new ArgumentException("validCharSet cannot be empty");
    }


    public virtual char Generate
    {
        get
        {
            char nextChar = _validCharSet[_context.Random.Next(_validCharSet.Length)];
            return nextChar;
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<char> GenerateMany(int count)
    {
        List<char> result = new List<char>();
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





