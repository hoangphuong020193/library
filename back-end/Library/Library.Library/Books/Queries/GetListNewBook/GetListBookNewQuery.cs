using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetListNewBook
{
    public class GetListBookNewQuery : IGetListBookNewQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public GetListBookNewQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<BookViewModel>> ExecuteAsync()
        {
            var result = _bookRepository.TableNoTracking.Where(x => x.Enabled.Value).OrderByDescending(x => x.DateImport).Take(10)
                .Select(x => new BookViewModel
                {
                    BookId = x.Id,
                    BookCode = x.BookCode,
                    BookName = x.BookName
                }).ToListAsync();

            return result;
        }
    }
}
