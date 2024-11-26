namespace TestForge.DataGenerator.XUnit.Attributes;

/// <summary>
/// an attribute on a generator on a TestForge enumerator that tells the enumerator that this
/// method is capable of creating a data generator for use in an enumerator
/// </summary>
public class GeneratorAttribute : Attribute
{
    public Type GeneratorType { get; set; }
    public string Name { get; set; }

    public GeneratorAttribute(Type generatorType, string name)
    {
        GeneratorType = generatorType;
        Name = name;
    }
}



