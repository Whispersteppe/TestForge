using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test.Generators;

/// <summary>
/// tests of the various generators
/// </summary>
public class BoolGeneratorTests : TestBase
{
    public BoolGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void BoolTest()
    {
        GeneratorContext context = new GeneratorContext();
        BoolGenerator generator = new BoolGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }
}
