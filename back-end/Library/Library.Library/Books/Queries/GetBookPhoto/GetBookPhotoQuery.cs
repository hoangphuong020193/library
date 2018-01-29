using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetBookPhoto
{
    public class GetBookPhotoQuery : IGetBookPhotoQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBookPhotoQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookPhotoViewModel> ExecuteAsync(string code)
        {
            return await _bookRepository.TableNoTracking.Where(x => x.BookCode == code)
                  .Select(x => new BookPhotoViewModel
                  {
                      Content = x.BookImage
                  }).FirstOrDefaultAsync();
        }
    }
}
