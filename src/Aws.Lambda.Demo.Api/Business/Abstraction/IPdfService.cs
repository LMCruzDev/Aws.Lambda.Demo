using System;
using System.Threading.Tasks;
using Aws.Lambda.Demo.Api.Model;
using Aws.Lambda.Demo.Api.Model.Enum;

namespace Aws.Lambda.Demo.Api.Business.Abstraction
{
    public interface IPdfService
    {
        Task Create(Guid id, string bucketName);
    }
}
