using System.Linq.Expressions;
using TestForge.DataGenerator.BuiltinGenerators;

namespace TestForge.DataGenerator.Builder;

/// <summary>
/// build a class generator
/// </summary>
/// <typeparam name="T"></typeparam>
public class ClassGeneratorBuilder<T> where T: class
{

    ClassGenerator<T> _generator;
    GeneratorContext _context;

    public ClassGeneratorBuilder(GeneratorContext context)
    {
        _context = context;
        _generator = new ClassGenerator<T>();
    }

    /// <summary>
    /// add a custom constructor
    /// </summary>
    /// <param name="constructorFunction"></param>
    /// <returns></returns>
    /// <remarks>
    /// if you need to pass in data, or there is not a default constructor, then you'll want to use this.
    /// </remarks>
    public ClassGeneratorBuilder<T> AddConstructor(Func<GeneratorContext, T> constructorFunction)
    {
        _generator._constructorFunction = constructorFunction;
        return this;
    }

    /// <summary>
    /// set a property builder based on a generator
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="property"></param>
    /// <param name="generator"></param>
    /// <returns></returns>
    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, IGenerator> generator)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        var inGen = generator.Invoke(_context);

        _generator._propertyGenerators.Add(new PropertyGeneratorIGenerator<TProperty>(propertyName) { Generator = inGen });

        return this;
    }

    /// <summary>
    /// set a property with specific data
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="property"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, TProperty value)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _generator._propertyGenerators.Add(new PropertyGeneratorFixedValue<TProperty>(propertyName) { Value = value });

        return this;
    }

    /// <summary>
    /// set a property with an inline function
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="property"></param>
    /// <param name="generatorFunction"></param>
    /// <returns></returns>
    public ClassGeneratorBuilder<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, TProperty> generatorFunction)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _generator._propertyGenerators.Add(new PropertyGeneratorGeneratorFunction<TProperty>(propertyName) { FunctionGenerator = generatorFunction });

        return this;
    }

    /// <summary>
    /// return the generator
    /// </summary>
    /// <returns></returns>
    public ClassGenerator<T> Build()
    {
        return _generator;
    }


}
