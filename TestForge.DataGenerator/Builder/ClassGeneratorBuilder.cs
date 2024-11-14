using System.Linq.Expressions;

namespace TestForge.DataGenerator.Builder;

public class ClassGeneratorBuilder<T> where T: class
{

    ClassGenerator<T> _generator;
    GeneratorContext _context;

    public ClassGeneratorBuilder(GeneratorContext context)
    {
        _context = context;
        _generator = new ClassGenerator<T>();
    }

    public ClassGeneratorBuilder<T> AddConstructor(Func<GeneratorContext, T> constructorFunction)
    {
        _generator._constructorFunction = constructorFunction;
        return this;
    }

    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, IGenerator> generator)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        var inGen = generator.Invoke(_context);

        _generator._propertyGenerators.Add(new PropertyGeneratorIGenerator<TProperty>(propertyName) { Generator = inGen });

        return this;
    }

    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, TProperty value)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _generator._propertyGenerators.Add(new PropertyGeneratorFixedValue<TProperty>(propertyName) { Value = value });

        return this;
    }

    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, TProperty> generatorFunction)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _generator._propertyGenerators.Add(new PropertyGeneratorGeneratorFunction<TProperty>(propertyName) { FunctionGenerator = generatorFunction });

        return this;
    }

    public ClassGenerator<T> Build()
    {
        return _generator;
    }


}
