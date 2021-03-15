namespace Aws.Lambda.Demo.Api.Data.Abstraction
{
    public interface ITable<TKey>
    {
        TKey Id { get; set; }
    }
}
