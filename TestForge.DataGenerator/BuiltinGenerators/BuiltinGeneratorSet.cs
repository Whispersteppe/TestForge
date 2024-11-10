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
        IntGenerator generator = new IntGenerator(_context, minValue, maxValue);
        return generator;

    }

    public ByteGenerator Byte(byte? minValue = null, byte? maxValue = null)
    {
        ByteGenerator generator = new ByteGenerator(_context, minValue, maxValue);
        return generator;

    }

    public LongGenerator Long(long? minValue = null, long? maxValue = null)
    {
        LongGenerator generator = new LongGenerator(_context, minValue, maxValue);
        return generator;

    }

    public ShortGenerator Short(short? minValue = null, short? maxValue = null)
    {
        ShortGenerator generator = new ShortGenerator(_context, minValue, maxValue);
        return generator;

    }

    public UIntGenerator UInt(uint? minValue = null, uint? maxValue = null)
    {
        UIntGenerator generator = new UIntGenerator(_context, minValue, maxValue);
        return generator;

    }

    public UInt16Generator UInt16(UInt16? minValue = null, UInt16? maxValue = null)
    {
        UInt16Generator generator = new UInt16Generator(_context, minValue, maxValue);
        return generator;

    }

    public DateGenerator DateTime(DateTime? minValue = null, DateTime? maxValue = null)
    {
        DateGenerator generator = new DateGenerator(_context, minValue, maxValue);
        return generator;

    }

    public DoubleGenerator Double(double? minValue = null, double? maxValue = null)
    {
        DoubleGenerator generator = new DoubleGenerator(_context, minValue, maxValue);
        return generator;
    }

    public FloatGenerator Float(float? minValue = null, float? maxValue = null)
    {
        FloatGenerator generator = new FloatGenerator(_context, minValue, maxValue);
        return generator;
    }

    public StringGenerator String(int minLength = 1, int maxLength = 1, string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        StringGenerator generator = new StringGenerator(_context, minLength, maxLength, validCharSet);
        return generator;

    }

    public CharGenerator Char(string validCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
    {
        CharGenerator generator = new CharGenerator(_context, validCharSet);
        return generator;
    }

    public BoolGenerator Bool()
    {
        BoolGenerator generator = new BoolGenerator(_context);
        return generator;
    }

    public EnumGenerator<T> Enum<T>() where T: Enum
    {
        EnumGenerator<T> generator = new EnumGenerator<T>(_context);
        return generator;
    }

    public GuidGenerator Guid()
    {
        GuidGenerator generator = new GuidGenerator(_context);
        return generator;
    }


    public ListSelectionGenerator<T> Selection<T>(params T[] items)
    {
        ListSelectionGenerator<T> generator = new ListSelectionGenerator<T>(_context, items);
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