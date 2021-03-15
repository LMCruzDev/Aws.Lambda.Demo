using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.S3;
using Aws.Lambda.Demo.Api.Business;
using Aws.Lambda.Demo.Api.Business.Abstraction;
using Aws.Lambda.Demo.Api.Data;
using Aws.Lambda.Demo.Api.Messaging.Model;
using NetCoreHTMLToPDF;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Aws.Lambda.Demo.Api
{
    public class Function
    {
        private readonly IPdfService pdfService = new PdfService(
            new FormPdfRepository(new AmazonDynamoDBClient()),
            new AmazonS3Client(),
            new HtmlConverter());

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function()
        {
        }


        /// <summary>
        /// This method is called for every Lambda invocation. This method takes in an SQS event object and can be used 
        /// to respond to SQS messages.
        /// </summary>
        /// <param name="evnt"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Handler(SQSEvent evnt, ILambdaContext context)
        {
            foreach(var message in evnt.Records)
            {
                await ProcessMessageAsync(message, context);
            }
        }

        private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.LogLine($"Processed message {message.Body}");

            var model = JsonConvert.DeserializeObject<FormPdfMessage>(message.Body);

            var bucketName = Environment.GetEnvironmentVariable("S3BucketName");

            await this.pdfService.Create(model.Id, bucketName);

            // TODO: Do interesting work based on the new message
            await Task.CompletedTask;
        }
    }
}
