using FluentAssertions;
using TestForge.DataGenerator.Builder;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

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
        var classGenerator = CreateGenerator(context);

        var generatedData = classGenerator.Generate;

        WriteObject(generatedData);
    }

    [Fact]
    public void SimpleClassbuilderWitConstructorTest()
    {
        GeneratorContext context = new GeneratorContext();
        var classGenerator = CreateGenerator(context);
        classGenerator.AddConstructor(x => new TestClass());

        var generatedData = classGenerator.Generate;

        WriteObject(generatedData);
    }

    [Fact]
    public void MultipleItemsClassbuilderTest()
    {
        GeneratorContext context = new GeneratorContext();
        var classGenerator = CreateGenerator(context);

        var generatedData = classGenerator.GenerateMany(5);

        WriteObject(generatedData);

        IGenerator generator2 = classGenerator;

        var generatedData2 = generator2.GenerateMany(5);
        var singleData = generator2.Generate;
    }


    [Fact]
    public void RepeatabilityTest()
    {
        Random random = new Random();
        int seed = random.Next();

        GeneratorContext context1 = new GeneratorContext(seed);
        GeneratorContext context2 = new GeneratorContext(seed);

        ClassGenerator<TestClass> generator1 = CreateGenerator(context1);
        ClassGenerator<TestClass> generator2 = CreateGenerator(context2);

        var generatedData1 = generator1.GenerateMany(5);
        var generatedData2 = generator2.GenerateMany(5);

        WriteObject(generatedData1);
        WriteObject(generatedData2);

        KellermanSoftware.CompareNetObjects.CompareLogic comparer = new KellermanSoftware.CompareNetObjects.CompareLogic();
        var compareResults = comparer.Compare(generatedData1, generatedData2);

        compareResults.AreEqual.Should().BeTrue();

    }

    private ClassGenerator<TestClass> CreateGenerator(GeneratorContext context)
    {
        var classGenerator = context.Build<TestClass>()
            .Property(x => x.FieldString, "string")
            .Property(x => x.FieldInt, y => y.Builtin.Int())
            .Property(x => x.FieldDouble, y => { return 25; })
            .Property(x => x.FieldDouble, y => y.Builtin.Double())
            .Property(x => x.FieldBool, y => y.Builtin.Bool())
            .Property(x => x.FieldString2, y => y.Builtin.String())
            .Property(x => x.FieldInt2, y => y.Builtin.Int(0, 10))
            .Property(x => x.FieldByte, y => y.Builtin.Byte())
            .Property(x => x.FieldChar, y => y.Builtin.Char())
            .Property(x => x.FieldDate, y => y.Builtin.DateTime())
            .Property(x => x.FieldFloat, y => y.Builtin.Float())
            .Property(x => x.FieldEnum, y => y.Builtin.Enum<MyEnum>())
            .Property(x => x.FieldGuid, y => y.Builtin.Guid())
            .Property(x => x.FieldLong, y => y.Builtin.Long())
            .Property(x => x.FieldShort, y => y.Builtin.Short())
            .Property(x => x.FieldUint, y => y.Builtin.UInt())
            .Property(x => x.FieldUint16, y => y.Builtin.UInt16())
            .Property(x => x.FieldSelection, y => y.Builtin.Selection("One", "Two", "Three", "Four", "Five"))

            ;

        return classGenerator;
    }
}

public enum MyEnum
{
    Value1,
    Value2, 
    Value3, 
    Value4, 
    Value5, 
    Value6, 
    Value7, 
    Value8, 
    Value9, 
    Value10, 
    Value11,
}
public class TestClass
{
    public string FieldString { get; set; }
    public string FieldString2 { get; set; }
    public int FieldInt { get; set; }
    public int FieldInt2 { get; set; }
    public double FieldDouble { get; set; }
    public double FieldDouble2 { get; set; }
    public bool FieldBool { get; set; }
    public byte FieldByte { get; set; }
    public char FieldChar { get; set; }
    public DateTime FieldDate { get; set; }
    public float FieldFloat { get; set; }
    public MyEnum FieldEnum { get; set; }
    public Guid FieldGuid { get; set; }
    public long FieldLong { get; set; }
    public short FieldShort { get; set; }
    public uint FieldUint { get; set; }
    public UInt16 FieldUint16 { get; set; }
    public string FieldSelection { get; set; }
}