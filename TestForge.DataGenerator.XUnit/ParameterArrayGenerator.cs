using System.Reflection;
using TestForge.DataGenerator.XUnit.Attributes;

namespace TestForge.DataGenerator.XUnit;

/// <summary>
/// generate an array of parameters based on the generator enumerator DataClass for a particular test method
/// </summary>
public class ParameterArrayGenerator
{
    List<ParameterInfo>? _paramInfo = null;
    List<GeneratorItem>? _generators = null;

    object _classEnumerator;

    public ParameterArrayGenerator(List<ParameterInfo> paramInfo, object classEnumerator)
    {

        _generators = GetGenerators(classEnumerator.GetType());
        _paramInfo = paramInfo;
        _classEnumerator = classEnumerator;

    }

    /// <summary>
    /// builds an array of parameters to send to the test
    /// </summary>
    /// <param name="seed"></param>
    /// <param name="iteration"></param>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    public object[] BuildParameterArray(int seed, int iteration)
    {

        List<object> parameterArray = new List<object>();


        GeneratorContext context = new GeneratorContext(seed);

        foreach (var param in _paramInfo)
        {
            if (_generators.FirstOrDefault(x => x.GeneratorType == param.ParameterType) != null)
            {
                var generator = _generators.First(x => x.GeneratorType == param.ParameterType).Generator(_classEnumerator, context) as IGenerator;

                var dataElement = generator.Generate(context);
                parameterArray.Add(dataElement);
                continue;
            }

            if (_generators.FirstOrDefault(x => x.Name == param.Name) != null)
            {
                var generator = _generators.First(x => x.Name == param.Name).Generator(_classEnumerator, context) as IGenerator;

                var dataElement = generator.Generate(context);
                parameterArray.Add(dataElement);
                continue;
            }

            if (param.ParameterType == typeof(GeneratorContext))
            {
                parameterArray.Add(context);
                continue;
            }
            if (param.Name.Equals("seed", StringComparison.InvariantCultureIgnoreCase))
            {
                parameterArray.Add(seed);
                continue;
            }
            if (param.Name.Equals("iteration", StringComparison.InvariantCultureIgnoreCase))
            {
                parameterArray.Add(iteration);
                continue;
            }
            //  if we reach this point, we haven't assigned a parameter.  explode mightily
            throw new InvalidDataException($"Cannot find a generator for parameter: {param.Name}");
        }

        return parameterArray.ToArray();
    }

    /// <summary>
    /// retrieves a set of generators from this or a child class
    /// </summary>
    /// <returns></returns>
    private List<GeneratorItem> GetGenerators(Type dataClassEnumeratorType)
    {
        List<GeneratorItem> generators = new List<GeneratorItem>();
        var methodList = dataClassEnumeratorType.GetMethods();
        foreach (var method in methodList)
        {
            var attributes = method.GetCustomAttributes(false);
            var testAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(GeneratorAttribute)) as GeneratorAttribute;
            if (testAttribute != null)
            {
                generators.Add(new GeneratorItem()
                {
                    Name = testAttribute.Name,
                    GeneratorType = testAttribute.GeneratorType,
                    Generator = (xClass, xContext) =>
                    {
                        object?[]? xArray = new object?[] { xContext };
                        var rslt = method.Invoke(xClass, xArray);
                        return rslt;
                    }
                });
            }
        }

        return generators;
    }
}
    


