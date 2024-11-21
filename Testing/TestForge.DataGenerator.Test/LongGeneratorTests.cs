using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

/// <summary>
/// tests of the various generators
/// </summary>
public class LongGeneratorTests : TestBase
{
    public LongGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void LongTest()
    {
        GeneratorContext context = new GeneratorContext();
        LongGenerator generator = new LongGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }
}
