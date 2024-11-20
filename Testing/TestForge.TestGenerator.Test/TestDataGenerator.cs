using Newtonsoft.Json;
using TestForge.DataGenerator;
using TestForge.DataGenerator.XUnit;
using Xunit.Abstractions;

namespace TestForge.TestGenerator.Test;

/// <summary>
/// tests of the TestForgeDataEnumerator and TestForgeDataClassAttribute
/// </summary>
public class TestDataGenerator
{
    ITestOutputHelper _output;

    public TestDataGenerator(ITestOutputHelper output)
    {
        _output = output;
    }

    public void WriteObject(object o)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        var data = JsonConvert.SerializeObject(o, settings);
        _output.WriteLine(data);
    }


    [Theory]
    [TestForgeClassData(typeof(MyTestClass), 25, 0)]
    public void TestEnumerator(TFTestClass testData)
    {
        WriteObject(testData);
    }
}

public class MyTestClass : TestForgeDataEnumerator<TFTestClass>
{
    public MyTestClass(TestForgeDataEnumeratorConfiguration config) : base(config)
    {
    }

    public override IGenerator<TFTestClass> GetGenerator(GeneratorContext context)
    {
        var classGenerator = context.Build<TFTestClass>()
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
            .Property(x => x.FieldEnum, y => y.Builtin.Enum<TFMyEnum>())
            .Property(x => x.FieldGuid, y => y.Builtin.Guid())
            .Property(x => x.FieldLong, y => y.Builtin.Long())
            .Property(x => x.FieldShort, y => y.Builtin.Short())
            .Property(x => x.FieldUint, y => y.Builtin.UInt())
            .Property(x => x.FieldUint16, y => y.Builtin.UInt16())
            .Property(x => x.FieldSelection, y => y.Builtin.Selection("One", "Two", "Three", "Four", "Five"))
            .Build()
            ;

        return classGenerator;
    }
}

public enum TFMyEnum
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

public class TFTestClass
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
    public TFMyEnum FieldEnum { get; set; }
    public Guid FieldGuid { get; set; }
    public long FieldLong { get; set; }
    public short FieldShort { get; set; }
    public uint FieldUint { get; set; }
    public UInt16 FieldUint16 { get; set; }
    public string FieldSelection { get; set; }
}
