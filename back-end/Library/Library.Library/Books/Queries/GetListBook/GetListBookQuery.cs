using System.Linq;
using System.Threading.Tasks;
using Library.Common.Paging;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetListBook
{
    public class GetListBookQuery : IGetListBookQuery
    {
        private readonly IRepository<Book> _bookRepository;

        public GetListBookQuery(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedList<BookViewModel>> ExecuteAsync(int page, int pageSize, string search)
        {
            IQueryable<BookViewModel> books = _bookRepository.TableNoTracking.Include(x => x.Category).Include(x => x.Publisher).Include(x => x.Supplier)
                .Select(x => new BookViewModel
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
                });

            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(x => x.BookCode == search || x.BookName.Contains(search));
            }

            var result = page == 0 && pageSize == 1 ? await books.ToListAsync() : await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<BookViewModel>(result, page, pageSize, books.Count());
        }
    }
}
