using System.Reflection;

namespace TestForge.DataGenerator.XUnit;

public enum ConfigurationTypeEnum
{
    IterationAndPrimarySeed,
    SpecificSeeds,
}
/// <summary>
/// Configuration that is passed into TestForgeDataEnumerator
/// </summary>
public class TestForgeDataEnumeratorConfiguration
{
    /// <summary>
    /// which parts of the configuration to use
    /// </summary>
    public ConfigurationTypeEnum ConfigurationTypeEnum { get; set; }
    /// <summary>
    /// the data type of items being created
    /// </summary>
    public Type ClassType { get; set; }
    /// <summary>
    /// the number of iterations of data to produce
    /// </summary>
    public int Iterations { get; set; } = 25;
    /// <summary>
    /// the primary seed that will be used to generate individual seeds for each iteration
    /// </summary>
    public int PrimarySeed { get; set; } = 0;
    /// <summary>
    /// a list of specific seeds that will be used instead of theprimary seed
    /// </summary>
    public List<int> SpecificSeeds { get; set; } = new List<int>();
    /// <summary>
    /// other parameters to go into the generator
    /// </summary>
    public List<object> Parameters { get; set; } = new List<object>();

    /// <summary>
    /// information about the method being called during the test
    /// </summary>
    public MethodInfo TestMethodInformation { get; set; }
}


