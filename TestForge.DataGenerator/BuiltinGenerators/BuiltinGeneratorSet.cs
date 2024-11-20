namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// a class to create all the built-in classes.  primarily used to more easily reference things from the context
/// </summary>
public class BuiltinGeneratorSet
{
    GeneratorContext _context;
    public BuiltinGeneratorSet(GeneratorContext context)
    {
        _context = context;
    }

    /// <summary>
    /// create an int generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public IntGenerator Int(int? minValue = null, int? maxValue = null)
    {
        IntGenerator generator = new IntGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a byte generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public ByteGenerator Byte(byte? minValue = null, byte? maxValue = null)
    {
        ByteGenerator generator = new ByteGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a long generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public LongGenerator Long(long? minValue = null, long? maxValue = null)
    {
        LongGenerator generator = new LongGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a short generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public ShortGenerator Short(short? minValue = null, short? maxValue = null)
    {
        ShortGenerator generator = new ShortGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a uint generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public UIntGenerator UInt(uint? minValue = null, uint? maxValue = null)
    {
        UIntGenerator generator = new UIntGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a uint16 generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public UInt16Generator UInt16(UInt16? minValue = null, UInt16? maxValue = null)
    {
        UInt16Generator generator = new UInt16Generator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a datetime generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public DateGenerator DateTime(DateTime? minValue = null, DateTime? maxValue = null)
    {
        DateGenerator generator = new DateGenerator(minValue, maxValue);
        return generator;

    }

    /// <summary>
    /// create a double generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public DoubleGenerator Double(double? minValue = null, double? maxValue = null)
    {
        DoubleGenerator generator = new DoubleGenerator(minValue, maxValue);
        return generator;
    }

    /// <summary>
    /// create a float generator
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public FloatGenerator Float(float? minValue = null, float? maxValue = null)
    {
        FloatGenerator generator = new FloatGenerator(minValue, maxValue);
        return generator;
    }

    /// <summary>
    /// create a string generator
    /// </summary>
    /// <param name="minLength"></param>
    /// <param name="maxLength"></param>
    /// <param name="validCharSet"></param>
    /// <returns></returns>
    public StringGenerator String(int minLength = 1, int maxLength = 1, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        StringGenerator generator = new StringGenerator(minLength, maxLength, validCharSet);
        return generator;

    }

    /// <summary>
    /// create a char generator
    /// </summary>
    /// <param name="validCharSet"></param>
    /// <returns></returns>
    public CharGenerator Char(string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        CharGenerator generator = new CharGenerator(validCharSet);
        return generator;
    }

    /// <summary>
    /// create a bool generator
    /// </summary>
    /// <returns></returns>
    public BoolGenerator Bool()
    {
        BoolGenerator generator = new BoolGenerator();
        return generator;
    }

    /// <summary>
    /// create an enum generator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public EnumGenerator<T> Enum<T>() where T: Enum
    {
        EnumGenerator<T> generator = new EnumGenerator<T>();
        return generator;
    }

    /// <summary>
    /// create a guid generator
    /// </summary>
    /// <returns></returns>
    public GuidGenerator Guid()
    {
        GuidGenerator generator = new GuidGenerator();
        return generator;
    }

    /// <summary>
    /// create a list selection generator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="items"></param>
    /// <returns></returns>
    public ListSelectionGenerator<T> Selection<T>(params T[] items)
    {
        ListSelectionGenerator<T> generator = new ListSelectionGenerator<T>(items);
        return generator;

    }
}

/*
 * tree of stuff on the context
 * Context
 *      Generators
 *          Builtin
 *              double
 *              float
 *              date
 *              address
 *              name
 *              enum
 *              collection
 *              string
 *              address
 *              also think things from Bogus
 *          Class Generators
 *          Named Generators
 */