using Library.Common.Paging;
using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.BookBorrowAmount
{
    public interface IBookBorrowAmountQuery
    {
        Task<PagedList<BookBorrowAmountViewModel>> ExecuteAsync(int page, int pageSize, string startDate, string endDate);
    }
}
