namespace TestForge.DataGenerator.BuiltinGenerators.FixedListData;

public class FixedListGenerator : ListSelectionGenerator<string>
{
    public FixedListGenerator(string listName)
        : base(FixedDataReader.Instance.GetValuesForTopic(listName).Values.ToArray())
    {
    }
}
