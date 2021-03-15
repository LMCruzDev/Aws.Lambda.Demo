using System;
using FormsData = Aws.Lambda.Demo.Api.Data.Model;
using FormsModel = Aws.Lambda.Demo.Api.Model;

namespace Aws.Lambda.Demo.Api.Business.Mapping
{
    public static class FormsPdfMapper
    {
        public static FormsModel.FormsPdf ToModel(this FormsData.FormsPdf model)
        {
            return new FormsModel.FormsPdf
            {
                Id = model.Id,
                Name = model.Name,
                Html = model.Html,
                CreatedDate = model.CreatedDate,
                UploadStatus = (FormsModel.Enum.UploadStatus)model.UploadStatus
            };
        }

        public static FormsData.FormsPdf ToData(this FormsModel.FormsPdf model)
        {
            return new FormsData.FormsPdf
            {
                Id = model.Id,
                Name = model.Name,
                Html = model.Html,
                CreatedDate = model.CreatedDate,
                UploadStatus = (int)model.UploadStatus
            };
        }
    }
}
