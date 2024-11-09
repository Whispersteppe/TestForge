using TestForge.DataGenerator.BuiltinGenera;

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