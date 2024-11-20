using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.DataGenerator.XUnit;

public class TestForgeDataEnumerator<T> : IEnumerable<object[]>
{

    TestForgeDataEnumeratorConfiguration _configuration;
    int _currentCount = 0;

    public TestForgeDataEnumerator(TestForgeDataEnumeratorConfiguration configuration)
    {
       _configuration = configuration;
    }

    /* things to do:
     *   pass in a GeneratorContext
     *   pass in individual seeds for multiple items
     *   spit out the seed in the output so it can be found
     *   all passing in of seeds for different items
     *   generic generator - have a virtual BuildGenerator
     */


    public IEnumerator<object[]> GetEnumerator()
    {

        GeneratorContext context = new GeneratorContext(_configuration.PrimarySeed);
        IGenerator<T> generator = GetGenerator(context);

        while (_currentCount < _configuration.Iterations)
        {

            T item = generator.Generate(context);

            yield return new object[] { item };

            _currentCount++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public virtual IGenerator<T> GetGenerator(GeneratorContext context)
    {
        throw new NotImplementedException();
    }

}


