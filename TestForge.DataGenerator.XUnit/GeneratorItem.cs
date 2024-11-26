namespace TestForge.DataGenerator.XUnit;

/// <summary>
/// an enumerator generator item
/// </summary>
public class GeneratorItem
{
    public Type GeneratorType { get; set; }
    public string Name { get; set; }
    public Func<object, GeneratorContext, object> Generator {get;set;}
}
    


