namespace TestForge.DataGenerator.XUnit;

/// <summary>
/// generate n items based on a single seed
/// </summary>
public class TestForgeIterationDataClassAttribute : TestForgeClassDataAttribute
{
    public TestForgeIterationDataClassAttribute(Type classType, int interations = 25, int seed = 0) 
        : base(classType, new TestForgeDataEnumeratorConfiguration()
                    {
                        ConfigurationTypeEnum = ConfigurationTypeEnum.IterationAndPrimarySeed,
                        ClassType = classType,
                        Iterations = interations,
                        PrimarySeed = seed,
                    })
    {
    }
}

