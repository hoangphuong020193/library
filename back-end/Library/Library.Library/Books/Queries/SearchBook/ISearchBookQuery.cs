using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.SearchBook
{
    public interface ISearchBookQuery
    {
        Task<SearchBookResultViewModel> ExecuteAsync(string search, int page, int pageSize);
    }
}
