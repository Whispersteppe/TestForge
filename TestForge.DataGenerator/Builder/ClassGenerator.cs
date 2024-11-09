using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.DataGenerator.Builder;



public class ClassGenerator<T> : IGenerator<T> where T : class
{

    GeneratorContext _context;
    Func<GeneratorContext, T>? _constructorFunction;
    List<PropertyGenerator> _propertyGenerators;

    public ClassGenerator(GeneratorContext context)
    {
        _context = context;
        _propertyGenerators = new List<PropertyGenerator>();
    }

    #region Builder

    public ClassGenerator<T> Build()
    {
        return this;
    }

    public ClassGenerator<T> AddConstructor(Func<GeneratorContext, T> constructorFunction)
    {
        _constructorFunction = constructorFunction;
        return this;
    }

    public ClassGenerator<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, IGenerator> generator)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        var inGen = generator.Invoke(_context);

        _propertyGenerators.Add(new PropertyGeneratorIGenerator<TProperty>(_context, propertyName) { Generator = inGen });

        return this;
    }

    public ClassGenerator<T> Property<TProperty>(Expression<Func<T, TProperty>> property, TProperty value)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _propertyGenerators.Add(new PropertyGeneratorFixedValue<TProperty>(_context, propertyName) { Value = value });

        return this;
    }

    public ClassGenerator<T> Property<TProperty>(Expression<Func<T, TProperty>> property, Func<GeneratorContext, TProperty> generatorFunction)
    {
        MemberExpression member = property.Body as MemberExpression;
        string propertyName = member.Member.Name;

        _propertyGenerators.Add(new PropertyGeneratorGeneratorFunction<TProperty>(_context, propertyName) { FunctionGenerator = generatorFunction });

        return this;
    }

    #endregion

    public T GenerateMany(int count)
    {
        throw new NotImplementedException();
    }

    public T1 GenerateMany<T1>(int count)
    {
        throw new NotImplementedException();
    }

    public T Generate 
    {
        get
        {
            T instance;
            if (_constructorFunction != null)
            {
                instance = _constructorFunction.Invoke(_context);
            }
            else
            {
                instance = Activator.CreateInstance(typeof(T)) as T;
            }

            foreach (var property in _propertyGenerators)
            {
                //  find the property
                PropertyInfo propInfo = typeof(T).GetProperty(property.PropertyName);
                if (propInfo != null)
                {
                    propInfo.SetValue(instance, property.GetValue());
                }
            }

            return instance;
        }
    }

    object IGenerator.Generate
    {
        get
        {
            return Generate;
        }
    }
    /*
     * tree of stuff on the context
     * Context
     *      Builder
     *          Class Builder
     *              Property
     *                  Pre property function
     *                  post property function
     *              post create function
     *              pre create function
     */

}
