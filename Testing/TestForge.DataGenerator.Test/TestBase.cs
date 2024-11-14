using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestForge.DataGenerator.Test;

public class TestBase
{
    ITestOutputHelper _output;

    public TestBase(ITestOutputHelper output) 
    {
        _output = output;
    }

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
