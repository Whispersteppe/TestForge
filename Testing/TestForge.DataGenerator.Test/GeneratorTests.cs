using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

public class GeneratorTests : TestBase
{
    public GeneratorTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void IntTest()
    {
        GeneratorContext context = new GeneratorContext();
        IntGenerator generator = new IntGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
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

    [Fact]
    public void ByteTest()
    {
        GeneratorContext context = new GeneratorContext();
        ByteGenerator generator = new ByteGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }

    [Fact]
    public void CharTest()
    {
        GeneratorContext context = new GeneratorContext();
        CharGenerator generator = new CharGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }

    [Fact]
    public void DateTest()
    {
        GeneratorContext context = new GeneratorContext();
        DateGenerator generator = new DateGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }

    [Fact]
    public void DoubleTest()
    {
        GeneratorContext context = new GeneratorContext();
        DoubleGenerator generator = new DoubleGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
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

    [Fact]
    public void GuidTest()
    {
        GeneratorContext context = new GeneratorContext();
        GuidGenerator generator = new GuidGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }

    [Fact]
    public void ListSelectionTest()
    {
        GeneratorContext context = new GeneratorContext();
        ListSelectionGenerator<int> generator = new ListSelectionGenerator<int>(1, 2, 4, 8, 16);

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
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

    [Fact]
    public void ShortTest()
    {
        GeneratorContext context = new GeneratorContext();
        ShortGenerator generator = new ShortGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
    }

    [Fact]
    public void StringTest()
    {
        GeneratorContext context = new GeneratorContext();
        StringGenerator generator = new StringGenerator();

        var rslt1 = generator.Generate;
        var rslt2 = generator.GenerateMany(context, 5);

        IGenerator generator1 = generator;
        var rslt3 = generator1.Generate;
        var rslt4 = generator1.GenerateMany(context, 5);
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

    [Fact]
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
