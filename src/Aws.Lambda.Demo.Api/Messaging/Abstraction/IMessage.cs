namespace Aws.Lambda.Demo.Api.Messaging.Abstraction
{
    interface IMessage<TKey>
    {
        public TKey Id { get; set; }
    }
}
