using Library.Library.Books.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookInCart
{
    public interface IGetBookInCartQuery
    {
        Task<List<BookInCartViewModel>> ExecuteAsync();
    }
}
