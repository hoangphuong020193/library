using Library.Library.Books.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetListBookByRequestCode
{
    public interface IGetListBookByRequestCodeQuery
    {
        Task<List<BookBorrowViewModel>> ExecuteAsync(string code);
    }
}
