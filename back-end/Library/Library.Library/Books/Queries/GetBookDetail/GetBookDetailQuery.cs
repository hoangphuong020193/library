using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IGetBookDetailQuery
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<BookFavorite> _bookFavoriteRepository;
        private readonly HttpContext _httpContext;

        public GetBookDetailQuery(
            IRepository<Book> bookRepository,
            IRepository<Publisher> publisherRepository,
            IRepository<Supplier> supplierRepository,
            IRepository<BookFavorite> bookFavoriteRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
            _supplierRepository = supplierRepository;
            _bookFavoriteRepository = bookFavoriteRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<BookViewModel> ExecuteAsync(string bookCode)
        {
            var userId = 0;
            int.TryParse(_httpContext?.User?.UserId(), out userId);

            BookViewModel model = new BookViewModel();

            if (userId == 0)
            {
                model = await (from book in _bookRepository.TableNoTracking.Where(x => x.BookCode == bookCode && x.Enabled.Value)
                               join publisher in _publisherRepository.TableNoTracking on book.PublisherId equals publisher.Id into publishers
                               from publisher in publishers.DefaultIfEmpty()
                               join supplier in _supplierRepository.TableNoTracking on book.SupplierId equals supplier.Id into suppliers
                               from supplier in suppliers.DefaultIfEmpty()
                               select new BookViewModel
                               {
                                   BookId = book.Id,
                                   BookCode = book.BookCode,
                                   BookName = book.BookName,
                                   Tag = book.Tag,
                                   Description = book.Description,
                                   DateImport = book.DateImport.Value,
                                   Amount = book.Amount.Value,
                                   AmountAvailable = book.AmountAvailable.Value,
                                   Author = book.Author,
                                   Publisher = publisher != null ? publisher.Name : "Đang cập nhập",
                                   Supplier = supplier != null ? supplier.Name : "Đang cập nhập",
                                   Size = book.Size,
                                   Format = book.Format,
                                   PublicationDate = book.PublicationDate.Value,
                                   Pages = book.Pages.Value,
                                   MaximumDateBorrow = book.MaximumDateBorrow,
                                   Favorite = false
                               }).FirstOrDefaultAsync();
            }
            else
            {
                model = await (from book in _bookRepository.TableNoTracking.Where(x => x.BookCode == bookCode && x.Enabled.Value)
                               join publisher in _publisherRepository.TableNoTracking on book.PublisherId equals publisher.Id into publishers
                               from publisher in publishers.DefaultIfEmpty()
                               join supplier in _supplierRepository.TableNoTracking on book.SupplierId equals supplier.Id into suppliers
                               from supplier in suppliers.DefaultIfEmpty()
                               join favorite in _bookFavoriteRepository.TableNoTracking.Where(x => x.UserId == userId) on book.Id equals favorite.BookId into favorites
                               from favorite in favorites.DefaultIfEmpty()
                               select new BookViewModel
                               {
                                   BookId = book.Id,
                                   BookCode = book.BookCode,
                                   BookName = book.BookName,
                                   Tag = book.Tag,
                                   Description = book.Description,
                                   DateImport = book.DateImport.Value,
                                   Amount = book.Amount.Value,
                                   AmountAvailable = book.AmountAvailable.Value,
                                   Author = book.Author,
                                   Publisher = publisher != null ? publisher.Name : "Đang cập nhập",
                                   Supplier = supplier != null ? supplier.Name : "Đang cập nhập",
                                   Size = book.Size,
                                   Format = book.Format,
                                   PublicationDate = book.PublicationDate.Value,
                                   Pages = book.Pages.Value,
                                   MaximumDateBorrow = book.MaximumDateBorrow,
                                   Favorite = favorite != null
                               }).FirstOrDefaultAsync();
            }


            return model;
        }
    }
}
