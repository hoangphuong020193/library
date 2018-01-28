using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetBookByBookCode
{
    public class GetBookByBookCodeQuery : IGetBookByBookCodeQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public GetBookByBookCodeQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookViewModel> ExecuteAsync(string bookCode)
        {
            var result = await _bookRepository.TableNoTracking.Select(x => new BookViewModel
            {
                BookId = x.Id,
                BookCode = x.BookCode,
                BookName = x.BookName,
                CategoryId = x.CategoryId.Value,
                CategoryName = x.Category.CategoryName,
                CategoryType = x.Category.Type,
                Tag = x.Tag,
                Description = x.Description,
                DateImport = x.DateImport.Value,
                Amount = x.Amount.Value,
                AmountAvailable = x.AmountAvailable.Value,
                Author = x.Author,
                PublisherId = x.Publisher != null ? x.PublisherId.Value : 0,
                Publisher = x.Publisher != null ? x.Publisher.Name : "Đang cập nhập",
                SupplierId = x.Supplier != null ? x.SupplierId.Value : 0,
                Supplier = x.Supplier != null ? x.Supplier.Name : "Đang cập nhập",
                Size = x.Size,
                Format = x.Format,
                PublicationDate = x.PublicationDate.Value,
                Pages = x.Pages.Value,
                MaximumDateBorrow = x.MaximumDateBorrow,
                Enabled = x.Enabled.Value
            }).FirstOrDefaultAsync(x => x.BookCode == bookCode);
            return result;
        }
    }
}
