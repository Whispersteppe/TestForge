using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestForge.DataGenerator.BuiltinGenerators.FixedListData;

public class FixedData
{
    public string Description { get; set; }
    public List<string> Values { get; set; }
}
