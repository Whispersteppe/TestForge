namespace TestForge.DataGenerator.Builder;

public class PropertyGenerator
{
    public PropertyGenerator(string propertyName)
    {
        PropertyName = propertyName;
    }

    public string PropertyName { get; private set; }
    public virtual object GetValue(GeneratorContext context)
    {
        return null;
    }
}

public class PropertyGeneratorFixedValue<TProperty> : PropertyGenerator
{
    public PropertyGeneratorFixedValue(string propertyName) : base(propertyName)
    {
    }

    public TProperty? Value { get; set; }
    public override object GetValue(GeneratorContext context)
    {
        return Value;
    }
}

public class PropertyGeneratorIGenerator<TProperty> : PropertyGenerator
{
    public PropertyGeneratorIGenerator(string propertyName) : base(propertyName)
    {
    }
    public IGenerator? Generator { get; set; }

    public override object GetValue(GeneratorContext context)
    {
        return Generator.Generate(context);
    }
}

public class PropertyGeneratorGeneratorFunction<TProperty> : PropertyGenerator
{
    public PropertyGeneratorGeneratorFunction(string propertyName) : base(propertyName)
    {
    }

    public Func<GeneratorContext, TProperty>? FunctionGenerator { get; set; }

    public override object GetValue(GeneratorContext context)
    {
        return FunctionGenerator.Invoke(context);
    }
}