using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Aws.Lambda.Demo.Api.Business.Abstraction;
using Aws.Lambda.Demo.Api.Business.Mapping;
using Aws.Lambda.Demo.Api.Data.Abstraction;
using Aws.Lambda.Demo.Api.Model;
using Aws.Lambda.Demo.Api.Model.Enum;
using NetCoreHTMLToPDF;

namespace Aws.Lambda.Demo.Api.Business
{
    public class PdfService : IPdfService
    {
        private readonly IRepository<Data.Model.FormsPdf, Guid> _repository;
        private readonly AmazonS3Client _amazonS3Client;
        private readonly HtmlConverter _htmlConverter;

        public PdfService(
            IRepository<Data.Model.FormsPdf, Guid> repository,
            AmazonS3Client amazonS3Client,
            HtmlConverter htmlConverter)
        {
            _repository = repository;
            this._amazonS3Client = amazonS3Client;
            this._htmlConverter = htmlConverter;
        }

        public async Task Create(Guid id, string bucketName)
        {
            var data = await _repository.GetById(id);
            if (data == null)
            {
                return;
            }

            var model = data.ToModel();
            await UpdateStatus(model, UploadStatus.Started);

            var pdf = _htmlConverter.FromHtmlString(model.Html);

            using (var stream = new MemoryStream(pdf))
            {
                await _amazonS3Client.PutObjectAsync(new PutObjectRequest
                {
                    InputStream = stream,
                    BucketName = bucketName,
                    Key = model.Name
                });
            }

            await UpdateStatus(model, UploadStatus.Finished);
        }

        private Task UpdateStatus(FormsPdf model, UploadStatus uploadStatus)
        {
            model.UploadStatus = uploadStatus;
            return _repository.Update(model.ToData());
        }
    }
}
