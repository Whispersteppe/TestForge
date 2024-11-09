namespace TestForge.DataGenerator.Builder;

public class PropertyGenerator
{
    internal readonly GeneratorContext _context;
    public PropertyGenerator(GeneratorContext context, string propertyName)
    {
        _context = context;
        PropertyName = propertyName;
    }

    public string PropertyName { get; private set; }
    public virtual object GetValue()
    {
        return null;
    }
}

public class PropertyGeneratorFixedValue<TProperty> : PropertyGenerator
{
    public PropertyGeneratorFixedValue(GeneratorContext context, string propertyName) : base(context, propertyName)
    {
    }

    public TProperty? Value { get; set; }
    public override object GetValue()
    {
        return Value;
    }
}

public class PropertyGeneratorIGenerator<TProperty> : PropertyGenerator
{
    public PropertyGeneratorIGenerator(GeneratorContext context, string propertyName) : base(context, propertyName)
    {
    }
    public IGenerator? Generator { get; set; }

    public override object GetValue()
    {
        return Generator.Generate;
    }
}

public class PropertyGeneratorGeneratorFunction<TProperty> : PropertyGenerator
{
    public PropertyGeneratorGeneratorFunction(GeneratorContext context, string propertyName) : base(context, propertyName)
    {
    }

    public Func<GeneratorContext, TProperty>? FunctionGenerator { get; set; }

    public override object GetValue()
    {
        return FunctionGenerator.Invoke(_context);
    }
}