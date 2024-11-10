using System.Text;

namespace TestForge.DataGenerator.BuiltinGenerators;

public class StringGenerator : IGenerator<string>
{
    GeneratorContext _context;
    int _minLength;
    int _maxLength;
    string _validCharSet;

    public StringGenerator(GeneratorContext context, int minLength = 1, int maxLength = 25, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        _context = context;
        _minLength = minLength;
        _maxLength = maxLength;
        _validCharSet = validCharSet;

        if (_minLength <= 0) throw new ArgumentException("minlenth must be larger than zero");
        if (_minLength > maxLength) throw new ArgumentException("maxLength must be larger than minLength");
        if (_validCharSet.Length == 0) throw new ArgumentException("validCharSet cannot be empty");
    }


    public virtual string Generate
    {
        get
        {
            int targetLength = _context.Random.Next(_minLength, _maxLength);
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0;i < targetLength;i++)
            {
                char nextChar = _validCharSet[_context.Random.Next(_validCharSet.Length)];
                stringBuilder.Append(nextChar);
            }

            return stringBuilder.ToString();

        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }


    public List<string> GenerateMany(int count)
    {
        List<string> result = new List<string>();
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





