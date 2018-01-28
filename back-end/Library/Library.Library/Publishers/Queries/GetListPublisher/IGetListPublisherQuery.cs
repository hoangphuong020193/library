using Library.Library.Publishers.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Publishers.Queries.GetListPublisher
{
    public interface IGetListPublisherQuery
    {
        Task<List<PublisherViewModel>> ExecuteAsync();
    }
}
