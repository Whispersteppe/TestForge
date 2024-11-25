using Newtonsoft.Json;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

/// <summary>
/// base functionality for all tests
/// </summary>
public class TestBase
{
    ITestOutputHelper _output;

    public TestBase(ITestOutputHelper output) 
    {
        _output = output;
    }

    public void WriteLine(string text)
    {
        _output.WriteLine(text);
    }

    /// <summary>
    /// write out an object as a formatted json string
    /// </summary>
    /// <param name="o"></param>
    public void WriteObject(object o)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        var data = JsonConvert.SerializeObject(o, settings);
        _output.WriteLine(data);
    }
}
