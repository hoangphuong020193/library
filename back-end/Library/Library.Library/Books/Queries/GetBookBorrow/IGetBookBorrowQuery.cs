using Library.Common.Paging;
using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookBorrow
{
    public interface IGetBookBorrowQuery
    {
        Task<PagedList<BookBorrowViewModel>> ExecuteAsync(int page, int pageSize, string status);
    }
}
