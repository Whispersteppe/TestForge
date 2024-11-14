namespace TestForge.DataGenerator.BuiltinGenerators;

public class BuiltinGeneratorSet
{
    GeneratorContext _context;
    public BuiltinGeneratorSet(GeneratorContext context)
    {
        _context = context;
    }

    public IntGenerator Int(int? minValue = null, int? maxValue = null)
    {
        IntGenerator generator = new IntGenerator(minValue, maxValue);
        return generator;

    }

    public ByteGenerator Byte(byte? minValue = null, byte? maxValue = null)
    {
        ByteGenerator generator = new ByteGenerator(minValue, maxValue);
        return generator;

    }

    public LongGenerator Long(long? minValue = null, long? maxValue = null)
    {
        LongGenerator generator = new LongGenerator(minValue, maxValue);
        return generator;

    }

    public ShortGenerator Short(short? minValue = null, short? maxValue = null)
    {
        ShortGenerator generator = new ShortGenerator(minValue, maxValue);
        return generator;

    }

    public UIntGenerator UInt(uint? minValue = null, uint? maxValue = null)
    {
        UIntGenerator generator = new UIntGenerator(minValue, maxValue);
        return generator;

    }

    public UInt16Generator UInt16(UInt16? minValue = null, UInt16? maxValue = null)
    {
        UInt16Generator generator = new UInt16Generator(minValue, maxValue);
        return generator;

    }

    public DateGenerator DateTime(DateTime? minValue = null, DateTime? maxValue = null)
    {
        DateGenerator generator = new DateGenerator(minValue, maxValue);
        return generator;

    }

    public DoubleGenerator Double(double? minValue = null, double? maxValue = null)
    {
        DoubleGenerator generator = new DoubleGenerator(minValue, maxValue);
        return generator;
    }

    public FloatGenerator Float(float? minValue = null, float? maxValue = null)
    {
        FloatGenerator generator = new FloatGenerator(minValue, maxValue);
        return generator;
    }

    public StringGenerator String(int minLength = 1, int maxLength = 1, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        StringGenerator generator = new StringGenerator(minLength, maxLength, validCharSet);
        return generator;

    }

    public CharGenerator Char(string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        CharGenerator generator = new CharGenerator(validCharSet);
        return generator;
    }

    public BoolGenerator Bool()
    {
        BoolGenerator generator = new BoolGenerator();
        return generator;
    }

    public EnumGenerator<T> Enum<T>() where T: Enum
    {
        EnumGenerator<T> generator = new EnumGenerator<T>();
        return generator;
    }

    public GuidGenerator Guid()
    {
        GuidGenerator generator = new GuidGenerator();
        return generator;
    }


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