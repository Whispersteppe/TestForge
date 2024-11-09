namespace TestForge.DataGenerator;

public interface IGenerator
{
    public T GenerateMany<T>(int count);
    public object Generate { get; }
}

public interface IGenerator<T> : IGenerator
{
    public T GenerateMany(int count);
    new public T Generate { get; }
}
