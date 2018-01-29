using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookByBookCode
{
    public interface IGetBookByBookCodeQuery
    {
        Task<BookViewModel> ExecuteAsync(string bookCode);
    }
}
