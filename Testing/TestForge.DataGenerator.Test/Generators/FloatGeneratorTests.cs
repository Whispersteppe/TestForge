using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test.Generators;

/// <summary>
/// tests of the various generators
/// </summary>
public class FloatGeneratorTests : TestBase
{
    public FloatGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }


    [Fact]
    public void FloatTest()
    {
        GeneratorContext context = new GeneratorContext();
        FloatGenerator generator = new FloatGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }
}
