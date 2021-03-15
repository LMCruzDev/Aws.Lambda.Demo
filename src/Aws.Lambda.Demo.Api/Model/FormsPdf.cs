using System;
using Aws.Lambda.Demo.Api.Model.Enum;

namespace Aws.Lambda.Demo.Api.Model
{
    public class FormsPdf
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }

        public DateTime CreatedDate { get; set; }

        public UploadStatus UploadStatus { get; set; }
    }
}
