using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookDetail
{
    public interface IGetBookDetailQuery
    {
        Task<BookViewModel> ExecuteAsync(string bookCode);
    }
}
