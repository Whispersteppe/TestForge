namespace TestForge.DataGenerator;

public interface IGenerator
{
    public List<object> GenerateMany(GeneratorContext context, int count);
    public object Generate(GeneratorContext context);
}

public interface IGenerator<T> : IGenerator
{
    public List<T> GenerateMany(GeneratorContext context, int count);
    new public T Generate(GeneratorContext context);
}
