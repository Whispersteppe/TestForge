using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

public class TestClass
{
    public string FirstField { get; set; }
    public int SecondField { get; set; }
    public double ThirdField { get; set; }
    public List<int> FourthField { get; set; }
    public string FifthField { get; set; }
    public int SixthField { get; set; }
}

public class ClassGeneratorTests : TestBase
{
    public ClassGeneratorTests(ITestOutputHelper output) 
        : base(output)
    {

    }

    [Fact]
    public void SimpleClassbuilderTest()
    {
        GeneratorContext context = new GeneratorContext();
        var classGenerator = context.Build<TestClass>()
            .Property(x => x.FirstField, "string")
            .Property(x=>x.SecondField, y=> y.Builtin.Int())
            .Property(x=>x.ThirdField, y=> { return 25; })
            .Property(x=>x.SixthField, y=> y.Builtin.Int(0, 10))
            ;

        var generatedData = classGenerator.Generate;

        WriteObject(generatedData);
    }
}
