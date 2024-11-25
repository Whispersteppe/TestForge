using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForge.DataGenerator.BuiltinGenerators;
using TestForge.DataGenerator.XUnit;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test
{
    public class TestForgeDataEnumeratorTests : TestBase
    {
        public TestForgeDataEnumeratorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            TestForgeDataEnumeratorConfiguration config = new TestForgeDataEnumeratorConfiguration()
            {
                ClassType = typeof(int),
                ConfigurationTypeEnum = ConfigurationTypeEnum.IterationAndPrimarySeed,
                Iterations = 25,
                PrimarySeed = 0, 
                TestMethodInformation = typeof(MyTestClass).GetMethod("GetGenerator")
            };

            TestForgeDataEnumerator enumer = new MyTestClass(config);

            foreach(var item in enumer)
            {
                WriteObject(item);
            }
        }
    }
}
