using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.SearchBook
{
    public class SearchBookQuery : ISearchBookQuery
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        public SearchBookQuery(
            IRepository<Book> bookRepository,
            IRepository<Category> categoryRepository,
            IRepository<Publisher> publisherRepository,
            IRepository<Supplier> supplierRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<SearchBookResultViewModel> ExecuteAsync(string search, int page, int pageSize)
        {
            if (string.IsNullOrEmpty(search) || page < 0)
            {
                return new SearchBookResultViewModel();
            }

            search = search.Trim().ToLowerInvariant();

            var listBooks = from book in _bookRepository.TableNoTracking
                            join category in _categoryRepository.TableNoTracking on book.CategoryId equals category.Id
                            join publisher in _publisherRepository.TableNoTracking on book.PublisherId equals publisher.Id into publishers
                            from publisher in publishers.DefaultIfEmpty()
                            join supplier in _supplierRepository.TableNoTracking on book.SupplierId equals supplier.Id into suppliers
                            from supplier in suppliers.DefaultIfEmpty()
                            where book.BookName.ToLower().Contains(search)
                            || category.CategoryName.ToLower().Contains(search)
                            || book.Author.ToLower().Contains(search)
                            || (publisher != null && publisher.Name.ToLower().Contains(search))
                            || (supplier != null && supplier.Name.ToLower().Contains(search))
                            select new BookViewModel
                            {
                                BookId = book.Id,
                                BookCode = book.BookCode,
                                BookName = book.BookName
                            };

            var result = page == 0 && pageSize == 1 ? await listBooks.ToListAsync() : await listBooks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            SearchBookResultViewModel model = new SearchBookResultViewModel();
            model.Total = await listBooks.CountAsync();
            model.ListBooks = result;

            return model;
        }
    }
}
