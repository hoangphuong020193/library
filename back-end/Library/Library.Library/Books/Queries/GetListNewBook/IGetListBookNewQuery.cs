using Library.Library.Books.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetListNewBook
{
    public interface IGetListBookNewQuery
    {
        Task<List<BookViewModel>> ExecuteAsync();
    }
}
