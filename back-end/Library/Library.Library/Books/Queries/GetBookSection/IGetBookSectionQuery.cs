using Library.Library.Books.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookSection
{
    public interface IGetBookSectionQuery
    {
        Task<List<BookViewModel>> ExecuteAsync(string sectionType, int take = 10);
    }
}
