namespace TestForge.DataGenerator;

public interface IGenerator
{
    public List<object> GenerateMany(int count);
    public object Generate { get; }
}

public interface IGenerator<T> : IGenerator
{
    public List<T> GenerateMany(int count);
    new public T Generate { get; }
}
