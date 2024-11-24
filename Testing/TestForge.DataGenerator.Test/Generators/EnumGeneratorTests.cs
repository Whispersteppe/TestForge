using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test.Generators;

/// <summary>
/// tests of the various generators
/// </summary>
public class EnumGeneratorTests : TestBase
{
    public EnumGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }


    public enum TestEnum
    {
        Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, Value10, Value11,
    }

    [Fact]
    public void EnumTest()
    {
        GeneratorContext context = new GeneratorContext();
        EnumGenerator<TestEnum> generator = new EnumGenerator<TestEnum>();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }


}
