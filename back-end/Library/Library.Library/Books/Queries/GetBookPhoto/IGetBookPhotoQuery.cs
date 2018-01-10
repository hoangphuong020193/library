using Library.Library.Books.ViewModels;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.GetBookPhoto
{
    public interface IGetBookPhotoQuery
    {
        Task<BookPhotoViewModel> ExecuteAsync(string code);
    }
}
