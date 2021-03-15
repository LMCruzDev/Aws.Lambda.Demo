using System;
using Amazon.DynamoDBv2.DataModel;
using Aws.Lambda.Demo.Api.Data.Abstraction;

namespace Aws.Lambda.Demo.Api.Data.Model
{
    [DynamoDBTable("FormsPdf")]
    public class FormsPdf : ITable<Guid>
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        [DynamoDBProperty("Name")]
        public string Name { get; set; }

        [DynamoDBProperty("Html")]
        public string Html { get; set; }

        [DynamoDBProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DynamoDBProperty("UploadStatus")]
        public int UploadStatus { get; set; }
    }
}
