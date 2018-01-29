using Library.Common.Paging;
using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetListBook
{
    public interface IGetListBookQuery
    {
        Task<PagedList<BookViewModel>> ExecuteAsync(int page, int pageSize, string search);
    }
}
