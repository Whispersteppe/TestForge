using TestForge.DataGenerator.BuiltinGenerators.FixedListData;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test
{
    public class FixedDataTest : TestBase
    {
        public FixedDataTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void GetFixedData()
        {

            var rslts = FixedDataReader.Instance.GetValuesForTopic("FirstName");

            WriteObject(rslts);
        }
    }
}