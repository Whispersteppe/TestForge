﻿using TestForge.DataGenerator.BuiltinGenerators;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test.Generators;

/// <summary>
/// tests of the various generators
/// </summary>
public class ListSelectionGeneratorTests : TestBase
{
    public ListSelectionGeneratorTests(ITestOutputHelper output) : base(output)
    {
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
}
