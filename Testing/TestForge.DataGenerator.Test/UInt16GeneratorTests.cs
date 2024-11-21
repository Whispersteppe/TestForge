using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

/// <summary>
/// tests of the various generators
/// </summary>
public class UInt16GeneratorTests : TestBase
{
    public UInt16GeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    public void UInt16Test()
    {
        GeneratorContext context = new GeneratorContext();
        UInt16Generator generator = new UInt16Generator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }


}
