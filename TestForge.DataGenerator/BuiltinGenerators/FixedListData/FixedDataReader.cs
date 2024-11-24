using Newtonsoft.Json;
using System.Reflection;

namespace TestForge.DataGenerator.BuiltinGenerators.FixedListData;

public class FixedDataReader
{
    static FixedDataReader _instance;
    public static FixedDataReader Instance
    {
        get
        {
            _instance ??= new FixedDataReader();

            return _instance;
        }
    }

    Dictionary<string, FixedData> _listData;
    public FixedDataReader()
    {
        _listData = JsonConvert.DeserializeObject<Dictionary<string, FixedData>>(GetResourceString("TestForge.DataGenerator.BuiltinGenerators.FixedListData.FixedData.json"));
    }

    public FixedData GetValuesForTopic(string topic)
    {
        var list = _listData[topic];

        return list;
    }

    private string GetResourceString(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
