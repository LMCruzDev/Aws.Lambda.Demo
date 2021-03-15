using System.Threading.Tasks;

namespace Aws.Lambda.Demo.Api.Data.Abstraction
{
    public interface IRepository<TModel, TKey>
        where TModel : class, ITable<TKey>
    {
        Task<TModel> GetById(TKey id);

        Task Update(TModel model);
    }
}
