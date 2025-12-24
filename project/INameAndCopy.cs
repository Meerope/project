namespace project
{
    public interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}