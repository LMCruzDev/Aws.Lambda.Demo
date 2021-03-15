using System;
using Aws.Lambda.Demo.Api.Messaging.Abstraction;

namespace Aws.Lambda.Demo.Api.Messaging.Model
{
    public class FormPdfMessage : IMessage<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }
    }
}
