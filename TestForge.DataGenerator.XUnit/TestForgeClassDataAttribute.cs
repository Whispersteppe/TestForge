using System.Globalization;
using System.Reflection;
using Xunit;

namespace TestForge.DataGenerator.XUnit;

/// <summary>
/// extension of the ClassDataAttribute to call create an enumerator around a TestForgeDataEnumerator
/// </summary>
/// <remarks>
/// this is part of the xunit ClassData, so format will look approximately like:
/// [Theory]
/// [TestForgeClassData(typeof(enumeratorClass))]
/// public void MyTest(mydata data){}
/// 
/// where enumerator class is a class ased off of IEnumerator<object[]> that returns a type of mydata
/// </remarks>
public class TestForgeClassDataAttribute : ClassDataAttribute
{
    TestForgeDataEnumeratorConfiguration _configuration;

    public TestForgeClassDataAttribute(Type classType, int interations = 25, int seed = 0,  params object[] constructorParameters) : base(classType)
    {
        _configuration = new TestForgeDataEnumeratorConfiguration()
        {
            ClassType = classType,
            Iterations = interations,
            PrimarySeed = seed,
            Parameters = new List<object>(constructorParameters)
        };

    }

    /// <summary>
    /// override of the ClassData::GetData
    /// </summary>
    /// <param name="testMethod"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {

        IEnumerable<object[]> data = Activator.CreateInstance(Class, _configuration) as IEnumerable<object[]>;

        if (data == null)
            throw new ArgumentException(
                string.Format(
                    CultureInfo.CurrentCulture,
                    "{0} must implement IEnumerable<object[]> to be used as ClassData for the test method named '{1}' on {2}",
                    Class.FullName,
                    testMethod.Name,
                    testMethod.DeclaringType.FullName
                )
            );

        return data;
    }

}
