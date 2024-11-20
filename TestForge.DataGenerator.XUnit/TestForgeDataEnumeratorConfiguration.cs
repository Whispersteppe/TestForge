namespace TestForge.DataGenerator.XUnit;

/// <summary>
/// Configuration that is passed into TestForgeDataEnumerator
/// </summary>
public class TestForgeDataEnumeratorConfiguration
{
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
    /// other parameters to go into the generator
    /// </summary>
    public List<object> Parameters { get; set; } = new List<object>();
}


