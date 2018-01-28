using Library.Data.Entities.Library;
using Library.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.Library.Books.Queries.CheckBookExistsCode
{
    public class CheckBookCodeExistsQuery : ICheckBookCodeExistsQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public CheckBookCodeExistsQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> ExecuteAsync(int bookId, string bookCode)
        {
            var result = await _bookRepository.TableNoTracking.AnyAsync(x => x.Id != bookId && x.BookCode == bookCode);
            return result;
        }
    }
}
