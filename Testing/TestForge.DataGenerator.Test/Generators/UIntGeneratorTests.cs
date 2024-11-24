using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test.Generators;

/// <summary>
/// tests of the various generators
/// </summary>
public class UIntGeneratorTests : TestBase
{
    public UIntGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void UIntTest()
    {
        GeneratorContext context = new GeneratorContext();
        UIntGenerator generator = new UIntGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }
}
