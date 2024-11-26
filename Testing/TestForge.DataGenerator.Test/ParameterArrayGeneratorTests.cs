using FluentAssertions;
using Newtonsoft.Json;
using TestForge.DataGenerator;
using TestForge.DataGenerator.Test;
using TestForge.DataGenerator.XUnit;
using TestForge.DataGenerator.XUnit.Attributes;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

/// <summary>
/// tests of the TestForgeDataEnumerator and TestForgeDataClassAttribute
/// </summary>
public class ParameterArrayGeneratorTests : TestBase
{

    public ParameterArrayGeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void ArrayGeneratorTests()
    {
        TestForgeDataEnumeratorConfiguration config = new TestForgeDataEnumeratorConfiguration();
        var testEnumerator = new MyTestClass(config);

        var paramInfo = GetType().GetMethod(nameof(MyTestMethod)).GetParameters().ToList();
        ParameterArrayGenerator arrayGenerator = new ParameterArrayGenerator(paramInfo, testEnumerator);

        var generatedData = arrayGenerator.BuildParameterArray(5, 1);

        WriteObject(generatedData);
    }

    public void MyTestMethod(TFTestClass testData, int seed, int iteration, GeneratorContext context)
    {
    }

}

