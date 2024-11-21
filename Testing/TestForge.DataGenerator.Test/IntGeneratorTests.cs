using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

/// <summary>
/// tests of the various generators
/// </summary>
public class IntGeneratorTests : TestBase
{
    public IntGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void IntTest()
    {
        GeneratorContext context = new GeneratorContext();
        IntGenerator generator = new IntGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }
}
