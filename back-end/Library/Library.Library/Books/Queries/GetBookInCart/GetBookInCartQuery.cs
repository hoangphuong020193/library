using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Data.Entities.Library;
using Library.Data.Services;
using Library.Library.Books.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Library.Library.Books.Queries.GetBookInCart
{
    public class GetBookInCartQuery : IGetBookInCartQuery
    {
        public readonly IRepository<BookCart> _bookCartRepository;
        private readonly HttpContext _httpContext;

        public GetBookInCartQuery(
            IRepository<BookCart> bookCartRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookCartRepository = bookCartRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<List<BookInCartViewModel>> ExecuteAsync()
        {
            var userId = int.Parse(_httpContext?.User?.UserId());

            var result = await _bookCartRepository.TableNoTracking
                .Include(x => x.Book)
                .Where(x => x.UserId == userId)
                .Select(x => new BookInCartViewModel
                {
                    BookId = x.BookId.Value,
                    BookCode = x.Book.BookCode,
                    BookName = x.Book.BookName,
                    Author = x.Book.Author,
                    Amoun = x.Book.Amount.Value,
                    AmountAvailable = x.Book.AmountAvailable.Value,
                    Status = x.Status,
                    ModifiedDate = x.ModifiedDate.Value,
                    MaximumDateBorrow = x.Book.MaximumDateBorrow

                }).ToListAsync();

            return result;
        }
    }
}
