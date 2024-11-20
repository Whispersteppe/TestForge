using System.Globalization;
using System.Reflection;
using Xunit;

namespace TestForge.DataGenerator.XUnit
{
    public class TestForgeClassDataAttribute : ClassDataAttribute
    {
        Type _class;
        TestForgeDataEnumeratorConfiguration _configuration;

        public TestForgeClassDataAttribute(Type @class, int interations = 25, int seed = 0,  params object[] constructorParameters) : base(@class)
        {
            _configuration = new TestForgeDataEnumeratorConfiguration()
            {
                Iterations = interations,
                PrimarySeed = seed,
                Parameters = new List<object>(constructorParameters)
            };

            _class = @class;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {

            IEnumerable<object[]> data = Activator.CreateInstance(_class, _configuration) as IEnumerable<object[]>;


            //IEnumerable<object[]> data = _constructorParameters.Count == 0
            //        ? Activator.CreateInstance(Class) as IEnumerable<object[]>
            //        : Activator.CreateInstance(_class, _constructorParameters.ToArray()) as IEnumerable<object[]>;

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
}
