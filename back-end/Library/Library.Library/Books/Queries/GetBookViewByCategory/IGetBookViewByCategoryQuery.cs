using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookViewByCategory
{
    public interface IGetBookViewByCategoryQuery
    {
        Task<SearchBookResultViewModel> ExecuteAsync(string view, int page, int pageSize);
    }
}
