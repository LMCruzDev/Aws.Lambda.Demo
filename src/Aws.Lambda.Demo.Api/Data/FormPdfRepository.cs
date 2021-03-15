using System;
using Amazon.DynamoDBv2;
using Aws.Lambda.Demo.Api.Data.Model;

namespace Aws.Lambda.Demo.Api.Data
{
    public class FormPdfRepository : BaseRepository<FormsPdf, Guid>
    {
        public FormPdfRepository(AmazonDynamoDBClient dbClient) : base(dbClient)
        {
        }
    }
}
