namespace TestForge.DataGenerator.BuiltinGenerators;

/// <summary>
/// property generators
/// </summary>
/// <remarks>
/// for the different types of generators for a property we'll need to wrap the generators, values, inline code funcs, or whatever
/// in something common so we don't have to have these gosh awful case blocks all over the place for the different generator types.
/// </remarks>
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

/// <summary>
/// property generators for fixed values
/// </summary>
/// <typeparam name="TProperty"></typeparam>
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

/// <summary>
/// property generator for a generator
/// </summary>
/// <typeparam name="TProperty"></typeparam>
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

/// <summary>
/// property generator for inline function code
/// </summary>
/// <typeparam name="TProperty"></typeparam>
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