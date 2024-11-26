namespace TestForge.DataGenerator.XUnit.Attributes;

/// <summary>
/// data class attribute to generate data based on a specific set of seeds
/// </summary>
public class TestForgeSpecificSeedsDataClassAttribute : TestForgeClassDataAttribute
{

    public TestForgeSpecificSeedsDataClassAttribute(Type classType, params int[] seeds) :
        base(classType, new TestForgeDataEnumeratorConfiguration()
        {
            ConfigurationTypeEnum = ConfigurationTypeEnum.SpecificSeeds,
            ClassType = classType,
            SpecificSeeds = new List<int>(seeds)
        })
    {
    }
}

