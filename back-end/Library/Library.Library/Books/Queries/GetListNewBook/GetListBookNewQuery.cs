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
            var result = _bookRepository.TableNoTracking.Include(x => x.Category).Where(x => x.Enabled.Value).OrderByDescending(x => x.DateImport).Take(10)
                .Select(x => new BookViewModel
                {
                    Id = x.Id,
                    CategoryId = x.Category.Id,
                    CategoryName = x.Category.CategoryName,
                    BookName = x.BookName,
                    Tag = x.Tag,
                    Description = x.Description,
                    BookImage = x.BookImage,
                    DateImport = x.DateImport.Value,
                    Amount = x.Amount.Value
                }).ToListAsync();

            return result;
        }
    }
}
