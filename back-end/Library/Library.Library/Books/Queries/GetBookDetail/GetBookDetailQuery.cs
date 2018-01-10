using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IGetBookDetailQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBookDetailQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<BookViewModel> ExecuteAsync(string bookCode)
        {
            var result = _bookRepository.TableNoTracking.Where(x => x.BookCode == bookCode && x.Enabled.Value)
                .Select(x => new BookViewModel
                {
                    BookId = x.Id,
                    BookCode = x.BookCode,
                    BookName = x.BookName,
                    Tag = x.Tag,
                    Description = x.Description,
                    DateImport = x.DateImport.Value,
                    Amount = x.Amount.Value
                }).FirstOrDefaultAsync();

            return result;
        }
    }
}
